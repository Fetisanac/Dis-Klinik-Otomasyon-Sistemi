using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// Groq API mesaj modeli
    /// </summary>
    public class BGroqMessage
    {
        public string role { get; set; } // "system", "user", "assistant", "tool"
        public string content { get; set; }
        public string name { get; set; } // tool çağrıları için fonksiyon adı
        public List<BGroqToolCall> tool_calls { get; set; } // AI'dan gelen tool çağrıları
        public string tool_call_id { get; set; } // tool sonuçları için
    }
}



