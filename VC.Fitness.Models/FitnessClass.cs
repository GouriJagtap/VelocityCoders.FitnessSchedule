﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
    public class FitnessClass :BaseEntity<int>
    {
        //Default Constructor
        public FitnessClass()
        {

        }
        //Overloaded constructor

        public FitnessClass(int fitnessClassId, string fitnessClassName)
        {
            this.FitnessClassId = fitnessClassId;
            this.FitnessClassName = fitnessClassName;
        }

       

        public override string Name
        {
            get
            {
                return "Fitness Class Entity";
            }
        }
        public override string GetName()
        {
            return "Name from sub class :" ;
            throw new NotImplementedException();
        }

        #region Properties
        public int FitnessClassId { get; set; }
        public string FitnessClassName { get; set; }
        public int InstructorFitnessClassId { get; set; }
        //public string Category { get; set; }

        #endregion
      

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
