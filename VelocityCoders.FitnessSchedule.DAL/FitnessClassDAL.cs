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

            private static FitnessClass FillDataRecord(IDataRecord myDataRecord)
            {
                FitnessClass myObject = new FitnessClass();

                myObject.FitnessClassId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("FitnessClassId"));

                if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("FitnessClassName")))
                    myObject.FitnessClassName = myDataRecord.GetString(myDataRecord.GetOrdinal("FitnessClassName"));

                //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("InstructorId")))
                //    myObject.EntityTypeName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeName"));

                //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EmailAddress")))
                //    myObject.EmailAddress = myDataRecord.GetString(myDataRecord.GetOrdinal("EmailAddress"));

                //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
                //    myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("CreateDate"));

                return myObject;
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

    }
}
