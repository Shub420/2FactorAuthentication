using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2factor.Models;

namespace WebApplication2factor.Controllers
{
    [RoutePrefix("Employees")]
    [Authorize(Roles = RolesName.canManageEmployee)]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController()
        {
            _context = new ApplicationDbContext();
        }
        [Route("")]
        // [OutputCache(Duration = 10, VaryByParam = "none")]
        //[Route("MVCTest")]
        public ActionResult Index()
        {
            var studentlist = _context.Employees.ToList();
            return View(studentlist);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        //[ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (employee == null)
                return HttpNotFound();
            if (!ModelState.IsValid)
                return View("Create");
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("{id}/Edit")]
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();
            var studentindb = _context.Employees.FirstOrDefault(m => m.Id == id);
            if (studentindb == null)
                return HttpNotFound();
            return View(studentindb);

        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee == null)
                return HttpNotFound();
            var empfromdb = _context.Employees.FirstOrDefault(u => u.Id == employee.Id);
            if (empfromdb == null || empfromdb.Id != employee.Id)
                return HttpNotFound();
            if (!ModelState.IsValid)
                return View("Edit");

            empfromdb.Name = employee.Name;
            empfromdb.Address = employee.Address;
            empfromdb.Salary = employee.Salary;
            
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
       
        public ActionResult Delete_Data(int id)
        {
            if (id == 0)
                return HttpNotFound();
            var Empindb = _context.Employees.FirstOrDefault(l => l.Id == id);
            if (Empindb == null)
                return HttpNotFound();
            _context.Employees.Remove(Empindb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Route("{id}/Details")]
        public ActionResult Details(int id )
        {
            var empInDb = _context.Employees.FirstOrDefault(i => i.Id == id);
            return View(empInDb);
        }

    }
}