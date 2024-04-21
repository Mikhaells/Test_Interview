using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Models;
using Employee.Business;

namespace Employee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View("~/Views/Home/HomeView.cshtml");
        }
          


    }
}