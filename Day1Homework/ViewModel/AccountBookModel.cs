using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Day1Homework.ViewModel
{
    public class AccountBookModel
    {
        public string ClassType{ get; set; }
        public string AccountDate{ get; set; }

        public double BillingAmount{ get; set; }
        public string Note{ get; set; }
    }
}