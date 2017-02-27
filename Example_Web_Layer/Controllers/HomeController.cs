using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Example_Data_Layer;
using Example_Cross_Layer.Log;

namespace Example_Web_Layer.Controllers
{
    public class HomeController : Controller
    {
        private LogManagement  _log;
        public HomeController()
            : this(new EventLogManagment())
        { }

        public HomeController(LogManagement log)
        {
            _log = log;
        }

        public ActionResult Index()
        {
            try
            {
                var result = new List<Blog>();
                using (var db = new ExampleContext())
                {
                    return View(db.Blogs.ToList());
                }
            }
            catch (Exception ex)
            {
                _log.WriteLog(ex.Message);
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}