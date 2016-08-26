using Day1Homework.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day1Homework.ViewModel
{
    public class AccountBookModel
    {
        [Required]
        public string ClassType{ get; set; }
        [Required]
        [DayRange]
        [Display(Name = "記帳日期")]
        public string AccountDate{ get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "「金額」只能輸入正整數")]
        public double BillingAmount{ get; set; }
        [Required]
        public string Note{ get; set; }
    }
}