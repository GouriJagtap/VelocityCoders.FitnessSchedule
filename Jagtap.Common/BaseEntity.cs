using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagtap.Common
{
    public abstract class BaseEntity<T>
    {
        public abstract T ID { get; set; }

        //Abstract property that is a read only because it has only get;
        public abstract string Name { get; }

        // abstract method doesnt have a body its just a declaration

        public abstract string GetName();

        ////Virtual method in the abstract class

        public virtual string GetName1()
        {
            return "Name from base class";
        }
        public virtual string GetName1(string fName, string lName)
        {
            return "Name from base class";
        }
    }
}
