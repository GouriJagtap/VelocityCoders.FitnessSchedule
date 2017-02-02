using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
 public class State:BaseEntity<int>
    {
        public string StateName { get; set; }
        public string ShortName { get; set; }
        public string Abbreviation { get; set; }

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
    }
}
