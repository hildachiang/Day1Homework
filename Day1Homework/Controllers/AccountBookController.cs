using Day1Homework.Models;
using Day1Homework.Repositories;
using Day1Homework.Service;
using Day1Homework.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var categoryOptions = new List<SelectListItem>{
                        new SelectListItem { Text = "請選擇", Value="" },
                        new SelectListItem { Text = "支出", Value="支出" },
                        new SelectListItem { Text = "收入", Value="收入" }
                    };

            return View(new CreateViewModel { CategoryOptions = categoryOptions, AccountBookModel = new AccountBookModel() });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model)
        {
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