using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Filters
{
    public class DayRangeAttribute : ValidationAttribute, IClientValidatable
    {
        public DayRangeAttribute()
        {
        }
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            DateTime compareDate;
            bool isDatetime = DateTime.TryParse(value.ToString(), out compareDate);
            if (isDatetime)
            {
                compareDate = compareDate.Date;
                return compareDate < DateTime.Now.Date;
            }
            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dayrange",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}