using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealERPLIB
{
    public class ListOfModules
    {
        public List<ListOfModules> listOfModules = new List<ListOfModules>();
        public int id { get; set; }
        public string moduleName { get; set; }
        public string comcod { get; set; }
        public ListOfModules()
        {
            listOfModules.Add(new ListOfModules { id=1,moduleName= "Annual Business Plan", comcod="3101" });
        }

    }
}
