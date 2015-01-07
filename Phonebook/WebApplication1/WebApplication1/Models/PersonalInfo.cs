using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace WebApplication1.Models
{
    public class PersonalInfo
    {
        public int ID { get; set; }

        [Required]
        [StringLength(30)]
        [Display (Name = "Last Name")]
        public string lastName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "First Name")]
        public string firstName { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Middle Name")]

        public string middleName { get; set; }
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Home Address")]
        [StringLength(50)]
        public string Address { get; set; }

        [Display(Name = "Company")]
        [StringLength(30)]
        public string Company { get; set; }


        public virtual ICollection<ContactNumber> ContactNumbers { get; set; }
        public virtual ICollection<EmailAdd> EmailAdds { get; set; }

        
    }

    
}