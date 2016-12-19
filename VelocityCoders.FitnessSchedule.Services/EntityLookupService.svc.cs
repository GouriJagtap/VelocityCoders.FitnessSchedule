using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using VelocityCoders.FitnessSchedule.Services.DataContracts;
using VelocityCoders.FitnessSchedule.Services.Faults;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EntityLookupService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EntityLookupService.svc or EntityLookupService.svc.cs at the Solution Explorer and start debugging.
    public class EntityLookupService : IEntityTypeLookupService
    {
        #region GET

        public EntityDTOCollection GetEntityCollection()
        {
            EntityCollection entityCollection = EntityManager.GetCollection();
            return HydrateEntityDTO(entityCollection);
        }

        public EntityTypeDTO GetEntityType(int entityTypeId)
        {
            EntityType entityType = EntityTypeManager.GetItem(entityTypeId);
            return HydrateEntityTypeDTO(entityType);
        }

        public EntityTypeDTOCollection GetEntityTypeCollection(int entityId)
        {
            EntityTypeCollection entityTypeCollection = EntityTypeManager.GetCollection(entityId);
            return HydrateEntityTypeDTO(entityTypeCollection);
        }
        

        #endregion

        #region SAVE and DELETE

        public void DeleteEntityType(int entityTypeId)
        {
            if (entityTypeId > 0)
            {
                try
                {
                    if (!EntityTypeManager.Delete(entityTypeId))
                        throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault("No records were affected"), "Delete failed");
                }
                catch (BLLException ex)
                {
                    throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault(ex.Message), "Validation failed");
                }
            }
            else
                throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault("Entity TypeId was not valid"), "validation failed");
        }

        public void SaveEntityType(EntityTypeDTO entityTypeToSave)
        {
            if (entityTypeToSave != null)
            {
                if (entityTypeToSave.EntityId > 0)
                {
                    if (string.IsNullOrEmpty(entityTypeToSave.EntityTypeName))
                        throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault("EntityType value is required"), "Validation Failed");
                    else
                    {
                        try
                        {
                            EntityTypeManager.Save(entityTypeToSave.EntityId, HydrateEntityType(entityTypeToSave));
                        }
                        catch (BLLException ex)
                        {
                            throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault(ex.Message), "Save Failed");
                        }
                    }
                }
                else
                    throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault("Entity Id is required"), "Validation Failed");

            }
            else
                throw new FaultException<EntityLookupServiceFault>(new EntityLookupServiceFault("EntityType object was invalid"), "Validation Failed");
        }

        #endregion

        #region HYDRATE OBJECTS

        private EntityDTOCollection HydrateEntityDTO(EntityCollection entityCollection)
        {
            EntityDTOCollection tempCollection = new EntityDTOCollection();

            if(entityCollection != null && entityCollection.Count >0)
            {
                foreach(Entity item in entityCollection)
                {
                    if (!string.IsNullOrEmpty(item.EntityName))
                    {
                        EntityDTO temp = new EntityDTO() { EntityId = item.EntityId, EntityName = item.EntityName };

                        if (!string.IsNullOrEmpty(item.DisplayName))
                            temp.DisplayName = item.DisplayName;

                        tempCollection.Add(temp);
                    }
                    else
                        tempCollection.Add(new EntityDTO { EntityId = item.EntityId });
                }
            }
            return tempCollection;
        }

        private EntityTypeDTO HydrateEntityTypeDTO(EntityType entityType)
        {
            EntityTypeDTO tempItem = new EntityTypeDTO();

            if(entityType !=null)
            {
                tempItem.EntityTypeId = entityType.EntityTypeId;

                if (!string.IsNullOrEmpty(entityType.EntityTypeName))
                    tempItem.EntityTypeName = entityType.EntityTypeName;

                if (!string.IsNullOrEmpty(entityType.DisplayName))
                    tempItem.DisplayName = entityType.DisplayName;
            }
            return tempItem;
        }

        private EntityTypeDTOCollection HydrateEntityTypeDTO(EntityTypeCollection entityTypeCollection)
        {
            EntityTypeDTOCollection tempCollection = new EntityTypeDTOCollection();

            if (entityTypeCollection != null && entityTypeCollection.Count > 0)
            {
                foreach (EntityType item in entityTypeCollection)
                {
                    if (!string.IsNullOrEmpty(item.EntityTypeName))
                    {
                        EntityTypeDTO temp = new EntityTypeDTO()
                        {
                            EntityTypeId = item.EntityTypeId,
                            EntityTypeName = item.EntityTypeName
                        };
                        if (!string.IsNullOrEmpty(item.DisplayName))
                            temp.DisplayName = item.EntityTypeName;

                        tempCollection.Add(temp);
                    }
                    else
                        tempCollection.Add(new EntityTypeDTO { EntityTypeId = item.EntityTypeId });
                }
            }
            return tempCollection;
        }

        private EntityType HydrateEntityType(EntityTypeDTO entityTypeDTO)
        {
            EntityType tempItem = new EntityType();

            if(entityTypeDTO != null)
            {
                tempItem.EntityTypeId = entityTypeDTO.EntityTypeId;

                if (!string.IsNullOrEmpty(entityTypeDTO.EntityTypeName))
                    tempItem.EntityTypeName = entityTypeDTO.EntityTypeName;

                if (!string.IsNullOrEmpty(entityTypeDTO.DisplayName))
                    tempItem.DisplayName = entityTypeDTO.DisplayName;
            }
            return tempItem;
        }

        public EntityTypeDTOCollection getEntityTypeCollection(int entityId)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
