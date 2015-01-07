using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class ContactNumber
    {
        public int ID { get; set; }

        public int ContactID { get; set; }

        [Display(Name = "Contact Type")]
        public string SelectedContactType { get; set; }
        public IEnumerable<SelectListItem> ContactTypes { get; set; }

        [Required]
        [Display(Name = "Contact Number")]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Contact number should contain only numbers")]
        public string mobile { get; set; }

        public virtual PersonalInfo PersonalInfo { get; set; }

    }
}