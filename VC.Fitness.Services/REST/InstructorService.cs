using Jagtap.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using VelocityCoders.FitnessSchedule.BLL;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Services.DataContracts;
using VelocityCoders.FitnessSchedule.Services.ServiceContracts;

namespace VelocityCoders.FitnessSchedule.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public class InstructorService : IInstructorService
    {
        #region GET

        public InstructorDTO GetInstructor(string instructorId)
        {
            Instructor model = InstructorManager.GetItem(instructorId.ToInt());
            return this.InstructorItemToDTO(model);
        }
        #endregion

        #region ADD FITNESS CLASS

        public int AddFitnessClass(string instructorId, string fitnessClassId)
        {
            return InstructorManager.AddFitnessClass(instructorId.ToInt(), fitnessClassId.ToInt());
        }
        #endregion

        #region PRIVATE METHODS

        private InstructorDTO InstructorItemToDTO(Instructor instructor)
        {
            InstructorDTO tempItem = new InstructorDTO();

            if (instructor != null)
            {
                tempItem.InstructorId = instructor.InstructorId;

                if (!string.IsNullOrEmpty(instructor.FirstName))
                    tempItem.FirstName = instructor.FirstName;

                if (!string.IsNullOrEmpty(instructor.LastName))
                    tempItem.LastName = instructor.LastName;
            }
            return tempItem;
        }

        public bool DeleteFitnessClass(string instructorFitnessClassId)
        {
            return InstructorManager.DeleteFitnessClass(instructorFitnessClassId.ToInt());
        }
        #endregion


    }
}