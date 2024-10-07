﻿using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    [Table("UserDetail", Schema = "User")]
    public class UserDetail 
    {

        public UserDetail()
        {
            //UserID = null;
            Address = null;
            Phone = null;
            Image = null;
            //User = null;
        }

        public long UserID { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }


        public virtual User User { get; set; }
    }
}