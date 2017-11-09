using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SebProject.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Agreements = new HashSet<Agreement>();
        }

        public int Id { get; set; }
        public int PersonalId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Agreement> Agreements { get; set; }
    }

    public class CustomerRegistrationViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }

    public class CustomerAuthentificationViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public int Id { get; set; }

    }
    public class CustomerDetailsModel
    {
        public CustomerDetailsModel(string code)
        {
            SelectedBaseCode = code;
        }

        public CustomerDetailsModel() { }

        public string Name { get; set; }
        public int Id { get; set; }
        public int SelectedAgreementId { get; set; }
        public string SelectedBaseCode { get; set; }

        public List<Agreement> Agreements { get; set; }

        public string DisplayValue
        {
            get
            {
                return this.Name + ", personal id " + this.Id + " has " + this.Agreements.Count + " agreements:";
            }
            private set { }
        }
    }
}