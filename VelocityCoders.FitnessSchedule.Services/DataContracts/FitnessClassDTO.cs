using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Web;

namespace VelocityCoders.FitnessSchedule.Services.DataContracts
{
    [DataContract(Name ="FitnessClassDTO")]
    public class FitnessClassDTO
    {
        [DataMember]
        public int FitnessClassId { get; set; }

        [DataMember]
        public string FitnessClassName { get; set; }

      

    }
}