using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    /// <summary>
    /// AI'ya tanıtılacak tool/fonksiyon tanımı
    /// </summary>
    public class BGroqTool
    {
        public string type { get; set; } = "function";
        public BGroqFunction function { get; set; }
    }

    public class BGroqFunction
    {
        public string name { get; set; }
        public string description { get; set; }
        public BGroqFunctionParameters parameters { get; set; }
    }

    public class BGroqFunctionParameters
    {
        public string type { get; set; } = "object";
        public Dictionary<string, BGroqFunctionProperty> properties { get; set; }
        public List<string> required { get; set; }
    }

    public class BGroqFunctionProperty
    {
        public string type { get; set; }
        public string description { get; set; }
    }
}



