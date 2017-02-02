using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common;

namespace VelocityCoders.FitnessSchedule.BLL
{
   public static class EmailAddressManager
    {
        #region INSERT, SAVE

        public static int Save(int instructorId, EmailAddress emailToSave)
        {
            BrokenRuleCollection saveBrokenRules = new BrokenRuleCollection();

            if (instructorId <= 0)
                saveBrokenRules.Add("Instructor", "Invalid Id");

            //make sure email type is in correct format
            ValidateEmail(emailToSave, ref saveBrokenRules);

            //email type is required
            if(emailToSave.EmailType.EntityTypeId <= 0)
            {
                saveBrokenRules.Add("Email Address Type", "Type is required.");
            }
            if(saveBrokenRules.Count() > 0)
            {
                throw new BLLException("There was an error saving Email", saveBrokenRules);
            }
            else
            {
                // Validation successful - call data access layer to save
                return EmailAddressDAL.Save(instructorId, emailToSave);
            }
        }
        #endregion

        #region SELECT

        public static EmailAddress GetItem(int emailId)
        {
            return EmailAddressDAL.GetItem(emailId);
        }

        public static EmailAddressCollection GetCollection(int instructorId)
        {
            return EmailAddressDAL.GetCollection(instructorId);
        }
        #endregion

        #region DELETE

        public static bool Delete(int emailId)
        {
            if (emailId > 0)
                return EmailAddressDAL.Delete(emailId);
            else
                throw new BLLException("Delete failed. Email Id is invalid :" + emailId.ToString());
        }
        #endregion

        #region PRIVATE HELPER METHODS

        private static bool ValidateEmail(EmailAddress emailToValidate, ref BrokenRuleCollection brokenRules)
        {
            //Set default return value to true
            bool returnValue = true;

            if (emailToValidate != null)
            {
                if (!string.IsNullOrEmpty(emailToValidate.EmailValue))
                {
                    if (!EmailValidator.IsValid(emailToValidate.EmailValue.Trim()))
                    {
                        brokenRules.Add("Email Address", emailToValidate.EmailValue.Trim() + " is an invalid email format.");
                        returnValue = false;
                    }
                }
                else
                {
                    brokenRules.Add("Email Address", "Email is required.");
                    returnValue = false;
                }
            }
            else
            {
                brokenRules.Add("Email Address", "Email class was not instantiated");
                returnValue = false;
            }
            return returnValue;

        }
        #endregion

    }
}
