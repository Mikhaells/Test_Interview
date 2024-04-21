using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace Employee.Controllers.Employee
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            //populate employee
            List<Models.EmployeeModel> EmployeeList = new List<Models.EmployeeModel>();
            Business.Employee em = new Business.Employee();
            EmployeeList = em.GetEmployeesBySP().OrderBy(col => col.Id).ToList();

            //populate position
            List<Models.Positon> _pos = new List<Models.Positon>();
            _pos = em.GetPosition();

            //populate department
            List<Models.Department> _dept = new List<Models.Department>();
            _dept = em.GetDepartment();

            //populate allowance
            List<Models.Allowance> _allowance = new List<Models.Allowance>();
            _allowance = em.GetAllowance();


            ViewBag.Positions = _pos.Select(e => new System.Web.Mvc.SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();
            ViewBag.Departments = _dept.Select(e => new System.Web.Mvc.SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name
            }).ToList();

            ViewBag.Allowances = _allowance;


            return View("~/Views/Employee/EmployeeView.cshtml", EmployeeList);
        }

        public JsonResult GetEmployeeDetailById(int Id)
        {
            try
            {
                Models.EmployeeModel Employee = new Models.EmployeeModel();
                Business.Employee em = new Business.Employee();
                Employee = em.GetEmployeesById(Id);
                List<Models.Employee_AllowanceModel> employee_AllowanceModel = new List<Models.Employee_AllowanceModel>();
                employee_AllowanceModel = em.GetAllowanceDetailById(Id);
                return Json(new { flag = true, EmployeeDetail = Employee, AllowanceDetail = employee_AllowanceModel }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
                _res.flag = false;
                _res.message = "error when Populate Department and Position";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDepartmentPosition()
        {
            try
            {
                Business.Employee em = new Business.Employee();
                List<Models.Positon> _pos = new List<Models.Positon>();
                _pos = em.GetPosition();
                List<Models.Department> _dept = new List<Models.Department>();
                _dept = em.GetDepartment();

                return Json(new { flag = true, Position = _pos, Department = _dept }, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
                _res.flag = false;
                _res.message = "error when Populate Department and Position";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult InsertEmployee(string NIK, string NAME, int DepartmentId, int PositionId, string Allowance)
        {
            Business.Employee em = new Business.Employee();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            {
                Models.Employees employees = new Models.Employees();
                employees.NIK = NIK;
                employees.Name = NAME;
                employees.DepartmentId = DepartmentId;
                employees.PositionId = PositionId;
                _res = em.InsertEmployeeData(employees, Allowance);
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "Employee")
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _res.flag = false;
                _res.message = "Error insert Employee";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);

            }
        }
        public JsonResult UpdateEmployee(string NIK, string NAME, int DepartmentId, int PositionId, string Allowance)
        {
            Business.Employee em = new Business.Employee();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            {
                Models.Employees employees = new Models.Employees();
                employees.NIK = NIK;
                employees.Name = NAME;
                employees.DepartmentId = DepartmentId;
                employees.PositionId = PositionId;
                _res = em.UpdateEmployeeData(employees, Allowance);
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "Employee")
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _res.flag = false;
                _res.message = "Error Update Employee";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);

            } 
        }
        public JsonResult DeleteEmployee(int Id)
        {
            Business.Employee em = new Business.Employee();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            { 
                _res = em.DeleteEmployeeData(Id);
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "Employee")
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _res.flag = false;
                _res.message = "Error Delete Employee";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);

            }
        }

    }
}