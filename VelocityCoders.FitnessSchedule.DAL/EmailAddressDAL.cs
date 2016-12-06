using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models.Enums;

namespace VelocityCoders.FitnessSchedule.DAL
{
    public class EmailAddressDAL
    {
        #region INSERT AND UPDATE

        public static int Save(int instructorId, EmailAddress emailToSave)
        {
            int result = 0;

            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (emailToSave.EmailId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@EmailId", emailToSave.EmailId);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", emailToSave.EmailType.EntityTypeId);

                    if (emailToSave.EmailValue != null)
                        myCommand.Parameters.AddWithValue("@EmailAddress", emailToSave.EmailValue);

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

        #region SELECT
        public static EmailAddress GetItem(int emailId)
        {
            EmailAddress tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);

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

        public static EmailAddressCollection GetCollection(int instructorId)
        {
            EmailAddressCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionByInstructor);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EmailAddressCollection();
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

        #region DELETE

        public static bool Delete(int emailId)
        {
            int result = 0;

            using (SqlConnection MyConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", MyConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EmailId", emailId);

                    MyConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                MyConnection.Close();

            }    
                return result > 0;
            
        }

        public static bool DeleteCollection(int instructorId)
        {
            int result = 0;

            using (SqlConnection MyConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEmail", MyConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteEmail);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorId);

                    MyConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                MyConnection.Close();

            }
            return result > 0;

        }
        #endregion

        #region HELPER METHODS

        public static EmailAddress FillDataRecord(IDataRecord myDataRecord)
        {
            EmailAddress myObject = new EmailAddress();

            myObject.EmailId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EmailId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EmailValue")))
                myObject.EmailValue = myDataRecord.GetString(myDataRecord.GetOrdinal("EmailValue"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeId")))
            {
                myObject.EmailType.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));

                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeName")))
                    myObject.EmailType.EntityTypeName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeName"));
            }
            return myObject;
        }
        #endregion
    }
}
