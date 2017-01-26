using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.FitnessSchedule.Models;
using VelocityCoders.FitnessSchedule.Models.Collections;
using VelocityCoders.FitnessSchedule.Models.Enums;
using System.Data.SqlClient;
using System.Data;

namespace VelocityCoders.FitnessSchedule.DAL
{
    public class FitnessClassDAL
    {
        #region INSERT AND UPDATE

        public static int Save(FitnessClass fitnessClassToSave)
        {
            int result = 0;

            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (fitnessClassToSave.FitnessClassId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fitnessClassToSave.FitnessClassId);
                    myCommand.Parameters.AddWithValue("@FitnessClassName", fitnessClassToSave.FitnessClassName);




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

        public static bool Delete(int fitnessClassId)
        {
            int result = 0;

            using (SqlConnection MyConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteFitnessClass", MyConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fitnessClassId);

                    MyConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                MyConnection.Close();

            }
            return result > 0;

        }
        #endregion
        public static FitnessClassCollection GetCollection()
        {
            FitnessClassCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new FitnessClassCollection();
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



        public static FitnessClass GetItem(int fitnessClassId)
        {
            FitnessClass tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetFitnessClass", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@FitnessClassId", fitnessClassId);

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

        #region Helper Mathod
        private static FitnessClass FillDataRecord(IDataRecord myDataRecord)
        {
            FitnessClass myObject = new FitnessClass();

            myObject.FitnessClassId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FitnessClassId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FitnessClassName")))
                myObject.FitnessClassName = myDataRecord.GetString(myDataRecord.GetOrdinal("FitnessClassName"));


            return myObject;
        }

        #endregion
    }
}