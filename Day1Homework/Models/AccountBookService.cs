using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Day1Homework.Models;
using Day1Homework.Repositories;
using Day1Homework.ViewModel;

namespace Day1Homework.Service 
{
    public class AccountBookService : Repository<AccountBook>
    {
        private readonly IRepository<AccountBook> _accountRep;

        public AccountBookService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _accountRep = new Repository<AccountBook>(unitOfWork);
        }

        public IEnumerable<AccountBookModel> Lookup()
        {
            var source = _accountRep.LookupAll();
            var result = source.Select(ab => new AccountBookModel()
            {
                AccountDate = ab.Dateee.ToString("yyyy/MM/dd"),
                BillingAmount = ab.Amounttt,
                ClassType = ab.Categoryyy.ToString(),
                Note = ab.Remarkkk
            }).ToList();
            return result;
        }


        public void Add(AccountBookModel accountBook)
        {
            var result = new AccountBook()
            {
                Amounttt = (Int32)accountBook.BillingAmount,
                Categoryyy = Int32.Parse(accountBook.ClassType),
                Dateee = DateTime.Parse(accountBook.AccountDate),
                Remarkkk = accountBook.Note
            };
            Add(result);
        }

        public void Add(AccountBook accountBook)
        {
            var newAccountBook = new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = accountBook.Amounttt,
                Categoryyy = accountBook.Categoryyy,
                Dateee = accountBook.Dateee,
                Remarkkk = accountBook.Remarkkk
            };
            _accountRep.Create(newAccountBook);
        }

        public void Save()
        {
            _accountRep.Commit();
        }
    }
}