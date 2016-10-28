using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Jagtap.Common
{
    public abstract class BaseCollection<T> : Collection<T> , IList<T>
    {
        protected BaseCollection() : base (new List<T>()) { }
    }
}
