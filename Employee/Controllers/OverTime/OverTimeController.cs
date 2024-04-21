using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class OverTimeController : Controller
    {
        // GET: OverTime
        public ActionResult Index()
        {

            Business.Overtime ot = new Business.Overtime();
            List<Models.Overtime> _OtList = new List<Models.Overtime>();
            _OtList = ot.GetOvertime();


            Business.Employee em = new Business.Employee(); 
            ViewBag.employees = em.GetEmployees().Select(e => new System.Web.Mvc.SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.NIK
            }).ToList(); 

            return View("~/Views/OverTime/OverTimeView.cshtml", _OtList);
        }

        public JsonResult InsertOverTime(string NIK,DateTime StartDate,DateTime FinishDate)
        {
            Business.Overtime ot = new Business.Overtime();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            { 
                TimeSpan difference = FinishDate.Subtract(StartDate);
                _res = ot.InserOvertime(NIK, StartDate, FinishDate, Convert.ToInt32(difference.TotalHours));
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "OverTime")
                }, JsonRequestBehavior.AllowGet); 
            }
            catch(Exception ex) 
            {
                _res.flag = false;
                _res.message = "Error Insert Overtime";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }
           
        }

        public JsonResult UpdateOverTime(string NIK, DateTime StartDate, DateTime FinishDate)
        {
            Business.Overtime ot = new Business.Overtime();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            {
                TimeSpan difference = FinishDate.Subtract(StartDate);
                _res = ot.UpdateOvertime(NIK, StartDate, FinishDate, Convert.ToInt32(difference.TotalHours));
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "OverTime")
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _res.flag = false;
                _res.message = "Error Update OverTime";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult DeleteOverTime(string NIK)
        {
            Business.Overtime ot = new Business.Overtime();
            Models.GeneralReturnModel _res = new Models.GeneralReturnModel();
            try
            { 
                _res = ot.DeleteOvertime(NIK);
                return Json(new
                {
                    flag = _res.flag,
                    message = _res.message,
                    message_info = _res.message_info,
                    redirectUrl = Url.Action("Index", "OverTime")
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _res.flag = false;
                _res.message = "Error Delete Overtime";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult GetOvertimeByNIK(string NIK)
        {

            Models.GeneralReturnModel _res = new Models.GeneralReturnModel(); 
            Business.Overtime ot = new Business.Overtime();
            Models.Overtime _Ot = new Models.Overtime();
            try
            {
                _Ot = ot.GetOvertime().Where(col => col.NIK == NIK ).FirstOrDefault();
                return Json(new
                {
                    flag = true, 
                    data = _Ot
                }, JsonRequestBehavior.AllowGet);

            }
            catch( Exception ex ) 
            {
                _res.flag = false;
                _res.message = "Error GetOverTime by NIK";
                _res.message_info = ex.Message;
                return Json(_res, JsonRequestBehavior.AllowGet);
            }
             
        }


    }
}