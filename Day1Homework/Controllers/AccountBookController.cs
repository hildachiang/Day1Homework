using Day1Homework.MyEnum;
using Day1Homework.Repositories;
using Day1Homework.Service;
using Day1Homework.ViewModel;
using System;
using System.Web.Mvc;

namespace Day1Homework.Controllers
{
    public class AccountBookController : Controller
    {
        private readonly AccountBookService _accountBookSvc;
        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);
        }

        // GET: AccountBook
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChildAction()
        {
            var result = _accountBookSvc.Lookup();
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AjaxPost(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.AccountBookModel.ClassType = model.CategoryOptions.ToString();
                _accountBookSvc.Add(model.AccountBookModel);
                _accountBookSvc.Save();
                return RedirectToAction("ChildAction");
            }
            return View("ChildAction");
        }
    }

}