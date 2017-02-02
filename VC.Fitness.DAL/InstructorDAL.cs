using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using Jagtap.Common.Extensions;
using VelocityCoders.FitnessSchedule.Models.Enums;
using System.Data.SqlClient;
using System.Data;


namespace VelocityCoders.FitnessSchedule.DAL
{
    public class InstructorDAL
    {

        #region SELECT
        /// <summary>
        /// Gets a single record for an Instructor
        /// </summary>
        /// <param name="instructorId"></param>
        /// <returns></returns>
        /// 

        public static Instructor GetItem(int instructorId)
        {
            Instructor tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = FillDataRecord(myReader);

                        }
                        myReader.Close();
                    }
                }
            }    
            return tempItem;
            }
        
        
      
      
        public static InstructorCollection GetCollection()
        {
            InstructorCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new InstructorCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
                            }

                        }
                        myReader.Close();
                    }

                }
            }
            return tempList;
        }
        #endregion

        private static Instructor FillDataRecord(IDataRecord myDataRecord)
        {
            Instructor myObject = new Instructor();

            myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PersonId")))
                myObject.PersonId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
                myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
                myObject.LastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayFirstName")))
                myObject.DisplayFirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayFirstName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
                myObject.Gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BirthDate")))
                myObject.BirthDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("BirthDate"));
            
            // Instructor specific Properties

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EmployeeTypeId")))
                myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EmployeeTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HireDate")))
                myObject.HireDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("HireDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TermDate")))
                myObject.TermDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("TermDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
                myObject.CreateDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("CreateDate"));

            return myObject;
        }
        //public static Instructor GetItem(int instructorID)
        //{
        //    Instructor tempItem = null;

        //    using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
        //    {
        //        using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
        //        {
        //            myCommand.CommandType = CommandType.StoredProcedure;

        //            myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
        //            myCommand.Parameters.AddWithValue("@InstructorId", instructorID);

        //            myConnection.Open();
        //            using (SqlDataReader myReader = myCommand.ExecuteReader())
        //            {
        //                if (myReader.Read())
        //                {
        //                    tempItem = FillDataRecord(myReader);
        //                }
        //                myReader.Close();
        //            }
        //        }
        //    }
        //    return tempItem;
        //}

        #region INSERT and UPDATE
        /// <summary>
        /// Saves the Instructor to the Databese. Determines to INSERT or UPDATE based on
        /// valid instructorId
        /// </summary>
        /// <param name="instructorToSave"></param>
        /// <returns></returns>
        public static int Save(Instructor instructorToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (instructorToSave.InstructorId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorToSave.InstructorId);
                    myCommand.Parameters.AddWithValue("@PersonId", instructorToSave.PersonId);

                   

                    if (instructorToSave.HireDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@HireDate", instructorToSave.HireDate.ToShortDateString());

                    if (instructorToSave.TermDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@TermDate", instructorToSave.TermDate.ToShortDateString());

                    if (instructorToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", instructorToSave.Description);

                    if (instructorToSave.EntityTypeId != 0)
                        myCommand.Parameters.AddWithValue("@EntityTypeId", instructorToSave.EntityTypeId);

                    //Add return output parameter to command object

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;

                }

                myConnection.Close();
            }
            return result;
        }

        public static int AddFitnessClass(int instructorId, int fitnessClassId)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //if (instructorToSave.InstructorId > 0)
            //    queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructorFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fitnessClassId);



                    //if (instructorToSave.HireDate != DateTime.MinValue)
                    //    myCommand.Parameters.AddWithValue("@HireDate", instructorToSave.HireDate.ToShortDateString());

                    //if (instructorToSave.TermDate != DateTime.MinValue)
                    //    myCommand.Parameters.AddWithValue("@TermDate", instructorToSave.TermDate.ToShortDateString());

                    //if (instructorToSave.Description != null)
                    //    myCommand.Parameters.AddWithValue("@Description", instructorToSave.Description);

                    //if (instructorToSave.EntityTypeId != 0)
                    //    myCommand.Parameters.AddWithValue("@EntityTypeId", instructorToSave.EntityTypeId);

                    //Add return output parameter to command object

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;

                }

                myConnection.Close();
            }
            return result;
        }
        #endregion

        #region DELETE

        public static bool Delete(int instructorId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }

        public static bool DeleteFitnessClass(int instructorFitnessClassId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteInstructorFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@InstructorFitnessClassId", instructorFitnessClassId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion
    }
}

