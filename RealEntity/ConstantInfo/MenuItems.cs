using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEntity.ConstantInfo
{
    [Serializable]
    public class MenuItems
    {
        public string itemcod { get; set; }
        public string itemdesc { get; set; }
        public string itemurl { get; set; }
        public string fbold { get; set; }
        public bool itemslct { get; set; }
        public string itemposition { get; set; }

        //mnuTbl1.Columns.Add("itemcod", Type.GetType("System.String"));
        //    mnuTbl1.Columns.Add("itemdesc", Type.GetType("System.String"));
        //    mnuTbl1.Columns.Add("itemurl", Type.GetType("System.String"));
        //    mnuTbl1.Columns.Add("itemtips", Type.GetType("System.String"));
        //    mnuTbl1.Columns.Add("itemslct", Type.GetType("System.Boolean"));
        //    mnuTbl1.Columns.Add("fbold", Type.GetType("System.String"));
        public MenuItems()
        {
                
        }
    }
}
