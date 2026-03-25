using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// Groq API'ye gönderilecek request modeli
    /// </summary>
    public class BGroqRequest
    {
        public string model { get; set; } = "llama-3.3-70b-versatile";
        public List<BGroqMessage> messages { get; set; }
        public List<BGroqTool> tools { get; set; }
        public string tool_choice { get; set; } // "auto", "none", veya tool adı
        public double? temperature { get; set; } = 0.7;
        public int? max_tokens { get; set; } = 4096;
    }
}



