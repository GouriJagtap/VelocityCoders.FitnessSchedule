using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Jagtap.Common
{
    public class BrokenRule
    {/// <summary>
    /// Constructor to initialize new instance of BrokenRule class
    /// </summary>
    /// <param name="propertyName"></param>
    /// <param name="message"></param>
        public BrokenRule(string propertyName, string message)
        {
            this.PropertyName = propertyName;
            this.Message = message;

        }
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }

    public class BrokenRuleCollection : Collection<BrokenRule>
    {
        #region METHODS
        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="message">The validation message associates with the broken rule</param>
        public void Add(string message)
        {
            Add(new BrokenRule(string.Empty, message));
        }
        /// <summary>
        /// Creates a new BrokenRule instance and adds it to the inner list.
        /// </summary>
        /// <param name="propertyName">The name of the property that caused the rule to be broken. Can be left empty.</param>
        /// <param name="message">The validation message associates with the broken rule</param>
        public void Add(string propertyName, string message)
        {
            Add(new BrokenRule(propertyName, message));
        }
        #endregion
    }
}
