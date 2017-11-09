namespace WebService.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Runtime.Serialization;

    public partial class Agreement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}
