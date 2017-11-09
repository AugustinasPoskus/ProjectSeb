using System.Collections.Generic;
using WebService.Model;

namespace WebService.Repository.Interfaces
{
    interface IAgreementRepository
    {
        Agreement GetAgreement(int id);
    }
}
