using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class ContactViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display (Name = "Contact Name")]
        public string name { get; set; }

        [Display(Name = "Contact Type")]
        public string SelectedContactType { get; set; }
        public IEnumerable<SelectListItem> ContactTypes { get; set; }

        [Required]
        [DataType (DataType.PhoneNumber)]
   
        [Display(Name = "Contact Number")]
        [StringLength(11)]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "Contact number should contain only numbers")]
        public string  mobile{ get; set; }


        [Display(Name = "Email Address")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string  Eadd { get; set; }
        
    }

    public class ContactDbContext : DbContext
    {
        public DbSet<ContactViewModel> Contacts { get; set; } 

    }
}