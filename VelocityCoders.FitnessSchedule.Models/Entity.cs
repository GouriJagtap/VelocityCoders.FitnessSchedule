using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class Entity : BaseEntity<int>
    {
        //Default Constructor
        public Entity()
        {
        }
        //Overloaded constructor
        public Entity(int entityId, string entityName)
        {
            this.EntityId = entityId;
            this.EntityName = entityName;
        }
       
        public override string Name
        {
            get
            {
                return "Enitty Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :" ;
            throw new NotImplementedException();
        }

        //public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
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
