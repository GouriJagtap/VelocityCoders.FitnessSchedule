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
    public class LocationManager
    {

        public static Location GetItem(int locationId)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (locationId <= 0)
            {
                saveBrokenRules.Add("Location", "Invalid ID: " + locationId.ToString());

                throw new BLLException("There was an error retrieving Gym", saveBrokenRules);
            }

            Location item = LocationDAL.GetItem(locationId);

            if (item == null)
            {
                saveBrokenRules.Add("Location", "Could not retrieve record with ID: " + locationId.ToString());

                throw new BLLException("Error: No records found", saveBrokenRules);
            }
            else
                return item;
        }

        public static LocationCollection GetCollection()
        {
            LocationCollection collection = LocationDAL.GetCollection();

            return collection;
        }

        public static int Save(Location locationToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (string.IsNullOrEmpty(locationToSave.Name))
                saveBrokenRules.Add("Location Name", "Name is required.");

            if (saveBrokenRules.Count() > 0)
            {
                throw new BLLException("There was an error saving Gym", saveBrokenRules);
            }
            else
            {
                return LocationDAL.Save(locationToSave);
            }

        }

        public static bool Delete(int locationToSave)
        {
            if (locationToSave > 0)
                return LocationDAL.Delete(locationToSave);
            else
                throw new BLLException("Delete failed. Location ID is Invalid: " + locationToSave.ToString());
        }

    }

}

