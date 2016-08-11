using Day1Homework.Enum;
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
            return View(_accountBookSvc.Lookup());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
            //新增仍有問題，抓不到enum塞的dropdownlist
            if (ModelState.IsValid)
            {                
                _accountBookSvc.Add(model.AccountBookModel);
                _accountBookSvc.Save();

                return RedirectToAction("Index");
            }
            return View(model);
        }

    }

}