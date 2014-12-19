using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDbContext _db = new ContactDbContext();

        // GET: /Contacts/
        public ActionResult Index(string search)
        {
            var contact = from m in _db.Contacts
                          select m;
            if (!String.IsNullOrEmpty(search))
            {
                contact = contact.Where(c => c.name.Contains(search));
            }
            return View(contact);
        }

        // GET: /Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = _db.Contacts.Find(id);
            contactViewModel.ContactTypes = GetContactType();
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }
        private IEnumerable<SelectListItem> GetContactType()
        {

            var contactTypes = new List<SelectListItem>();

            var mobile = new SelectListItem
            {
                Text = "Mobile",
                Value = "Mobile",

            };

            contactTypes.Add(mobile);
            var tel = new SelectListItem
            {
                Text = "Telephone",
                Value = "Telephone"
            };
            contactTypes.Add(tel);

            var home = new SelectListItem
            {
                Text = "Home",
                Value = "Home"
            };
            contactTypes.Add(home);

            var work = new SelectListItem
            {
                Text = "Work",
                Value = "Work"
            };
            contactTypes.Add(work);

            return (contactTypes);
        }
        // GET: /Contacts/Create
        public ActionResult Create()
        {
            var model = new ContactViewModel();
            model.ContactTypes = GetContactType();
            return View(model);
        }

        // POST: /Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,name,SelectedContactType,mobile,Eadd")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Contacts.Add(contactViewModel);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactViewModel);
        }

        // GET: /Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = _db.Contacts.Find(id);
            contactViewModel.ContactTypes = GetContactType();
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }

        // POST: /Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,name,SelectedContactType,mobile,Eadd")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(contactViewModel).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactViewModel);
        }

        // GET: /Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactViewModel contactViewModel = _db.Contacts.Find(id);
            if (contactViewModel == null)
            {
                return HttpNotFound();
            }
            return View(contactViewModel);
        }

        // POST: /Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactViewModel contactViewModel = _db.Contacts.Find(id);
            _db.Contacts.Remove(contactViewModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
