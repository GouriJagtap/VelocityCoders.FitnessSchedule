using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class EntityType :BaseEntity<int>
    {
        //Default Constructor
        public EntityType()
        {

        }

        //Overloaded constructor

            public EntityType(int entityTypeId, string displayName)
        {
            this.EntityTypeId = entityTypeId;
            this.DisplayName = displayName;        
        }

       
        public override string Name
        {
            get
            {
                return "Entity Type Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :" ;
            throw new NotImplementedException();
        }

        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public string EntityTypeName { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }

     

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
