using System.ComponentModel.DataAnnotations;
namespace Day1Homework.Enum
{
    public enum CategoryEnum
    {
        [Display(Name = "支出")]
        Expenditure,
        [Display(Name = "收入")]
        Income
    }
}