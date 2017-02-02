using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using VelocityCoders.FitnessSchedule.Services.ServiceContracts;
using VelocityCoders.FitnessSchedule.Services.DataContracts;

namespace VelocityCoders.FitnessSchedule.Services.ServiceContracts
{
    [ServiceContract]
    interface IFitnessClassService
    {
        ///<summary>
        ///Get a single instance of a Fitness class
        /// </summary>
        /// <param name="fitnessClassId"></param>
        /// <returns></returns>

        [Description("Gets a single instance of a Fitness Class.Pass in the fitnessClassId as a parameter")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "FitnessClass/Item/{fitnessClassId}")]
        FitnessClassDTO GetFitnessClass(string fitnessClassId);


        ///<summary>
        ///Gets a collection of Fitness Class instances
        /// </summary>
        /// <returns></returns>
        /// 

        [Description("Gets the collection of Fitness Class records.")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "FitnessClass/Collection/")]
        FitnessClassDTOCollection GetFitnessClasses();

        ///<summary>
        ///Gets a collection of Fitness Class instances by Instructor
        /// </summary>
        /// <returns></returns>
        /// 
        [Description("Gets a collection of Fitness CLass records by Instructor.")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "FitnessClass/Collection/Instructor/{instructorId}")]
        FitnessClassDTOCollection GetFitnessClassesByInstructor(String instructorId);


    }
}
