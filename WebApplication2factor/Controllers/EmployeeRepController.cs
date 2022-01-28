using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2factor.Models;
using WebApplication2factor.Repository;
using WebApplication2factor.Repository.IRepository;

namespace WebApplication2factor.Controllers
{
    [RoutePrefix("EmployeesRep")]
    public class EmployeeRepController : Controller
    {
        private readonly IEmployeeRepository _repository;
        public EmployeeRepController()
        {
            _repository = new EmployeeRepository(new Models.ApplicationDbContext());
        }
        public EmployeeRepController(IEmployeeRepository employeeRepository)
        {
            _repository = employeeRepository;
        }

        [Route("")]
        // GET: EmployeeRep
        public ActionResult Index()
        {
            var studentlist = _repository.GetAll();
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
            _repository.Add(employee);
            _repository.Save();
            return RedirectToAction("Index");
        }
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();
            //var studentindb = _context.Employees.FirstOrDefault(m => m.Id == id);
            var studentindb = _repository.Get(id);
            if (studentindb == null)
                return HttpNotFound();
            return View(studentindb);
                
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (employee == null)
                return HttpNotFound();
            var empfromdb = _repository.Get(employee.Id);

            if (empfromdb == null || empfromdb.Id != employee.Id)
                return HttpNotFound();
            if (!ModelState.IsValid)
                return View("Edit");

            empfromdb.Name = employee.Name;
            empfromdb.Address = employee.Address;
            empfromdb.Salary = employee.Salary;

            _repository.Save();
            return RedirectToAction("Index");

        }
        
        public ActionResult Delete_Data(int id)
        {
            if (id == 0)
                return HttpNotFound();
            //var Empindb = _context.Employees.FirstOrDefault(l => l.Id == id);
            var Empindb = _repository.Get(id);
            if (Empindb == null)
                return HttpNotFound();
            _repository.Remove(Empindb);
            _repository.Save();
            return RedirectToAction("Index");
        }
    }
}