using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DisKlinik.Hasta.Business;

namespace DisKlinik.Hasta.Service
{
    public class SYapayZeka
    {
        private const string ApiKey = "APİ KEY BURAYA GİRİLİR";
        private const string ApiUrl = "https://api.groq.com/openai/v1/chat/completions";
        private const string SystemPrompt = "Sen bir diş kliniği asistanısın. Doktorun sorularına veritabanı araçlarını kullanarak cevap verirsin. Türkçe cevap ver.\n\nÖNEMLİ KURALLAR:\n1. Bir Tool (araç) sana veri listesi döndürdüğünde (örneğin hasta listesi), asla özet geçme veya içinden örnek seçme. Listenin TAMAMINI kullanıcıya maddeler halinde (bullet points) yaz.\n2. Finansal sorular sorulduğunda net rakamlar ver ve para birimi olarak TL kullan.\n3. Randevuları listelerken tarih ve saati net belirt.\n4. Randevu oluştururken tarih ve saatin formatına dikkat et. Tarih YYYY-MM-DD, saat HH:MM formatında olmalı. Eğer kullanıcı eksik bilgi verirse (örneğin saati söylemezse), işlemi yapmadan önce eksik bilgiyi sor.";

        // Conversation history (session bazlı)
        private static Dictionary<string, List<BGroqMessage>> _conversations = new Dictionary<string, List<BGroqMessage>>();

        /// <summary>
        /// Mevcut basit metod (geriye dönük uyumluluk için)
        /// </summary>
        public static async Task<string> YapayZekayaSorAsenkron(string soru)
        {
            return await YapayZekayaSorAsenkron(soru, "default");
        }

        /// <summary>
        /// Function Calling destekli AI sorgulama
        /// </summary>
        public static async Task<string> YapayZekayaSorAsenkron(string soru, string sessionId = "default")
        {
            if (string.IsNullOrEmpty(soru))
            {
                return "Lütfen bir soru giriniz.";
            }

         

            try
            {
                // Conversation history'yi al veya oluştur
                if (!_conversations.ContainsKey(sessionId))
                {
                    _conversations[sessionId] = new List<BGroqMessage>
                    {
                        new BGroqMessage { role = "system", content = SystemPrompt }
                    };
                }

                // Kullanıcı mesajını ekle
                _conversations[sessionId].Add(new BGroqMessage
                {
                    role = "user",
                    content = soru
                });

                // Tool tanımlarını hazırla
                var tools = GetAvailableTools();

                // API isteğini gönder
                string finalAnswer = await ProcessConversationWithTools(_conversations[sessionId], tools, sessionId);

                return finalAnswer;
            }
            catch (Exception ex)
            {
                return $"Hata oluştu: {ex.Message}";
            }
        }

        /// <summary>
        /// Tool çağrılarını işleyerek conversation'ı tamamlar
        /// </summary>
        private static async Task<string> ProcessConversationWithTools(
            List<BGroqMessage> messages, 
            List<BGroqTool> tools, 
            string sessionId,
            int maxIterations = 5)
        {
            int iteration = 0;

            while (iteration < maxIterations)
            {
                // API isteği gönder
                BGroqResponse response = await SendApiRequest(messages, tools);

                if (response == null || response.choices == null || response.choices.Count == 0)
                {
                    return "API'den geçerli bir yanıt alınamadı.";
                }

                BGroqMessage assistantMessage = response.choices[0].message;
                messages.Add(assistantMessage);

                // Eğer tool çağrısı varsa
                if (assistantMessage.tool_calls != null && assistantMessage.tool_calls.Count > 0)
                {
                    // Her tool çağrısını işle
                    foreach (var toolCall in assistantMessage.tool_calls)
                    {
                        string functionName = toolCall.function.name;
                        string functionArgs = toolCall.function.arguments;

                        // Tool fonksiyonunu çalıştır
                        string toolResult = await ExecuteToolFunction(functionName, functionArgs);

                        // Tool sonucunu conversation'a ekle
                        messages.Add(new BGroqMessage
                        {
                            role = "tool",
                            tool_call_id = toolCall.id,
                            content = toolResult
                        });
                    }

                    // Tool sonuçlarıyla tekrar API'ye istek gönder
                    iteration++;
                    continue;
                }
                else
                {
                    // Normal cevap döndü
                    return assistantMessage.content ?? "Cevap alınamadı.";
                }
            }

            return "Maksimum iterasyon sayısına ulaşıldı. Lütfen tekrar deneyin.";
        }

        /// <summary>
        /// Groq API'ye HTTP isteği gönderir
        /// </summary>
        private static async Task<BGroqResponse> SendApiRequest(List<BGroqMessage> messages, List<BGroqTool> tools)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");
                client.Timeout = TimeSpan.FromSeconds(60);

                var request = new BGroqRequest
                {
                    model = "llama-3.3-70b-versatile",
                    messages = messages,
                    tools = tools,
                    tool_choice = "auto",
                    temperature = 0.7,
                    max_tokens = 4096
                };

                string jsonBody = JsonConvert.SerializeObject(request, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

                StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseJson = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<BGroqResponse>(responseJson);
                }
                else
                {
                    string errorContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"API Hatası: {response.StatusCode} - {errorContent}");
                }
            }
        }

        /// <summary>
        /// Mevcut tool fonksiyonlarını tanımlar
        /// </summary>
        private static List<BGroqTool> GetAvailableTools()
        {
            return new List<BGroqTool>
            {
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "GetPatients",
                        description = "Veritabanındaki tüm hastaların isimlerini listeler. Hasta listesi sorgusu için kullanılır.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>(),
                            required = new List<string>()
                        }
                    }
                },
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "GetDoctors",
                        description = "Klinikteki doktorların listesini getirir.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>(),
                            required = new List<string>()
                        }
                    }
                },
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "GetAppointments",
                        description = "Gelecek veya bugünkü randevuları listeler.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>(),
                            required = new List<string>()
                        }
                    }
                },
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "GetFinancialSummary",
                        description = "Kliniğin toplam kazancını (tahsilat) ve hastaların toplam borcunu (alacak) getirir.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>(),
                            required = new List<string>()
                        }
                    }
                },
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "GetPatientDebtByName",
                        description = "İsmi verilen belirli bir hastanın güncel borç bilgisini getirir.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>
                            {
                                {
                                    "patientName",
                                    new BGroqFunctionProperty
                                    {
                                        type = "string",
                                        description = "Hastanın adı veya soyadı (kısmi eşleşme yapılır)"
                                    }
                                }
                            },
                            required = new List<string> { "patientName" }
                        }
                    }
                },
                new BGroqTool
                {
                    type = "function",
                    function = new BGroqFunction
                    {
                        name = "CreateAppointment",
                        description = "Yeni bir randevu kaydı oluşturur. Tarih, Saat, Hasta Adı ve Doktor Adı gerektirir.",
                        parameters = new BGroqFunctionParameters
                        {
                            type = "object",
                            properties = new Dictionary<string, BGroqFunctionProperty>
                            {
                                {
                                    "patientName",
                                    new BGroqFunctionProperty
                                    {
                                        type = "string",
                                        description = "Hastanın adı ve soyadı"
                                    }
                                },
                                {
                                    "doctorName",
                                    new BGroqFunctionProperty
                                    {
                                        type = "string",
                                        description = "Doktorun adı ve soyadı"
                                    }
                                },
                                {
                                    "date",
                                    new BGroqFunctionProperty
                                    {
                                        type = "string",
                                        description = "Randevu tarihi (YYYY-MM-DD formatında, örn: 2024-12-25)"
                                    }
                                },
                                {
                                    "time",
                                    new BGroqFunctionProperty
                                    {
                                        type = "string",
                                        description = "Randevu saati (HH:MM formatında, örn: 14:30)"
                                    }
                                }
                            },
                            required = new List<string> { "patientName", "doctorName", "date", "time" }
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Tool fonksiyonunu çalıştırır
        /// </summary>
        private static async Task<string> ExecuteToolFunction(string functionName, string argumentsJson)
        {
            try
            {
                switch (functionName)
                {
                    case "GetPatients":
                        return await GetPatientsFunction();
                    
                    case "GetDoctors":
                        return await GetDoctorsFunction();
                    
                    case "GetAppointments":
                        return await GetAppointmentsFunction();
                    
                    case "GetFinancialSummary":
                        return await GetFinancialSummaryFunction();
                    
                    case "GetPatientDebtByName":
                        return await GetPatientDebtByNameFunction(argumentsJson);
                    
                    case "CreateAppointment":
                        return await CreateAppointmentFunction(argumentsJson);
                    
                    default:
                        return $"{{\"error\": \"Bilinmeyen fonksiyon: {functionName}\"}}";
                }
            }
            catch (Exception ex)
            {
                return $"{{\"error\": \"Fonksiyon çalıştırma hatası: {ex.Message}\"}}";
            }
        }

        /// <summary>
        /// GetPatients tool fonksiyonu - Veritabanından hasta isimlerini getirir
        /// </summary>
        private static async Task<string> GetPatientsFunction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    // SHasta servisini kullanarak hasta listesini al
                    SHasta hastaServis = new SHasta();
                    List<BHasta> hastaListesi = hastaServis.HastaListesiGetir();

                    // Ad + " " + Soyad formatında isimleri çıkar
                    var hastaIsimleri = hastaListesi
                        .Where(h => !string.IsNullOrEmpty(h.Ad) || !string.IsNullOrEmpty(h.Soyad))
                        .Select(h => $"{h.Ad} {h.Soyad}".Trim())
                        .ToList();

                    // JSON formatında tam liste olarak döndür (AI'nın tamamını görmesi için)
                    // Newtonsoft.Json kullanarak basit bir string array olarak serialize et
                    return JsonConvert.SerializeObject(hastaIsimleri, Formatting.None);
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Hasta listesi alınırken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// GetDoctors tool fonksiyonu - Veritabanından doktor isimlerini getirir
        /// </summary>
        private static async Task<string> GetDoctorsFunction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    // SDoktor servisini kullanarak doktor listesini al
                    SDoktor doktorServis = new SDoktor();
                    List<BDoktor> doktorListesi = doktorServis.DoktorListesiGetir();

                    // Ad + " " + Soyad formatında isimleri çıkar
                    var doktorIsimleri = doktorListesi
                        .Where(d => !string.IsNullOrEmpty(d.Ad) || !string.IsNullOrEmpty(d.Soyad))
                        .Select(d => $"{d.Ad} {d.Soyad}".Trim())
                        .ToList();

                    // JSON formatında tam liste olarak döndür
                    return JsonConvert.SerializeObject(doktorIsimleri, Formatting.None);
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Doktor listesi alınırken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// GetAppointments tool fonksiyonu - Bugün ve gelecek randevuları getirir
        /// </summary>
        private static async Task<string> GetAppointmentsFunction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    // SRandevu servisini kullanarak randevu listesini al
                    SRandevu randevuServis = new SRandevu();
                    List<BRandevu> randevuListesi = randevuServis.RandevuListesiGetir();

                    // Bugün ve gelecek randevuları filtrele (Durum = true ve tarih >= bugün)
                    var gelecekRandevular = randevuListesi
                        .Where(r => r.Durum && r.RandevuTarihi.Date >= DateTime.Today)
                        .OrderBy(r => r.RandevuTarihi)
                        .Select(r => new
                        {
                            Tarih = r.RandevuTarihi.ToString("dd.MM.yyyy"),
                            Saat = r.RandevuTarihi.ToString("HH:mm"),
                            HastaAd = r.HastaAdi ?? "Bilinmiyor",
                            DoktorAd = r.DoktorAdi ?? "Bilinmiyor",
                            Tedavi = r.TedaviAdi ?? "Belirtilmemiş"
                        })
                        .ToList();

                    // JSON formatında döndür
                    return JsonConvert.SerializeObject(gelecekRandevular, Formatting.None);
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Randevu listesi alınırken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// GetFinancialSummary tool fonksiyonu - Finansal özeti getirir
        /// </summary>
        private static async Task<string> GetFinancialSummaryFunction()
        {
            return await Task.Run(() =>
            {
                try
                {
                    // SOdeme servisini kullanarak kasa özetini al
                    SOdeme odemeServis = new SOdeme();
                    BKasaOzet ozet = odemeServis.KasaOzetGetir();

                    // JSON formatında döndür
                    var result = new
                    {
                        ToplamKazanc = ozet.ToplamTahsilat,
                        ToplamAlacak = ozet.ToplamAlacak > 0 ? ozet.ToplamAlacak : 0
                    };

                    return JsonConvert.SerializeObject(result, Formatting.None);
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Finansal özet alınırken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// GetPatientDebtByName tool fonksiyonu - İsme göre hasta borcunu getirir
        /// </summary>
        private static async Task<string> GetPatientDebtByNameFunction(string argumentsJson)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // JSON parametrelerini parse et
                    JObject args = JObject.Parse(argumentsJson);
                    string patientName = args["patientName"]?.ToString()?.Trim();

                    if (string.IsNullOrEmpty(patientName))
                    {
                        return JsonConvert.SerializeObject(new { error = "Hasta adı parametresi boş olamaz." });
                    }

                    // SHasta servisini kullanarak hasta listesini al
                    SHasta hastaServis = new SHasta();
                    List<BHasta> hastaListesi = hastaServis.HastaListesiGetir();

                    // İsme göre esnek arama (ToLower ile büyük/küçük harf duyarsız)
                    string patientNameLower = patientName.ToLower();
                    var hasta = hastaListesi.FirstOrDefault(h =>
                        (!string.IsNullOrEmpty(h.Ad) && h.Ad.ToLower().Contains(patientNameLower)) ||
                        (!string.IsNullOrEmpty(h.Soyad) && h.Soyad.ToLower().Contains(patientNameLower)) ||
                        (!string.IsNullOrEmpty(h.Ad) && !string.IsNullOrEmpty(h.Soyad) && 
                         $"{h.Ad} {h.Soyad}".ToLower().Contains(patientNameLower)));

                    if (hasta == null)
                    {
                        return JsonConvert.SerializeObject(new { error = $"'{patientName}' adında hasta bulunamadı." });
                    }

                    // SOdeme servisini kullanarak hasta ödeme listesini al
                    SOdeme odemeServis = new SOdeme();
                    List<BOdeme> odemeListesi = odemeServis.OdemeListesiGetir(hasta.TcKimlikNo);

                    // Borç hesapla: IslemTuru = 0 (Borç) - IslemTuru = 1 (Ödeme)
                    decimal toplamBorc = odemeListesi.Where(o => o.IslemTuru == 0).Sum(o => o.Tutar);
                    decimal toplamOdeme = odemeListesi.Where(o => o.IslemTuru == 1).Sum(o => o.Tutar);
                    decimal guncelBorc = toplamBorc - toplamOdeme;

                    // JSON formatında döndür
                    var result = new
                    {
                        Hasta = $"{hasta.Ad} {hasta.Soyad}".Trim(),
                        GuncelBorc = guncelBorc > 0 ? guncelBorc : 0
                    };

                    return JsonConvert.SerializeObject(result, Formatting.None);
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Hasta borcu alınırken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// CreateAppointment tool fonksiyonu - Yeni randevu oluşturur
        /// </summary>
        private static async Task<string> CreateAppointmentFunction(string argumentsJson)
        {
            return await Task.Run(() =>
            {
                try
                {
                    // JSON parametrelerini parse et
                    JObject args = JObject.Parse(argumentsJson);
                    string patientName = args["patientName"]?.ToString()?.Trim();
                    string doctorName = args["doctorName"]?.ToString()?.Trim();
                    string dateStr = args["date"]?.ToString()?.Trim();
                    string timeStr = args["time"]?.ToString()?.Trim();

                    // Parametre validasyonu
                    if (string.IsNullOrEmpty(patientName))
                    {
                        return JsonConvert.SerializeObject(new { error = "Hasta adı boş olamaz." });
                    }
                    if (string.IsNullOrEmpty(doctorName))
                    {
                        return JsonConvert.SerializeObject(new { error = "Doktor adı boş olamaz." });
                    }
                    if (string.IsNullOrEmpty(dateStr))
                    {
                        return JsonConvert.SerializeObject(new { error = "Randevu tarihi boş olamaz." });
                    }
                    if (string.IsNullOrEmpty(timeStr))
                    {
                        return JsonConvert.SerializeObject(new { error = "Randevu saati boş olamaz." });
                    }

                    // Tarih ve saat parse etme
                    DateTime randevuTarihi;
                    try
                    {
                        // Tarih parse (YYYY-MM-DD)
                        if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime tarih))
                        {
                            return JsonConvert.SerializeObject(new { error = "Tarih formatı hatalı. YYYY-MM-DD formatında olmalı (örn: 2024-12-25)." });
                        }

                        // Saat parse (HH:MM)
                        string[] saatParcalari = timeStr.Split(':');
                        if (saatParcalari.Length != 2)
                        {
                            return JsonConvert.SerializeObject(new { error = "Saat formatı hatalı. HH:MM formatında olmalı (örn: 14:30)." });
                        }
                        if (!int.TryParse(saatParcalari[0], out int saat) || saat < 0 || saat > 23)
                        {
                            return JsonConvert.SerializeObject(new { error = "Saat değeri 0-23 arasında olmalı." });
                        }
                        if (!int.TryParse(saatParcalari[1], out int dakika) || dakika < 0 || dakika > 59)
                        {
                            return JsonConvert.SerializeObject(new { error = "Dakika değeri 0-59 arasında olmalı." });
                        }

                        randevuTarihi = tarih.Date.AddHours(saat).AddMinutes(dakika);
                    }
                    catch (Exception ex)
                    {
                        return JsonConvert.SerializeObject(new { error = $"Tarih/saat parse hatası: {ex.Message}" });
                    }

                    // Hasta kontrolü
                    SHasta hastaServis = new SHasta();
                    List<BHasta> hastaListesi = hastaServis.HastaListesiGetir();
                    string patientNameLower = patientName.ToLower();
                    var hasta = hastaListesi.FirstOrDefault(h =>
                        (!string.IsNullOrEmpty(h.Ad) && h.Ad.ToLower().Contains(patientNameLower)) ||
                        (!string.IsNullOrEmpty(h.Soyad) && h.Soyad.ToLower().Contains(patientNameLower)) ||
                        (!string.IsNullOrEmpty(h.Ad) && !string.IsNullOrEmpty(h.Soyad) &&
                         $"{h.Ad} {h.Soyad}".ToLower().Contains(patientNameLower)));

                    if (hasta == null)
                    {
                        return JsonConvert.SerializeObject(new { error = $"'{patientName}' adında hasta bulunamadı." });
                    }

                    // Doktor kontrolü
                    SDoktor doktorServis = new SDoktor();
                    List<BDoktor> doktorListesi = doktorServis.DoktorListesiGetir();
                    string doctorNameLower = doctorName.ToLower();
                    var doktor = doktorListesi.FirstOrDefault(d =>
                        (!string.IsNullOrEmpty(d.Ad) && d.Ad.ToLower().Contains(doctorNameLower)) ||
                        (!string.IsNullOrEmpty(d.Soyad) && d.Soyad.ToLower().Contains(doctorNameLower)) ||
                        (!string.IsNullOrEmpty(d.Ad) && !string.IsNullOrEmpty(d.Soyad) &&
                         $"{d.Ad} {d.Soyad}".ToLower().Contains(doctorNameLower)));

                    if (doktor == null)
                    {
                        return JsonConvert.SerializeObject(new { error = $"'{doctorName}' adında doktor bulunamadı." });
                    }

                    // Müsaitlik kontrolü - Aynı doktorun aynı tarih/saatte aktif randevusu var mı?
                    SRandevu randevuServis = new SRandevu();
                    List<BRandevu> randevuListesi = randevuServis.RandevuListesiGetir();

                    // Aynı doktor, aynı tarih/saat, aktif (Durum=true) randevu var mı?
                    var cakisanRandevu = randevuListesi.FirstOrDefault(r =>
                        r.DoktorSicil == doktor.TcKimlikNo &&
                        r.RandevuTarihi.Date == randevuTarihi.Date &&
                        r.RandevuTarihi.Hour == randevuTarihi.Hour &&
                        r.RandevuTarihi.Minute == randevuTarihi.Minute &&
                        r.Durum == true);

                    if (cakisanRandevu != null)
                    {
                        return JsonConvert.SerializeObject(new { error = $"Doktor {doctorName} {randevuTarihi:dd.MM.yyyy HH:mm} saatinde zaten randevulu. Lütfen başka bir saat seçin." });
                    }

                    // Yeni randevu oluştur
                    BRandevu yeniRandevu = new BRandevu
                    {
                        HastaTc = hasta.TcKimlikNo,
                        DoktorSicil = doktor.TcKimlikNo,
                        RandevuTarihi = randevuTarihi,
                        Notlar = "",
                        Durum = true,
                        TedaviId = null
                    };

                    string sonuc = randevuServis.RandevuEkle(yeniRandevu);

                    if (sonuc != null)
                    {
                        return JsonConvert.SerializeObject(new { error = $"Randevu oluşturulurken hata: {sonuc}" });
                    }

                    // Başarılı
                    return JsonConvert.SerializeObject(new { 
                        success = true, 
                        message = "Randevu başarıyla oluşturuldu.",
                        hasta = $"{hasta.Ad} {hasta.Soyad}".Trim(),
                        doktor = $"{doktor.Ad} {doktor.Soyad}".Trim(),
                        tarih = randevuTarihi.ToString("dd.MM.yyyy HH:mm")
                    });
                }
                catch (Exception ex)
                {
                    return JsonConvert.SerializeObject(new { error = $"Randevu oluşturulurken hata: {ex.Message}" });
                }
            });
        }

        /// <summary>
        /// Conversation history'yi temizler
        /// </summary>
        public static void ClearConversation(string sessionId = "default")
        {
            if (_conversations.ContainsKey(sessionId))
            {
                _conversations[sessionId].Clear();
            }
        }
    }
}
