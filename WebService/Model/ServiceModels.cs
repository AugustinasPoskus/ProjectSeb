using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebService.Model
{
    public class ServiceModels
    {
        [DataContract]
        public class CustomerDTO
        {
            [DataMember]
            public int PersonalId { get; set; }
            [DataMember]
            public string Name { get; set; }
        }

        [DataContract]
        public class CustomerDetailsModel
        {
            [DataMember]
            public string Name { get; set; }
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public List<AgreementDTO> Agreements { get; set; }
        }

        [DataContract]
        public class InterestRates
        {
            [DataMember]
            public decimal FirstRate { get; set; }
            [DataMember]
            public decimal SecondRate { get; set; }
        }

        [DataContract]
        public class AgreementForRate
        {
            [DataMember]
            public string Code { get; set; }
            [DataMember]
            public int AgreementId { get; set; }
        }

        [DataContract]
        public class AgreementDTO
        {
            [DataMember]
            public int Id { get; set; }
            [DataMember]
            public int PersonaId { get; set; }
            [DataMember]
            public int Duration { get; set; }
            [DataMember]
            public string Code { get; set; }
            [DataMember]
            public decimal Amount { get; set; }
            [DataMember]
            public decimal Margin { get; set; }
        }
    }
}