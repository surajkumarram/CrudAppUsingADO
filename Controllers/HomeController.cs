using CrudAppUsingADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppUsingADO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            EmployeDB db = new EmployeDB();
            List<EmployeeClass1> obj = db.getEmployee();
            return View(obj);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(EmployeeClass1 emp)
        {
            if (ModelState.IsValid == true)
            {
                EmployeDB db = new EmployeDB();
                bool check = db.AddEmployee(emp);
                if (check == true)
                {
                    TempData["Message"] = "Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            EmployeDB dbContext = new EmployeDB();
            var row = dbContext.getEmployee().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(int id, EmployeeClass1 emp)
        {

            if (ModelState.IsValid == true)
            {
                EmployeDB db = new EmployeDB();
                bool check = db.UpdateEmployee(emp);
                if (check == true)
                {
                    TempData["Message"] = "Successfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            EmployeDB dbContext = new EmployeDB();
            var row = dbContext.getEmployee().Find(model => model.id == id);
            return View(row);
        }
        [HttpPost]
        public ActionResult Delete(int id, EmployeeClass1 emp)
        {

            EmployeDB db = new EmployeDB();
            bool check = db.DeleteEmployee(id);
            if (check == true)
            {
                TempData["Message"] = "Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult dropdown()
        {
            List<string> emp = new List<string>();
            emp.Add("MERN");
            emp.Add("MEAN");
            emp.Add(".Net");
            emp.Add("Java");
            emp.Add("Python");
            ViewBag.List = emp;
            return RedirectToAction(ViewBag.List, "create");
        }
    }
}