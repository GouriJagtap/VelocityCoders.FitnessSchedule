using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.Models
{
   public class Student: Person, IPerson
    {
        public DateTime JoinDate { get; set; }

        // Implement Interface Method
        public string GetFullInfo()
        {
            return "Student " + base.Name + ":" + this.JoinDate.ToShortDateString();
        }
    }
}
