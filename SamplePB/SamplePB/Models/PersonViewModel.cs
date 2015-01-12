using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Antlr.Runtime.Misc;

namespace SamplePB.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            ContactNumbersViewModels = new List<ContactNumbersViewModel>();
            EmailsViewModels = new ListStack<EmailsViewModel>();
        }
        public int PersonId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string BirthDate { get; set; }
        public string HomeAddress { get; set; }
        public string Company { get; set; }
        public DataSet StoreAllData { get; set; }

        public List<ContactNumbersViewModel> ContactNumbersViewModels { get; set; }
        public List<EmailsViewModel> EmailsViewModels { get; set; }
    }
}