using System.Threading.Tasks;
using System.Web.Mvc;
using SebProject.Models;
using SebProject.InterestRateService;

namespace SebProject.Controllers
{
    public class CustomerController : Controller
    {
        private InterestRateServiceClient service;

        public CustomerController()
        {
            service = new InterestRateServiceClient();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(CustomerRegistrationViewModel model)
        {
            var customer = new ServiceModelsCustomerDTO()
            {
                PersonalId = model.Id,
                Name = model.Name
            };
            if (service.CreateCustomer(customer) != 0)
            {
                return View("SuccessfulRegistration");
            }
            else
            {
                return View("Error");
            }
        }

        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

    }
}