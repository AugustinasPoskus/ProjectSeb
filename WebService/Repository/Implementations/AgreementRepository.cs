using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Model;
using WebService.Repository.Interfaces;

namespace WebService.Repository.Implementations
{
    public class AgreementRepository : IAgreementRepository
    {

        private DatabaseContext context;

        public AgreementRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Agreement GetAgreement(int id)
        {
            return context.Agreements.Find(id);
        }
    }
}