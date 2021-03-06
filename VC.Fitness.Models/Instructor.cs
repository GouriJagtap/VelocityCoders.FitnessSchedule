﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class Instructor : Person,IPerson
    {
        //Default Constructor
        public Instructor()
        {
          
        }
        //Overloaded constructor
        public Instructor (int instructorId, int personId)
        {
  
            this.InstructorId = instructorId;
            base.PersonId = personId;
        }


        public int InstructorId { get; set; }
        public int PersonId { get; set; }
        public int EntityTypeId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime TermDate { get; set; }
        public string Description   { get; set; }
        public DateTime CreateDate { get; set; }


        //Implement Interface Method 

        public string GetFullInfo()
        {
            return "Instructor:" + base.Name + ":" + this.HireDate.ToShortDateString();
        }

    }
  
}
