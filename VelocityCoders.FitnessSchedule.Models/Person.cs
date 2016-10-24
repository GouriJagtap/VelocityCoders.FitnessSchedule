using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class Person : BaseEntity<int>
    {
        //Default Constructor

        public Person()
        {
        }

        //Overloaded constructor
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        //Another overloaded Constructor
        public Person(string firstName, string lastName, string gender)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gender = gender;
        }

        //Overriding the property of the abstract base class
        public override string Name
        {
            get
            {
                return " Name from base class " + this.FirstName + " " + this.LastName;
            }
        }

       

        //// Overriding the abstract method in the base class

        public override string GetName()
        {
            return "Name from sub class using abstract method from abstract class:" + this.FirstName + " " + this.LastName;
            throw new NotImplementedException();
        }

        public string firstName;
        public string lastName;
        public int PersonId {get; set;}
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName { get; set; }
      
        public string DisplayFirstName { get; set; }
        public string Gender { get; set; }

        

        public override int ID
        {
            get
            {
                return 1;
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
            // Override Virtual Method from BaseEntity class

            public override string GetName1()
        {
            return "From Person Class:" + this.firstName + this.lastName;
        }
        public override string GetName1(string s1, string s2)
        {
            return s1 + s2;
        }
    
    }
}
