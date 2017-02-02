using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class Email : BaseEntity<int>
    {
        //Default Constructor
        public Email ()
        {

        }
        //Overloaded constructor
        public override int ID
        {
            get
            {
                return ID;
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
                return "Email Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :";
            throw new NotImplementedException();
        }

        public Email(int id, int emailId,string emailAddress)
        {
            this.EmailId = emailId;
            this.EmailAddress = emailAddress;
            //base.ID = id;
        }
       // public int Id { get; set; }
        public int EmailId { get; set; }
        public int EntityTypeId { get; set; }
        public int InstructorId { get; set; }
        public string EmailAddress { get; set; }
    }
}
