using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using VelocityCoders.FitnessSchedule.Services.DataContracts;
using VelocityCoders.FitnessSchedule.Manager;
using VelocityCoders.FitnessSchedule.Services.ServiceContracts;
using Jagtap.Common.Extensions;
using Jagtap.Common;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.BLL;

namespace VelocityCoders.FitnessSchedule.Services.REST
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class GymService : IGymService
    {
        #region GYM

        public GymDTO GetGym(string gymId)
        {
            Gym model = GymManager.GetItem(gymId.ToInt());
            return this.GymItemToDTO(model);
        }

        public GymDTOCollection GetGyms()
        {
            GymCollection gymList = GymManager.GetCollection();
            return this.GymCollectionToDTO(gymList);
        }

        public GymDTO SaveGym(GymDTO gymToSave)
        {
            int gymId = GymManager.Save(this.DTOItemToGym(gymToSave));

            // Gym updatedItem = GymManager.GetItem(gymId);

            gymToSave.Id = gymId;
            return gymToSave;


            //return this.GymItemToDTO(updatedItem);

        }

        public bool DeleteGym(string gymId)
        {
            return GymManager.Delete(gymId.ToInt());
        }
        #endregion

        #region HYDRATE OBJECTS AND DTOs

        private Gym DTOItemToGym(GymDTO gymDTO) {

            Gym tempItem = new Gym();

            if(gymDTO != null)
            {
                tempItem.GymId = gymDTO.Id;

                if (!string.IsNullOrEmpty(gymDTO.Name))
                    tempItem.GymName = gymDTO.Name;

                if (!string.IsNullOrEmpty(gymDTO.Abbreviation))
                    tempItem.Abbreviation = gymDTO.Abbreviation;

                if (!string.IsNullOrEmpty(gymDTO.WebSite))
                    tempItem.WebSite = gymDTO.WebSite;

                if (!string.IsNullOrEmpty(gymDTO.Description))
                    tempItem.Description=gymDTO.Description;

                //if ((!string.IsNullOrEmpty(gymDTO.CreateDate.ToShortDateString())))
                //    tempItem.CreateDate = gymDTO.CreateDate;


            }
            return tempItem;
        }

        private GymDTOCollection GymCollectionToDTO(GymCollection gymCollection)
        {
            GymDTOCollection tempList = new GymDTOCollection();

            if(gymCollection !=null)
            {
                foreach(Gym item in gymCollection)
                {
                    tempList.Add(this.GymItemToDTO(item));
                }
            }
            return tempList;
        }

        private GymDTO GymItemToDTO(Gym gymModel)
        {
            GymDTO tempItem = new GymDTO();

            if(gymModel != null)
            {
                tempItem.Id = gymModel.GymId;

                if (!string.IsNullOrEmpty(gymModel.GymName))
                    tempItem.Name = gymModel.GymName;

                if (!string.IsNullOrEmpty(gymModel.Abbreviation))
                    tempItem.Abbreviation = gymModel.Abbreviation;

                if (!string.IsNullOrEmpty(gymModel.WebSite))
                    tempItem.WebSite = gymModel.WebSite;

                if (!string.IsNullOrEmpty(gymModel.Description))
                    tempItem.Description = gymModel.Description;

                //if (!string.IsNullOrEmpty(gymModel.CreateDate.ToShortDateString()))
                //    tempItem.CreateDate = gymModel.CreateDate;

            }
            return tempItem;

        }

        #endregion
    }
}