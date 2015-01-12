using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SamplePB.DAL;
using SamplePB.Models;

namespace SamplePB.Controllers
{
    public class ContactsController : Controller
    {
        //
        // GET: /Contacts/
        //Show contact details
        public ActionResult ShowContactDetails(int id)
        {
            var objDb = new DatabaseOperations();

            DataSet ds = objDb.SelectById(id);
            var pModel = new PersonViewModel
            {
                PersonId = Convert.ToInt32(ds.Tables[0].Rows[0]["PersonID"].ToString()),
                LastName = ds.Tables[0].Rows[0]["LastName"].ToString(),
                FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString(),
                MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString(),
                BirthDate = ds.Tables[0].Rows[0]["BirthDate"].ToString(),
                HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString(),
                Company = ds.Tables[0].Rows[0]["Company"].ToString()

            };

            foreach (DataRow row in ds.Tables[1].Rows)
            {
                pModel.ContactNumbersViewModels.Add(
                    new ContactNumbersViewModel
                    {
                        ContactId = Convert.ToInt32(row["ID"]),
                        PersonId = Convert.ToInt32(row["PersonID"]),
                        SelectedContactType = row["SelectedContactType"].ToString(),
                        ContactNumber = row["ContactNumber"].ToString()
                        
                    });
            }
            foreach (DataRow row in ds.Tables[2].Rows)
            {
                pModel.EmailsViewModels.Add(
                    new EmailsViewModel
                    {
                        EmailId = Convert.ToInt32(row["ID"]),
                        PersonId = Convert.ToInt32(row["PersonID"]),
                        Emails = row["EmailAddress"].ToString()

                    });
            }

            

            return View(pModel);
        }


        public ActionResult InsertContactPerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertContactPerson(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var obj = new DatabaseOperations();
                string result = obj.InsertContactPerson(model);
                ViewData["result"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllContacts", "Contacts");

            }
            else
            {
                ModelState.AddModelError("","Error saving.");
                return View();
            }
        }

        public ActionResult ShowAllContacts(PersonViewModel model)
        {
            var obj = new DatabaseOperations();
            model.StoreAllData = obj.SelectAllContacts();

            return View(model);
        }

        public ActionResult EditContact(int id)
        {
            var objDB = new DatabaseOperations(); 

            DataSet ds = objDB.SelectById(id);

            var model = new PersonViewModel();

            model.PersonId = Convert.ToInt32(ds.Tables[0].Rows[0]["PersonID"].ToString());
            model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();

            model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();

            model.MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();

            model.BirthDate = ds.Tables[0].Rows[0]["BirthDate"].ToString();

            model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();

            model.Company = ds.Tables[0].Rows[0]["Company"].ToString();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditContact(PersonViewModel model)
        {
            var obj = new DatabaseOperations();
            string result = obj.UpdateContactPerson(model);
            ViewData["updateResult"] = result;
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteContact(int id)
        {
            var objDB = new DatabaseOperations();

            DataSet ds = objDB.SelectById(id);

            var model = new PersonViewModel();

            model.PersonId = Convert.ToInt32(ds.Tables[0].Rows[0]["PersonID"].ToString());
            model.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();

            model.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();

            model.MiddleName = ds.Tables[0].Rows[0]["MiddleName"].ToString();

            model.BirthDate = ds.Tables[0].Rows[0]["BirthDate"].ToString();

            model.HomeAddress = ds.Tables[0].Rows[0]["HomeAddress"].ToString();

            model.Company = ds.Tables[0].Rows[0]["Company"].ToString();

            return View(model);
        }

        public ActionResult DeleteContact(PersonViewModel model)
        {
            var obj = new DatabaseOperations();
            string result = obj.DeleteContact(model.PersonId);

            return RedirectToAction("ShowAllContacts", "Contacts");
        }

        [HttpGet]
        public ActionResult InsertPersonEmail(int id)
        {
            var objDB = new DatabaseOperations();

            DataSet ds = objDB.SelectById(id);

            var model = new EmailsViewModel();

            model.PersonId = Convert.ToInt32(ds.Tables[0].Rows[0]["PersonID"].ToString());

            return View(model);
        }

        public ActionResult InsertPersonEmail(EmailsViewModel eModel)
        {
            if (ModelState.IsValid)
            {
                var obj = new DatabaseOperations();
                string result = obj.AddEmails(eModel);
                ViewData["result"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllContacts", "Contacts");

            }
            else
            {
                ModelState.AddModelError("", "Error saving.");
                return View();
            }
        }

        [HttpGet]
        public ActionResult InsertPersonContactNumber(int id)
        {
            var objDB = new DatabaseOperations();

            DataSet ds = objDB.SelectById(id);

            var model = new ContactNumbersViewModel();

            model.PersonId = Convert.ToInt32(ds.Tables[0].Rows[0]["PersonID"].ToString());


            return View(model);
        }
        //private IEnumerable<SelectListItem> GetContactType()
        //{

        //    var contactTypes = new List<SelectListItem>();

        //    var mobile = new SelectListItem
        //    {
        //        Text = "Mobile",
        //        Value = "Mobile",

        //    };

        //    contactTypes.Add(mobile);
        //    var tel = new SelectListItem
        //    {
        //        Text = "Telephone",
        //        Value = "Telephone"
        //    };
        //    contactTypes.Add(tel);

        //    var home = new SelectListItem
        //    {
        //        Text = "Home",
        //        Value = "Home"
        //    };
        //    contactTypes.Add(home);

        //    var work = new SelectListItem
        //    {
        //        Text = "Work",
        //        Value = "Work"
        //    };
        //    contactTypes.Add(work);

        //    return (contactTypes);
        //}
        public ActionResult InsertPersonContactNumber(ContactNumbersViewModel cModel)
        {

            
            if (ModelState.IsValid)
            {
               
                var obj = new DatabaseOperations();
                string result = obj.AddContactNumbers(cModel);
                ViewData["result"] = result;
                ModelState.Clear();
                return RedirectToAction("ShowAllContacts", "Contacts");

            }
            else
            {
                ModelState.AddModelError("", "Error saving.");
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditContactNumber(int id)
        {
            var objDb = new DatabaseOperations();

            DataSet ds = objDb.SelectByContactId(id);

            var model = new ContactNumbersViewModel();

            model.ContactId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            model.SelectedContactType = ds.Tables[0].Rows[0]["SelectedContactType"].ToString();
            model.ContactNumber = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult EditContactNumber(ContactNumbersViewModel model)
        {
            var obj = new DatabaseOperations();
            obj.UpdateContactNumber(model);
            return RedirectToAction("ShowAllContacts", "Contacts");
        }

        [HttpGet]
        public ActionResult DeleteContactNumber(int id)
        {
            var objDb = new DatabaseOperations();

            var ds = objDb.SelectByContactId(id);

            var model = new ContactNumbersViewModel();

            model.ContactId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            model.SelectedContactType = ds.Tables[0].Rows[0]["SelectedContactType"].ToString();
            model.ContactNumber = ds.Tables[0].Rows[0]["ContactNumber"].ToString();
            return View(model);
        }

        public ActionResult DeleteContactNumber(ContactNumbersViewModel model)
        {
            var obj = new DatabaseOperations();
            obj.DeleteContactNumber(model.ContactId);

            return RedirectToAction("ShowAllContacts", "Contacts");
        }

        public ActionResult EditEmail(int id)
        {
            var objDb = new DatabaseOperations();

            DataSet ds = objDb.SelectByEmailId(id);

            var model = new EmailsViewModel();

            model.EmailId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            model.Emails = ds.Tables[0].Rows[0]["EmailAddress"].ToString();

      
            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmail(EmailsViewModel model)
        {
            var obj = new DatabaseOperations();
            string result = obj.UpdateEmail(model);
            ViewData["updateEmailResult"] = result;
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteEmail(int id)
        {
            var objDB = new DatabaseOperations();

            DataSet ds = objDB.SelectByEmailId(id);

            var model = new EmailsViewModel();

            model.EmailId = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"].ToString());
            model.Emails = ds.Tables[0].Rows[0]["EmailAddress"].ToString();
            return View(model);
        }

        public ActionResult DeleteEmail(EmailsViewModel model)
        {
            var obj = new DatabaseOperations();
            obj.DeleteEmail(model.EmailId);

            return RedirectToAction("ShowAllContacts", "Contacts");
        }

    }
}