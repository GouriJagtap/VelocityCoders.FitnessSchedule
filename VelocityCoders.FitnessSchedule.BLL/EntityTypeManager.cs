using Jagtap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models.Enums;

namespace VelocityCoders.FitnessSchedule.Manager
{
    public static class EntityTypeManager
    {

        #region GET ITEM

        public static EntityType GetItem()
        {
            return new EntityType();
        }


        public static EntityType GetItem(int entityTypeId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (entityTypeId <= 0)
            { 
                saveBrokenRules.Add("Entity Type", "Invalid Id" +entityTypeId.ToString());

                throw new BLLException("There was an error saving Email", saveBrokenRules);
            }
            EntityType item = EntityTypeDAL.GetItem(entityTypeId);
            if (item == null)
            {
                saveBrokenRules.Add("EntityType", "Could not retrieve record with ID:" + entityTypeId.ToString());
                // Validation successful - call data access layer to save
                throw new BLLException("Error : No record found ", saveBrokenRules);
            }
            else
                return item;
        }

        #endregion

        #region GetCollection

        public static EntityTypeCollection GetCollection(EntityEnum entityName)
        {
            EntityTypeCollection collection = EntityTypeDAL.GetCollection(entityName);
            return collection;
        }
        public static EntityTypeCollection GetCollection(int entityId)
        {
            EntityTypeCollection entityTyoeCollection = EntityTypeDAL.GetCollection(entityId);
            return entityTyoeCollection;
        }
        #endregion

        #region INSERT,UPDATE


        public static int Save(int entityId, EntityType entityTypeToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (entityId <= 0)
                saveBrokenRules.Add("Entity", "Invalid Id for Entity Relationship" );

            //make sure email type is in correct format
           // ValidateEmail(emailToSave, ref saveBrokenRules);

            //email type is required
            if (string.IsNullOrEmpty(entityTypeToSave.EntityTypeName))
            {
                saveBrokenRules.Add("Entity Type Name", "Name is required.");
            }

            if (saveBrokenRules.Count() > 0)
            {
                throw new BLLException("There was an error saving Email", saveBrokenRules);
            }
            else
            {
                // Validation successful - call data access layer to save
                return EntityTypeDAL.Save(entityId, entityTypeToSave);
            }
        }
        #endregion

        #region DELETE

        public static bool Delete(int entityTypeId)
        {
            if (entityTypeId > 0)
            {
                return EntityTypeDAL.Delete(entityTypeId);
            }
            else
                throw new BLLException("Delete Failed. Entity Type Id is invalid." + entityTypeId.ToString());

        }
        #endregion

    }
}
