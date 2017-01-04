using Jagtap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;

namespace VelocityCoders.FitnessSchedule.BLL
{
    public class GymManager
    {
        public static Gym GetItem(int gymId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if(gymId <=0)
            {
                saveBrokenRules.Add("Gym", "Invalid ID: " + gymId.ToString());

                throw new BLLException("There was an error retrieving Gym", saveBrokenRules);
            }

            Gym item = GymDAL.GetItem(gymId);

            if (item == null)
            {
                saveBrokenRules.Add("Gym", "Could not retrieve record with ID: " + gymId.ToString());

                throw new BLLException("Error: No records found", saveBrokenRules);
            }
            else
                return item;
        }

        public static GymCollection GetCollection()
        {
            GymCollection collection = GymDAL.GetCollection();

            return collection;
        }

        public static int Save(Gym gymToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(gymToSave.GymName))
                saveBrokenRules.Add("Gym Name", "Name is required.");

            if(saveBrokenRules.Count() > 0)
            {
                throw new BLLException("There was an error saving Gym", saveBrokenRules);
            }
            else
            {
                return GymDAL.Save(gymToSave);
            }

        }

        public static bool Delete(int gymId)
        {
            if (gymId > 0)
                return GymDAL.Delete(gymId);
            else
                throw new BLLException("Delete failed. Gym ID is Invalid: " + gymId.ToString());
        }

        }
}
