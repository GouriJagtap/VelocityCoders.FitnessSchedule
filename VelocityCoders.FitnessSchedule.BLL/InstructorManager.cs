using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.DAL;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Models.Collections;

namespace VelocityCoders.FitnessSchedule.BLL
{
    public static class InstructorManager
    {
        #region SAVE

        /// <summary>
        /// Saves the Instructor object to the database
        /// </summary>
        /// <param name="instructorToSave"></param>
        /// <returns></returns>
        public static int Save(Instructor instructorToSave)
        {

            int personId = SavePerson(instructorToSave);

            instructorToSave.PersonId = personId;

            return InstructorDAL.Save(instructorToSave);
        }

        public static int SaveEmail(int instructorId, EmailAddress emailToSave)
        {
            return EmailAddressManager.Save(instructorId, emailToSave);
        }
        
        #endregion

        #region HELPER METHODS

        private static int SavePerson(Instructor instructorToSave)
        {
            Person tempPerson = new Person();

            tempPerson.PersonId = instructorToSave.PersonId;
            tempPerson.FirstName = instructorToSave.FirstName;
            tempPerson.LastName = instructorToSave.LastName;
            tempPerson.DisplayFirstName = instructorToSave.DisplayFirstName;
            tempPerson.BirthDate = instructorToSave.BirthDate;
            tempPerson.Gender = instructorToSave.Gender;


            return PersonManager.Save(tempPerson);


        }

        #endregion

        #region SELECT

        public static Instructor GetItem(int instructorId)
        {
            return InstructorDAL.GetItem(instructorId);
        }

        public static InstructorCollection GetCollection()
        {
            return InstructorDAL.GetCollection();
        }
        #endregion

        #region DELETE

        public static bool Delete(int instructorId)
        {
            // Retrieve personId from so we can delete person record
            Instructor toDelete = InstructorManager.GetItem(instructorId);
            if (toDelete != null)
            {
                if (toDelete.PersonId > 0 && toDelete.InstructorId > 0)
                {
                    EmailAddressCollection emailItem = EmailAddressManager.GetCollection(instructorId);
                    if (emailItem != null)
                    {
                        //DElete Email record first

                        if (EmailAddressDAL.DeleteCollection(instructorId))
                        {
                            // delete instructor first
                            if (InstructorDAL.Delete(toDelete.InstructorId))
                            {
                                return PersonDAL.Delete(toDelete.PersonId);
                            }
                            else
                                return false;
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }

        #endregion
    }
}
