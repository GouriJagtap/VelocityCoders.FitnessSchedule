using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.WebForms
{
    public static class Utilities
    {
        /// <summary>
        /// Extract info from <appsettings> </appsettings>
        /// from the web.Config file
        /// </summary>
        /// <param name="keyName"></param>
        /// <returns></returns>
        public static string GetApplicationKeyValue(string keyName)
        {
            try
            {
                return System.Configuration.ConfigurationManager.AppSettings[keyName];
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}