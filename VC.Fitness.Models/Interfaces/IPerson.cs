using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.FitnessSchedule
{
    public interface IPerson
    {
        //Method
        string GetFullInfo();

        //Property
        string Name { get; }
    }
}
