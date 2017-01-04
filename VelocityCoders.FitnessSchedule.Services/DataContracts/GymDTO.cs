using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelocityCoders.FitnessSchedule.Services.DataContracts
{
    [DataContract(Name ="GymDTO")]
    public class GymDTO
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string WebSite { get; set; }

        //[DataMember]
        //public DateTime CreateDate { get; set; }
    }
}