using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Services.DataContracts;

namespace VelocityCoders.FitnessSchedule.Services.ServiceContracts
{
    [ServiceContract]
    interface IGymService
    {
        /// <summary>
        /// Gets a collection of Gym instances
        /// </summary>
        /// <returns></returns>
        [Description("Gets a collection of Gym records in JSON format.")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Gym/Collection/")]
        GymDTOCollection GetGyms();


        /// <summary>
        /// Get a single instance of a gym
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        [Description("Gets a single instance of a gym. Pass in the gymId as a parameter")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Gym/Item/{gymId}")]
        GymDTO GetGym(string gymId);


        /// <summary>
        /// Delete Gym record
        /// </summary>
        /// <param name="gymId"></param>
        /// <returns></returns>
        [Description("Deletes a Gym instance")]
        [OperationContract]
        [WebInvoke(Method = "DELETE",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "Gym/Item/{gymID}")]
        bool DeleteGym(string gymId);



        /// <summary>
        /// Save a Gym record.
        /// </summary>
        /// <param name="gymToSave"></param>
        /// <returns></returns>
        [Description("Saves a gym record")]
        [OperationContract]
        [WebInvoke(Method = "PUT",
                    ResponseFormat = WebMessageFormat.Json,
                    UriTemplate = "Gym/Item/")]
        GymDTO SaveGym(GymDTO gymToSave);



    }
}
