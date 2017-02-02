using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class Location :BaseEntity<int>
    {
        //Default Constructor
        public Location()
        {

        }
        //Overloaded Constructor
        public Location(int locationId, string locationName)
        {
            this.LocationId = locationId;
            this.LocationName = locationName;
        }

       
        public override string Name
        {
            get
            {
                return "Location Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :" + Name;
            throw new NotImplementedException();
        }

        public int LocationId { get; set; }
      
        public string LocationName { get; set; }
        public string Address01 { get; set; }
        public string Address02 { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }

        public int StateId { get; set; }
        public int GymId { get; set; }
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
