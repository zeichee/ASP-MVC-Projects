using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmailAdd
    {
        public int ID { get; set; }

        public int EmailAddID { get; set; }


        [Display(Name = "Email Address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Eadd { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }
    }
}