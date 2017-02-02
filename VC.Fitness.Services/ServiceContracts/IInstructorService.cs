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
    interface IInstructorService
    {
        ///<summary>
        ///Get a single instance of an Instructor
        ///</summary>
        ///<param name="instructorId"></param>
        ///
        [Description("Gets a single instance of an Instructor.Pass in the instructorId as a parameter")]
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "Instructor/Item/{instructorId}")]
        InstructorDTO GetInstructor(string instructorId);

        ///<summary>
        ///Associate an Instructor with a Fitness Class.
        /// </summary>
        /// <param name="instructorId"></param>
        /// <param name="fitnessClassId"></param>
        /// <returns></returns>
        /// 
        [Description("Associate an Instructor with a Fitness Class. Returns InstructorFitnessClass Id.")]
        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Item/AddFitnessClass/{instructorId}")]
        int AddFitnessClass(string instructorId, string fitnessClassId);

        [Description("Delete the instructorFitnessClass from InstructorFitnessClass table")]
        [OperationContract]
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json, UriTemplate = "/Instructor/Item/DeleteFitnessClass/{instructorFitnessClassId}")]
        bool DeleteFitnessClass(string instructorFitnessClassId);



    }

}
