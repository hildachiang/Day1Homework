using Day1Homework.MyEnum;
using System;
using System.ComponentModel.DataAnnotations;
namespace Day1Homework.Helper
{
    public static class EnumExpand
    {
        public static string GetDisplayName(this CategoryEnum myEnum)
        {
            var member = (myEnum.GetType().GetMember(myEnum.ToString()))[0];
            var attribute = (DisplayAttribute)(member.GetCustomAttributes(typeof(DisplayAttribute), false))[0];
            return attribute.GetName();
        }

        public static string GetDisplayName(this CategoryEnum myEnum, int category)
        {
            CategoryEnum myCategoryEnum;
            if (Enum.TryParse(category.ToString(), true, out myCategoryEnum))
            {
                return GetDisplayName(myCategoryEnum);
            }
            else
                return "N/A";
        }
    }
}