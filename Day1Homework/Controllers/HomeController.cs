using Day1Homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChildAction()
        {
            var model = new List<AccountBookModel>();
            model.Add(new AccountBookModel() { ClassType = "支出", AccountDate = "2016-01-01", BillingAmount = 300 });
            model.Add(new AccountBookModel() { ClassType = "支出", AccountDate = "2016-01-02", BillingAmount = 1600 });
            model.Add(new AccountBookModel() { ClassType = "支出", AccountDate = "2016-01-03", BillingAmount = 800 });

            return View(model);
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