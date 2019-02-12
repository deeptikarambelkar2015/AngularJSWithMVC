using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4.DataAccess;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        // GET: Employee/UpdateEmployee
        public ActionResult UpdateEmployee(string id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Employee/EmployeeDetails
        public ActionResult EmployeeDetails()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            try
            {
                DataAccess.EmployeeDA employeeDAO = new DataAccess.EmployeeDA();
                List<Employee> employees = employeeDAO.getEmployees();
                return Json(employees, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult GetEmployee(string id)
        {
            int employeeID;

            try
            {
                employeeID = int.Parse(id);
                DataAccess.EmployeeDA employeeDAO = new DataAccess.EmployeeDA();
                Employee employee = employeeDAO.getEmployeeDetails(employeeID);
                return Json(employee, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            DataAccess.EmployeeDA employeeDAO = new DataAccess.EmployeeDA();
            employeeDAO.AddEmployee(employee);
            return Json(new { });
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            DataAccess.EmployeeDA employeeDAO = new DataAccess.EmployeeDA();
            employeeDAO.UpdateEmployee(employee);
            return Json(new { });
        }

        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                DataAccess.EmployeeDA employeeDAO = new DataAccess.EmployeeDA();
                employeeDAO.DeleteEmployee(id);

                //Update the data in the Employee table
                List<Employee> employees = employeeDAO.getEmployees();
                return Json(employees);
            }
            catch
            {
                throw;
            }
        }
    }
}