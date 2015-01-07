using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class ContactsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ContactDbContext>
    {
        protected override void Seed(ContactDbContext context)
        {
            var contacts = new List<PersonalInfo>
            {
                new PersonalInfo{lastName = "De Guzman",firstName = "Rogin Neil",middleName = "Tawatao",Birthdate = DateTime.Parse("11/03/1995"),Address = "Mabini Pangasinan",Company = "VSS IT Development"},
                new PersonalInfo{lastName = "Serapion",firstName = "Reymark",middleName = "Tracker",Birthdate = DateTime.Parse("10/01/1992"),Address = "Mangaldan Pangasinan",Company = "VSS IT Development"},
                new PersonalInfo{lastName = "Daz",firstName = "John Ralph",middleName = "Maksil",Birthdate = DateTime.Parse("05/03/1995"),Address = "Mangaldan Pangasinan",Company = "VSS IT Development"},
                new PersonalInfo{lastName = "Idio",firstName = "France Ginno",middleName = "Kras",Birthdate = DateTime.Parse("07/03/1995"),Address = "Sta. Barbara Pangasinan",Company = "VSS IT Development"}
            };
            contacts.ForEach(s=>context.PersonalInfos.Add(s));
            context.SaveChanges();
            var contactNumbers = new List<ContactNumber>
            {
                new ContactNumber{ContactID = 1,SelectedContactType = "Mobile",mobile = "09055545630"},
                new ContactNumber{ContactID = 2,SelectedContactType = "Mobile",mobile = "09055555555"},
                new ContactNumber{ContactID = 3,SelectedContactType = "Mobile",mobile = "09055545630"},
                new ContactNumber{ContactID = 4,SelectedContactType = "Mobile",mobile = "09055545630"},
                new ContactNumber{ContactID = 1,SelectedContactType = "Mobile",mobile = "09431596934"}
            };
            contactNumbers.ForEach(s => context.ContactNumbers.Add(s));
            context.SaveChanges();

            var emailAdds = new List<EmailAdd>
            {
                new EmailAdd{EmailAddID = 1,Eadd = "ichaosblade@gmail.com"},
                new EmailAdd{EmailAddID = 2,Eadd = "tracker@gmail.com"},
                new EmailAdd{EmailAddID = 2,Eadd = "tracker28@gmail.com"},
                new EmailAdd{EmailAddID = 3,Eadd = "ginno@gmail.com"},
                new EmailAdd{EmailAddID = 4,Eadd = "daz@gmail.com"}
            };
            emailAdds.ForEach(s => context.EmailAdds.Add(s));
            context.SaveChanges();


        }
    }
}