using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day1Homework.Filters
{
    public class ExtMaxLengthAttribute : ValidationAttribute, IClientValidatable
    {
        private int maxStringLen;
        public ExtMaxLengthAttribute(int maxLen)
        {
            this.maxStringLen = maxLen;
        }
        public override bool IsValid(object value)
        {
            string result = value.ToString().Replace("\r\n", "");
            return result.Length <= maxStringLen;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "extmaxlength",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            yield return rule;
        }
    }
}