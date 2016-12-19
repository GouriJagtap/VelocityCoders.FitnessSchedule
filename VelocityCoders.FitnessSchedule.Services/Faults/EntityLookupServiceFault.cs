using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelocityCoders.FitnessSchedule.Services.Faults
{
    [DataContract(Name = "EntityLookupServiceFault")]
    public class EntityLookupServiceFault
    {
        [DataMember]
        public string ErrorMrssage { get; set; }

        #region CONSTRUCTOR
        
        public EntityLookupServiceFault(string errorMessage)
        {
            this.ErrorMrssage = errorMessage;
        }
        #endregion
    }
}