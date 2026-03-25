using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKlinik.Hasta.Business
{
    public class BChatMesaj
    {
        private string _rol;
        private string _icerik;

        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public string Icerik
        {
            get { return _icerik; }
            set { _icerik = value; }
        }
    }
}



