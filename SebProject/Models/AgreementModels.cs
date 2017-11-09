using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SebProject.Models
{
    public partial class Agreement
    {
        public int Id { get; set; }
        public decimal Margin { get; set; }
        public decimal Amount { get; set; }
        public int CustomerId { get; set; }
        public string BaseRateCode
        {
            get { return BaseRateCodeEnumValue.ToString(); }
            set
            {
                BaseRateCodeEnum newValue;
                if (Enum.TryParse(value, out newValue))
                { BaseRateCodeEnumValue = newValue; }
            }
        }
        public BaseRateCodeEnum BaseRateCodeEnumValue { get; set; }
        public int Duration { get; set; }

        public virtual Customer Customer { get; set; }
    }

    public enum BaseRateCodeEnum
    {
        [Display(Name = "VILIBOR1m")]
        VILIBOR1m,
        [Display(Name = "VILIBOR3m")]
        VILIBOR3m,
        [Display(Name = "VILIBOR6m")]
        VILIBOR6m,
        [Display(Name = "VILIBOR1y")]
        VILIBOR1y
    }

    public class AgreementModel
    {
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Personal id must me a whole number!")]
        [Display(Name = "Personal id")]
        public int PersonalId { get; set; }

        public int CustomerName { get; set; }

        [Required]
        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Margin")]
        public decimal Margin { get; set; }

        [Required]
        [Display(Name = "Base rate code")]
        public BaseRateCodeEnum BaseRateCode { get; set; }

        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Duration must me a whole number!")]
        [Display(Name = "Duration in months")]
        public int Duration { get; set; }
    }

    public class AgreementSearchModel
    {
        [Required]
        [RegularExpression(@"^\d+$", ErrorMessage = "Personal id must me a whole number!")]
        [Display(Name = "Personal id")]
        public int PersonalId { get; set; }

        [Required]
        [Display(Name = "Base rate code")]
        public BaseRateCodeEnum BaseRateCode { get; set; }

    }

    public class InterestRatesModel
    {
        public decimal OldInterestRate { get; set; }
        public decimal NewInterestRate { get; set; }
    }
}