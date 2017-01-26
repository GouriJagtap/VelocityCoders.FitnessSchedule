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
    }

}
