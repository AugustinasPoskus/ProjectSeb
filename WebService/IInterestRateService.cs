using System.ServiceModel;
using static WebService.Model.ServiceModels;

namespace WebService
{
    [ServiceContract]
    public interface IInterestRateService
    {

        [OperationContract]
        CustomerDetailsModel GetAgreements(int customerId);

        [OperationContract]
        InterestRates GetCalculatedInterestRates(AgreementForRate agreement);

        [OperationContract]
        int CreateCustomer(CustomerDTO customer);

        [OperationContract]
        int CreateAgreement(AgreementDTO agreement);
    }
}
