using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jagtap.Common;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models.Enums;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace VelocityCoders.FitnessSchedule.DAL
{
    public class PersonDAL
    {
        public static PersonCollection GetCollection()
        {
            PersonCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.HasRows)
                        {
                            tempList = new PersonCollection();
                            while(myReader.Read())
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

        private static Person FillDataRecord(IDataRecord myDataRecord)
        {
            Person myObject = new Person();

            myObject.PersonId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FirstName")))
                myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("FirstName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LastName")))
                myObject.LastName = myDataRecord.GetString(myDataRecord.GetOrdinal("LastName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayFirstName")))
                myObject.DisplayFirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayFirstName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Gender")))
                myObject.Gender = myDataRecord.GetString(myDataRecord.GetOrdinal("Gender"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Birthdate")))
                myObject.BirthDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("BirthDate"));

            return myObject;
        }

        //Get a single Item from Person table


        public static Person GetItem(int personId)
        {
            Person tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetPerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@PersonId", personId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if(myReader.Read())
                        {
                            tempItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tempItem;
              
        }

        #region INSERT and UPDATE
        /// <summary>
        /// Saves the Person to the Databese. Determines to INSERT or UPDATE based on
        /// valid personId
        /// </summary>
        /// <param name="personToSave"></param>
        /// <returns></returns>
        public static int Save(Person personToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (personToSave.PersonId > 0)
             queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecutePerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (personToSave.PersonId > 0)
                        myCommand.Parameters.AddWithValue("@PersonId", personToSave.PersonId);

                    if (personToSave.FirstName != null)
                        myCommand.Parameters.AddWithValue("@FirstName", personToSave.FirstName);

                    if (personToSave.LastName != null)
                        myCommand.Parameters.AddWithValue("@LastName", personToSave.LastName);

                    if (personToSave.DisplayFirstName != null)
                        myCommand.Parameters.AddWithValue("@DisplayFirstName", personToSave.DisplayFirstName);

                    if (personToSave.Gender != null)
                        myCommand.Parameters.AddWithValue("@Gender", personToSave.Gender);

                    if (personToSave.BirthDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@BirthDate", personToSave.BirthDate.ToShortDateString());

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
        
        public static bool Delete(int PersonId)
        {
            int result = 0;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecutePerson", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@PersonId", PersonId);

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
