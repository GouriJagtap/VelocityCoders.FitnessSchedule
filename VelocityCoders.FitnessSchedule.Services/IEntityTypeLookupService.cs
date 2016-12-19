using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using VelocityCoders.FitnessSchedule.Services.DataContracts;
using VelocityCoders.FitnessSchedule.Services.Faults;

namespace VelocityCoders.FitnessSchedule.Services
{
    [ServiceContract]
    interface IEntityTypeLookupService
    {
        #region ENTITY


        [OperationContract]
        EntityDTOCollection GetEntityCollection();
        #endregion

        #region ENTITY TYPE

        [OperationContract]
        EntityTypeDTO GetEntityType(int entityTypeId);

        [OperationContract]
        EntityTypeDTOCollection getEntityTypeCollection(int entityId);

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void DeleteEntityType(int entityTypeId);

        [OperationContract]
        [FaultContract(typeof(EntityLookupServiceFault))]
        void SaveEntityType(EntityTypeDTO entityTypeToSave);
        #endregion

    }
}
