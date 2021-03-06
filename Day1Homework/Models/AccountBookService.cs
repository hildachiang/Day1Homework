﻿using System;
using System.Collections.Generic;
using System.Linq;

using Day1Homework.Models;
using Day1Homework.Repositories;
using Day1Homework.ViewModel;
using Day1Homework.MyEnum;
using Day1Homework.Helper;
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
            CategoryEnum myEnum;
            var source = _accountRep.LookupAll();
            return source.OrderByDescending(d => d.Dateee).AsEnumerable().Select(d => new AccountBookModel()
            {
                AccountDate = d.Dateee.ToString("yyyy-MM-dd"),
                BillingAmount = d.Amounttt,
                ClassType = Enum.TryParse(d.Categoryyy.ToString(), out myEnum) ? myEnum.GetDisplayName() : "N/A",
                Note = d.Remarkkk
            }).ToList();
        }

        public void Add(AccountBookModel accountBook)
        {
            Add(new AccountBook()
            {
                Amounttt = (int)accountBook.BillingAmount,
                Categoryyy = (int)GetEnumValue(accountBook.ClassType),
                Dateee = DateTime.Parse(accountBook.AccountDate),
                Remarkkk = accountBook.Note
            });
        }

        private CategoryEnum GetEnumValue(string category)
        {
            CategoryEnum myEnum;
            if (Enum.TryParse(category, out myEnum))
                return myEnum;
            else
                throw new Exception("未預期的enum值");
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