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
    public class LocationDAL
    {
        #region GET METHODS

        public static Location GetItem(int locationId)
        {
            Location tempItem = null;
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                        myCommand.Parameters.AddWithValue("@LocationId", locationId);

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
        }
      
        public static LocationCollection GetCollection()
        {
            LocationCollection myCollection = null;
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                myCollection = new LocationCollection();
                                while (myReader.Read())
                                {
                                    myCollection.Add(FillDataRecord(myReader));
                                }
                            }
                            myReader.Close();
                        }

                    }
                }
                return myCollection;
            }
        }

        public static LocationCollection GetCollection(int gymId)
        {
            LocationCollection myCollection = null;
            {
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetLocation", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;

                        myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionById);
                        myCommand.Parameters.AddWithValue("@GymId", gymId);

                        myConnection.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            if (myReader.HasRows)
                            {
                                myCollection = new LocationCollection();
                                while (myReader.Read())
                                {
                                    myCollection.Add(FillDataRecord(myReader));
                                }
                            }
                            myReader.Close();
                        }

                    }
                }
                return myCollection;
            }
        }
        #endregion

        #region INSERT AND UPDATE

        public static int Save(Location locationToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (locationToSave.ID > 0)
                queryId = ExecuteTypeEnum.UpdateItem;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@LocationId", locationToSave.ID);

                    if (locationToSave.Name != null)
                        myCommand.Parameters.AddWithValue("@LocationName", locationToSave.Name);

                    if (locationToSave.Address01 != null)
                        myCommand.Parameters.AddWithValue("@Abbreviation", locationToSave.Address01);

                    if (locationToSave.Address02 != null)
                        myCommand.Parameters.AddWithValue("@Website", locationToSave.Address02);


                    if (locationToSave.City != null)
                        myCommand.Parameters.AddWithValue("@Description", locationToSave.City);

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;

        }

        public static bool Delete(int locationId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLocation", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LocationId", locationId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion

        #region HELPER METHODS

        private static Location FillDataRecord(IDataRecord myDataRecord)
        {
            Location myObject = new Location();

            myObject.ID = myDataRecord.GetInt32(myDataRecord.GetOrdinal("locationId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LocationName")))
                myObject.LocationName = myDataRecord.GetString(myDataRecord.GetOrdinal("LocationName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Address01")))
                myObject.Address01 = myDataRecord.GetString(myDataRecord.GetOrdinal("Address01"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Address02")))
                myObject.Address02 = myDataRecord.GetString(myDataRecord.GetOrdinal("Address02"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("City")))
                myObject.City = myDataRecord.GetString(myDataRecord.GetOrdinal("City"));

            return myObject;

        }
        #endregion
    }
}
