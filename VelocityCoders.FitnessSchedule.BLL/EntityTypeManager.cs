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
        #endregion

        #region GetCollection

        public static EntityTypeCollection GetCollection(EntityEnum entityName)
        {
            EntityTypeCollection collection = EntityTypeDAL.GetCollection(entityName);
            return collection;
        }
        #endregion
    }
}
