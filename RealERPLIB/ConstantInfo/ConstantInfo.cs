﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEntity.ConstantInfo;

namespace RealERPLIB.ConstantInfo
{
    public static class ConstantInfo
    {
        public static List<MenuItems> MenuAllHR()
        {
            List<MenuItems> menuitems=new List<MenuItems> ();
            menuitems.Add(new MenuItems { itemcod= "0204000000", itemdesc= "B. Appointment", itemurl="",fbold= "mb", itemslct=false, itemposition="1st" });
            menuitems.Add(new MenuItems { itemcod = "0205000000", itemdesc = "01. Department Code", itemurl = "F_21_GAcc/AccSubCodeBook?InputType=Dept", fbold = "", itemslct = true, itemposition = "1st" });
            menuitems.Add(new MenuItems { itemcod = "0205000000", itemdesc = "01. Department Code", itemurl = "F_21_GAcc/AccSubCodeBook?InputType=Dept", fbold = "", itemslct = true, itemposition = "1st" });
            //menuitems.Add(new MenuItems { itemcod = "", itemdesc = "", itemurl = "", fbold = "" });
            //menuitems.Add(new MenuItems { itemcod = "", itemdesc = "", itemurl = "", fbold = "" });
            return menuitems;
        }
    }
}
