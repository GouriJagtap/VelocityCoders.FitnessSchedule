using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.DAL;

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
    }
}
