using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// Groq API'den gelen response modeli
    /// </summary>
    public class BGroqResponse
    {
        public string id { get; set; }
        public string @object { get; set; }
        public long created { get; set; }
        public string model { get; set; }
        public List<BGroqChoice> choices { get; set; }
        public BGroqUsage usage { get; set; }
    }

    public class BGroqChoice
    {
        public int index { get; set; }
        public BGroqMessage message { get; set; }
        public string finish_reason { get; set; } // "stop", "tool_calls", vb.
    }

    public class BGroqUsage
    {
        public int prompt_tokens { get; set; }
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}



