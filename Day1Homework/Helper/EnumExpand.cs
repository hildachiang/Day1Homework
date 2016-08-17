using Day1Homework.MyEnum;
using System;
using System.ComponentModel.DataAnnotations;
namespace Day1Homework.Helper
{
    public static class EnumExpand
    {
        /// <summary>
        /// 取得CategoryEnum的display name
        /// </summary>
        /// <param name="myEnum">欲取得display name的Enum</param>
        /// <returns></returns>
        public static string GetDisplayName(this Enum myEnum)
        {
            var member = (myEnum.GetType().GetMember(myEnum.ToString()))[0];
            var attribute = (DisplayAttribute)(member.GetCustomAttributes(typeof(DisplayAttribute), false))[0];
            return attribute.GetName();
        }
    }
}