using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelocityCoders.FitnessSchedule.Services.DataContracts
{
    [DataContract(Name ="EntityDTO")]
    public class EntityDTO
    {
        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public string EntityName { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

    }
}