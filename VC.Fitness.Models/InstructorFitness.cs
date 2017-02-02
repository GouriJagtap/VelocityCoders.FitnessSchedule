using Jagtap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessSchedule.Models
{
    class InstructorFitness : BaseEntity<int>


    {

        public InstructorFitness()
        {

        }

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


        public int InstructorFitnessClassId { get; set; }

        public int InstructorId { get; set; }

        public int FitnessClassId { get; set; }
    }
}
