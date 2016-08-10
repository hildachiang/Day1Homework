using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Data.Objects.SqlClient;
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
            return source.AsEnumerable().Select(d => new AccountBookModel()
            {
                AccountDate = d.Dateee.ToString("yyyy/MM/dd"),
                BillingAmount = d.Amounttt,
                ClassType = d.Categoryyy.ToString(),
                Note = d.Remarkkk
            }
            ).ToList();

        }


        public void Add(AccountBookModel accountBook)
        {
            Add(new AccountBook()
            {
                Amounttt = (Int32)accountBook.BillingAmount,
                Categoryyy = Int32.Parse(accountBook.ClassType),
                Dateee = DateTime.Parse(accountBook.AccountDate),
                Remarkkk = accountBook.Note
            });
        }

        public void Add(AccountBook accountBook)
        {
            _accountRep.Create(new AccountBook()
            {
                Id = Guid.NewGuid(),
                Amounttt = accountBook.Amounttt,
                Categoryyy = accountBook.Categoryyy,
                Dateee = accountBook.Dateee,
                Remarkkk = accountBook.Remarkkk
            });
        }

        public void Save()
        {
            _accountRep.Commit();
        }
    }
}