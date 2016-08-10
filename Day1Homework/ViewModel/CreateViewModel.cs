using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
namespace Day1Homework.ViewModel
{
   public class CreateViewModel
    {
        public AccountBookModel AccountBookModel { get; set; }
        public List<SelectListItem> CategoryOptions { get; set; }
    }
}