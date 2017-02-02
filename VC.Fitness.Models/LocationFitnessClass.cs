using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class LocationFitnessClass : BaseEntity<int>
    {
        //Default Constructor

        public LocationFitnessClass()
        {

        }

        //Overloaded constructor
        
        public LocationFitnessClass(int fitnessClassId, int locationId)
        {
            this.FitnessClassId = fitnessClassId;
            this.LocationId = locationId;
        }

        public override string Name
        {
            get
            {
                return "Location Fitness Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :" ;
            throw new NotImplementedException();
        }
        public int FitnessClassId { get; set; }
        public int LocationId { get; set; }
        public int LocationFitnessClassId { get; set; }
        public string Description { get; set; }

        

        public override int ID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
