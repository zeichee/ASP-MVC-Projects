using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.DAL;

namespace WebApplication1.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDbContext db = new ContactDbContext();

        // GET: /Contacts/
        public ActionResult Index()
        {
            return View(db.PersonalInfos.ToList());
        }

        // GET: /Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalinfo = db.PersonalInfos.Find(id);
            if (personalinfo == null)
            {
                return HttpNotFound();
            }
            return View(personalinfo);
        }

        // GET: /Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,lastName,firstName,middleName,Birthdate,Address,Company")] PersonalInfo personalinfo)
        {
            try
            {

            
            if (ModelState.IsValid)
            {
                db.PersonalInfos.Add(personalinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to add contact. Try again, and if the problem persists see your system administrator.");
            }
            return View(personalinfo);
        }

        // GET: /Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalInfo personalinfo = db.PersonalInfos.Find(id);
            if (personalinfo == null)
            {
                return HttpNotFound();
            }
            return View(personalinfo);
        }

        // POST: /Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,lastName,firstName,middleName,Birthdate,Address,Company")] PersonalInfo personalinfo)
        {
            try
            {

            
            if (ModelState.IsValid)
            {
                db.Entry(personalinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            }
            catch (DataException)
            {

                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(personalinfo);
        }

        // GET: /Contacts/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. The contact you're trying to delete is not in the list anymore.";
            }
            PersonalInfo personalinfo = db.PersonalInfos.Find(id);
            if (personalinfo == null)
            {
                return HttpNotFound();
            }
            return View(personalinfo);
        }

        // POST: /Contacts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {

            
            PersonalInfo personalinfo = db.PersonalInfos.Find(id);
            db.PersonalInfos.Remove(personalinfo);
            db.SaveChanges();
            }
            catch (DataException)
            {

                return RedirectToAction("Delete", new{id=id, saveChangesError = true});
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
