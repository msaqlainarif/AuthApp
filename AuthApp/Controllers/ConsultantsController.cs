using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthApp.DBFramework;
using AuthApp.Models;

namespace AuthApp.Controllers
{
    public class ConsultantsController : Controller
    {
        private BU_DB db = new BU_DB();

        // GET: Consultants
        public ActionResult Index()
        {
            return View(db.Consultants.ToList());
        }

       
        // GET: Consultants/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConsultantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Consultant consul = new Consultant();
                consul.Name = model.Name;
                consul.Phone = model.Phone;
                consul.Email = model.Email;
                consul.Address = model.Address;
                consul.DeptId = model.DeptId;
                consul.Status = model.Status;
                db.Consultants.Add(consul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
          
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View(model);
        }

        // GET: Consultants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = db.Consultants.Find(id);
            if (consultant == null)
            {
                return HttpNotFound();
            }
            ConsultantViewModel model;
            model = new ConsultantViewModel
            {
                Id = consultant.Id,
                Name = consultant.Name,
                Phone = consultant.Phone,
                Email= consultant.Email,
                Address= consultant.Address,
                DeptId= consultant.DeptId,
                Status= consultant.Status
            };
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ConsultantViewModel model)
        {
            if (ModelState.IsValid)
            {
                Consultant consul = new Consultant();
                consul.Id = model.Id;
                consul.Name = model.Name;
                consul.Phone = model.Phone;
                consul.Email = model.Email;
                consul.Address = model.Address;
                consul.DeptId = model.DeptId;
                consul.Status = model.Status;
                db.Entry(consul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View(model);
        }
        
        // GET: Consultants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultant consultant = db.Consultants.Find(id);
            db.Consultants.Remove(consultant);
            db.SaveChanges();
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
