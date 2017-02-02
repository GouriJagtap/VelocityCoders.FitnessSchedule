using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelocityCoders.FitnessSchedule.Services.DataContracts
{
    [DataContract(Name ="EntityTypeDTO")]
    public class EntityTypeDTO
    {
        [DataMember]
        public int EntityId { get; set; }

        [DataMember]
        public int EntityTypeId { get; set; }

        [DataMember]
        public string EntityTypeName { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

    }
}