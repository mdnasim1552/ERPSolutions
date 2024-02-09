using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEntity.Account
{
    public class Company
    {
        //select comcod,comsnam, comnam, comadd1,comadd2, comadd3, comadd4 from compinf order by comcod asc
        public string comcod { get; set; }
        public string? comsnam { get; set; }
        public string? comnam { get; set; }
        public string? comadd1 { get; set; }
        public string? comadd2 { get; set; }
        public string? comadd3 { get; set; }
        public string? comadd4 { get; set; }
        public Company()
        {
            
        }
    }
}
