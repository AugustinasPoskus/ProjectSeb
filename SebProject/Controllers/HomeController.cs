using SebProject.InterestRateService;
using SebProject.Models;
using System.Linq;
using System.Web.Mvc;

namespace SebProject.Controllers
{
    public class HomeController : Controller
    {
        private InterestRateServiceClient service;

        public HomeController()
        {
            service = new InterestRateServiceClient();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchAgreement()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SearchAgreement(AgreementSearchModel model)
        {

            var customer = service.GetAgreements(model.PersonalId);

            if (customer == null)
            {
                return PartialView("_PartialAgreements", null);
            }

            var ab = new Models.CustomerDetailsModel(model.BaseRateCode.ToString())
            {
                Name = customer.Name,
                Id = customer.Id,
                Agreements = customer.Agreements.Select(t => new Models.Agreement
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Margin = t.Margin,
                    BaseRateCode = t.Code,
                    Duration = t.Duration
                }).ToList()
            };
            return PartialView("_PartialAgreements", ab);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateAgreement(AgreementModel model)
        {
            ServiceModelsAgreementDTO agreement = new ServiceModelsAgreementDTO
            {
                PersonaId = model.PersonalId,
                Amount = model.Amount,
                Margin = model.Margin,
                Duration = model.Duration,
                Code = model.BaseRateCode.ToString()
            };
            if (service.CreateAgreement(agreement) == 0)
            {
                return View("Error");
            }
            return View("SuccessfulSubmit");
        }

        public ActionResult CreateAgreement()
        {
            return View();
        }

        public ActionResult CalculateInterestRate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateInterestRate(Models.CustomerDetailsModel model)
        {
            if(model.SelectedAgreementId == 0)
            {
                return View();
            }
            var rates = service.GetCalculatedInterestRates(new ServiceModelsAgreementForRate
            {
                Code = model.SelectedBaseCode,
                AgreementId = model.SelectedAgreementId
            });

            return PartialView("_RatesResults", new InterestRatesModel()
            {
                OldInterestRate = rates.FirstRate,
                NewInterestRate = rates.SecondRate
            });
        }
    }
}