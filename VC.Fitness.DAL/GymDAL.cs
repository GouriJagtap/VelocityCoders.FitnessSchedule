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
    public class GymDAL
    {
        #region GET METHODS

        public static Gym GetItem(int gymId)
        {
            Gym tempItem = null;
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetGym", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                        myCommand.Parameters.AddWithValue("@GymId", gymId);

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
        }

        public static GymCollection GetCollection()
        {
            GymCollection myCollection = null;
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetGym", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);
                       
                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                myCollection = new GymCollection();
                                while(myReader.Read())
                                {
                                    myCollection.Add(FillDataRecord(myReader));
                                }
                            }
                            myReader.Close();
                        }

                    }
                }
                
            }
            return myCollection;
        }
        #endregion

        #region INSERT AND UPDATE

        public static int Save(Gym gymToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (gymToSave.GymId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@GymId", gymToSave.GymId);

                    if (gymToSave.GymName != null)
                        myCommand.Parameters.AddWithValue("@GymName", gymToSave.GymName);

                    if (gymToSave.Abbreviation != null)
                        myCommand.Parameters.AddWithValue("@GymAbbreviation", gymToSave.Abbreviation);

                    if (gymToSave.WebSite != null)
                        myCommand.Parameters.AddWithValue("@WebSite", gymToSave.WebSite);

                    if (gymToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", gymToSave.Description);

                    //if (gymToSave.CreateDate != DateTime.MinValue)
                    //    myCommand.Parameters.AddWithValue("@CreateDate", gymToSave.CreateDate.ToShortDateString());

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;

        }

        public static bool Delete(int gymId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteGym", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@GymId", gymId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                    
                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion

        #region HELPER METHODS

        private static Gym FillDataRecord(IDataRecord myDataRecord)
        {
            Gym myObject = new Gym();

            myObject.GymId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("GymId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GymName")))
                myObject.GymName = myDataRecord.GetString(myDataRecord.GetOrdinal("GymName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("GymAbbreviation")))
                myObject.Abbreviation = myDataRecord.GetString(myDataRecord.GetOrdinal("GymAbbreviation"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("WebSite")))
                myObject.WebSite = myDataRecord.GetString(myDataRecord.GetOrdinal("WebSite"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
            //    myObject.CreateDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("CreateDate"));

            return myObject;

        }
        #endregion
    }
}
