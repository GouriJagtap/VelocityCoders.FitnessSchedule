using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.DAL;

namespace VelocityCoders.FitnessSchedule.Manager
{
    public static class PersonManager
    {
        #region INSERT, UPDATE

        public static int Save(Person personToSave)
        {
            int returnValue;
            returnValue = PersonDAL.Save(personToSave);

            return returnValue;
        }

        #endregion

        #region DELETE

        public static bool Delete(int personId)
        {
            // Call DAL to delete person record
            return PersonDAL.Delete(personId);
        }

        #endregion

    }
}
