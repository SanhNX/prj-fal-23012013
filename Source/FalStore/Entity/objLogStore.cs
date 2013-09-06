﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class objLogStore
    {
        //ID
        public string LogStoreID { get; set; }
        //Log type
        public int LogType { get; set; }
        //Employee object
        public objEmployee Employee { get; set; }
        //Log date
        public string LogDate { get; set; }
        //Branch object from
        public objBranch BranchFrom { get; set; }
        //NCC
        public string NCC { get; set; }
        //Branch object to
        public objBranch BranchTo { get; set; }
        //Description
        public string Description { get; set; }
        //Status
        public int Status { get; set; }
        //Delete Flag
        public int Delete_Flg { get; set; }
        //Create date
        public DateTime CreateDate { get; set; }
        //Create user
        public string CreateUser { get; set; }
        //Update date
        public DateTime UpdateDate { get; set; }
        //Update user
        public string UpdateUser { get; set; }

    }
}
