﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEntity.Account
{
    [Serializable]
    public class Userinf
    {
        public Userinf()
        {
            //select comcod,usrid,usrsname,usrname,usrdesig,usractive,usrpass,mailid,empid,userrole from userinf
        }
        public int row_num { get; set; }
        public string comcod { get; set; }
        public string usrid { get; set; }
        public string usrsname { get; set; }
        public string usrname { get; set;}
        public string usrdesig { get; set; }
        public bool usractive { get; set; }
        public string usrpass { get; set; }
        public string mailid { get; set; }
        public string? empid { get; set; }
        public string userrole { get; set; }

        public string roledesc { get; set; }    
    }
}
