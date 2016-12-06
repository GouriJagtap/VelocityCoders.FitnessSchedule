﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagtap.Common
{
    public class BLLException : Exception
        {
        public BLLException() : base() { }

        public BLLException(string message) : base(message) { }
        /// <summary>
        /// Sets the message and sets the BrokenRules property
        /// </summary>
        /// <param name="message"></param>
        /// <param name="brokenRules"></param>
        public BLLException(string message, BrokenRuleCollection brokenRules) : base(message)
        {
            this.BrokenRules = brokenRules;
        }
        public BLLException(string message, Exception inner) : base(message, inner) { }

        public BLLException(string message, Exception inner, BrokenRuleCollection brokenRules) : base(message, inner)
        {
            this.BrokenRules = brokenRules;
        }

        #region PROPERTIES
        /// <summary>
        /// Contains All the validation errors from the BLL
        /// </summary>
        public BrokenRuleCollection BrokenRules { get; set; }

        #endregion
    }
}
