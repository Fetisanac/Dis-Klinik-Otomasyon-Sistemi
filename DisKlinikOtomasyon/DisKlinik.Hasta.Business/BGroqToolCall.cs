using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// AI'dan gelen tool çağrısı
    /// </summary>
    public class BGroqToolCall
    {
        public string id { get; set; }
        public string type { get; set; } // "function"
        public BGroqFunctionCall function { get; set; }
    }

    public class BGroqFunctionCall
    {
        public string name { get; set; } // Fonksiyon adı (örn: "GetPatients")
        public string arguments { get; set; } // JSON string olarak parametreler
    }
}



