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
    public class ContractorsController : Controller
    {
        private BU_DB db = new BU_DB();

        // GET: Contractors
        public ActionResult Index()
        {
            return View(db.Contractors.ToList());
        }

       
        // GET: Contractors/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contractor cont = new Contractor();
                cont.Name = model.Name;
                cont.Phone = model.Phone;
                cont.Email = model.Email;
                cont.Address = model.Address;
                cont.DeptId = model.DeptId;
                cont.Status = model.Status;
                db.Contractors.Add(cont);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View(model);
        }

        // GET: Contractors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = db.Contractors.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            ContractorViewModel model;
            model = new ContractorViewModel
            {
                Id = contractor.Id,
                Name = contractor.Name,
                Phone = contractor.Phone,
                Email = contractor.Email,
                Address = contractor.Address,
                DeptId = contractor.DeptId,
                Status = contractor.Status
            };
            ViewBag.DepartmentsList = db.Departments.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContractorViewModel model)
        {
            if (ModelState.IsValid)
            {
                Contractor consul = new Contractor();
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

      
        // Get: Contractors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contractor contractor = db.Contractors.Find(id);
            if (contractor == null)
            {
                return HttpNotFound();
            }
            db.Contractors.Remove(contractor);
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
