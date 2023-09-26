using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEntity.Masterpage
{
    public class MasterClass
    {
        [Serializable]
        public class Modules
        {
            public string moduleid { get; set; }
            public string modulename { get; set; }
            public Modules()
            {
                
            }
        }
        [Serializable]
        public class Interfaces
        {
            public string comcod { get; set; }
            public string interfaceid { get; set; }
            public string interfacename { get; set; }
            public Interfaces()
            {
                
            }
        }
    }
}
