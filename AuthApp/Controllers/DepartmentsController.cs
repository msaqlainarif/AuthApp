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
    public class DepartmentsController : Controller
    {
        private BU_DB db = new BU_DB();

        // GET: Departments
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.CampusList=db.Campuses.ToList(); 
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department dept = new Department();
                dept.Name = model.Name;
                dept.DeptCode = model.DeptCode;
                dept.CampusId = model.CampusId;
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusList = db.Campuses.ToList();
            return View(model);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            DepartmentViewModel model;
            model = new DepartmentViewModel
            {
                Id = department.Id,
                Name = department.Name,
                DeptCode = department.DeptCode,
                CampusId = department.CampusId
            };
            ViewBag.CampusList = db.Campuses.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Department dept = new Department();
                dept.Id = model.Id;
                dept.Name = model.Name;
                dept.DeptCode = model.DeptCode;
                dept.CampusId = model.CampusId;
                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampusList = db.Campuses.ToList();
            return View(model);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
