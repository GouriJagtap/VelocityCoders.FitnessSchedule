using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.DAL;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Manager
{
    public static class EntityManager
    {
        #region SELECT COLLECTION

        public static EntityCollection GetCollection()
        {
            return EntityDAL.GetCollection();
        }
        #endregion

        public static bool Delete(int entityId)
        {
            if (entityId > 0)
            {
                return EntityDAL.Delete(entityId);
            }
            else
                throw new BLLException("Delete Failed. Entity Type Id is invalid." + entityId.ToString());

        }
    }
}
