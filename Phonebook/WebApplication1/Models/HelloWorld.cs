using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class HelloWorld
    {
        public int ID { get; set; }

        [Required]
        [Display (Name = "Full Name")]
        public string name { get; set; }

        [Required]
        [DataType (DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string mobile { get; set; }


        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string  Eadd { get; set; }
        
    }

    public class HelloWorldDbContext : DbContext
    {
        public DbSet<HelloWorld> Contacts { get; set; } 

    }
}