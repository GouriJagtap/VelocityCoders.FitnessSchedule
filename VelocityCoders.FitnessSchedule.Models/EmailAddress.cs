using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class EmailAddress : BaseEntity<int>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public EmailAddress()
        {
            this.EmailType = new EntityType();
        }
        public EmailAddress(int instructorId)
        {

        }

        public EmailAddress(int entityTypeId, string emailAddress)
        {
            this.EmailType = new EntityType { EntityTypeId = entityTypeId };
            this.EmailValue = emailAddress;
        }

        public int EmailId { get; set; }
        public string EmailValue { get; set; }
        public EntityType EmailType { get; set; }
        

        #region BASE ENTITY METHODS
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

        public override string Name
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string GetName()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
