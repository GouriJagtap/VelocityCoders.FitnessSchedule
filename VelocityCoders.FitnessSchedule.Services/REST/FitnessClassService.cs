using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Services.DataContracts;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Services.ServiceContracts;
using Jagtap.Common;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.BLL;

namespace VelocityCoders.FitnessSchedule.Services.REST
{
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public class FitnessClassService : IFitnessClassService
    {
        #region GET
        
        public FitnessClassDTO GetFitnessClass(string fitnessClassId)
        {
            FitnessClass model = FitnessClassManager.GetItem(fitnessClassId.ToInt());
            return this.FitnessClassItemToDTO(model);
        }

        public FitnessClassDTOCollection GetFitnessClasses()
        {
            FitnessClassCollection fitnessClassList = FitnessClassManager.GetCollection();
            return this.FitnessClassCollectionToDTO(fitnessClassList);

        }
        #endregion

        #region Private Methods

        private FitnessClassDTO FitnessClassItemToDTO(FitnessClass fitnessClass)
        {
            FitnessClassDTO tempItem = new FitnessClassDTO();

            if(fitnessClass != null)
            {
                tempItem.FitnessClassId = fitnessClass.FitnessClassId;

                if (!string.IsNullOrEmpty(fitnessClass.FitnessClassName))
                    tempItem.FitnessClassName = fitnessClass.FitnessClassName;
            }
            return tempItem;
        }

        private FitnessClassDTOCollection FitnessClassCollectionToDTO(FitnessClassCollection fitnessClassCollection)
        {

            FitnessClassDTOCollection tempList = new FitnessClassDTOCollection();

            if(fitnessClassCollection !=null)
            {
                foreach(FitnessClass item in fitnessClassCollection)
                {
                    //Call a method to convert FitnessClass to FitnessClassDTO and add to collection 
                    tempList.Add(this.FitnessClassItemToDTO(item));
                }
            }
            return tempList;
        }
        #endregion
    }
}