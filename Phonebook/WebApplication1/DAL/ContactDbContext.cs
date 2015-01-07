using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext() : base("ContactDbContext")
        {
        }

        public DbSet<PersonalInfo> PersonalInfos { get; set; }
        public DbSet<ContactNumber> ContactNumbers { get; set; }
        public DbSet<EmailAdd> EmailAdds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}