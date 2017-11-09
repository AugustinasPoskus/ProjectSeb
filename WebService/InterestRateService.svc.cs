using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using WebService.Model;
using WebService.Repository.Implementations;
using WebService.Repository.Interfaces;
using static WebService.Model.ServiceModels;

namespace WebService
{
    public class InterestRateService : IInterestRateService
    {
        private ICustomerRepository customerRepository;
        private IAgreementRepository agreementRepository;

        public InterestRateService()
        {
            customerRepository = new CustomerRepository(new DatabaseContext());
            agreementRepository = new AgreementRepository(new DatabaseContext());
        }

        public int CreateAgreement(AgreementDTO agreement)
        {
            var customer = customerRepository.GetNameByPersonalId(agreement.PersonaId);
            if(customer == null)
            {
                return 0;
            }
            if (!Enum.GetNames(typeof(BaseRateCodeEnum)).Contains(agreement.Code))
            {
                return 0;
            }
            customer.Agreements.Add(new Agreement
            {
                Margin = agreement.Margin,
                Amount = agreement.Amount,
                Duration = agreement.Duration,
                BaseRateCode = agreement.Code,
            });
            customerRepository.UpdateCustomer(customer);
            return customerRepository.Save();
        }

        public int CreateCustomer(CustomerDTO customer)
        {
            if (customerRepository.GetNameByPersonalId(customer.PersonalId) == null)
            {
                customerRepository.InsertCustomer(new Customer
                {
                    PersonalId = customer.PersonalId,
                    Name = customer.Name
                });
                return customerRepository.Save();
            }
            return 0;  
        }

        public CustomerDetailsModel GetAgreements(int customerId)
        {
            Customer customer = customerRepository.GetNameByPersonalId(customerId);
            if (customer == null)
            {
                return null;
            }

            var ab = new CustomerDetailsModel()
            {
                Name = customer.Name,
                Id = customer.PersonalId,
                Agreements = customer.Agreements.Select(t => new AgreementDTO
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Margin = t.Margin,
                    Duration = t.Duration,
                    Code = t.BaseRateCode,
                    PersonaId = t.CustomerId
                }).ToList()
            };
            return ab;
        }

        public InterestRates GetCalculatedInterestRates(AgreementForRate agreement)
        {
            var agreementObj = agreementRepository.GetAgreement(agreement.AgreementId);
            if(agreementObj == null)
            {
                return null;
            }
            decimal NewValue = GetLatesBaseRateValue(agreement.Code);
            if (NewValue == -1)
            {
                return null;
            }
            decimal OldValue = GetLatesBaseRateValue(agreementObj.BaseRateCode);
            if (OldValue == -1)
            {
                return null;
            }
            return new InterestRates
            {
                FirstRate = OldValue + agreementObj.Margin,
                SecondRate = NewValue + agreementObj.Margin
            };
        }

        private decimal GetLatesBaseRateValue(string baseCode)
        {
            WebRequest request = WebRequest.Create("http://old.lb.lt/webservices/VilibidVilibor/VilibidVilibor.asmx/getLatestVilibRate?RateType=" + baseCode);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            decimal result;
            using (var reader = new StreamReader(dataStream))
            {
                var doc = new XmlDocument();
                doc.LoadXml(reader.ReadToEnd());
                XmlNodeList elemList = doc.GetElementsByTagName("decimal");
                result = decimal.Parse(elemList[0].InnerXml);
            }
            return result;
        }
    }
}
