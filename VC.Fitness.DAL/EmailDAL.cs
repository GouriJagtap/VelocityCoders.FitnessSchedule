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
    public class EmailDAL
    {
        public static EmailCollection GetCollection()
        {
            EmailCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EmailCollection();
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

        private static Email FillDataRecord(IDataRecord myDataRecord)
        {
            Email myObject = new Email();

            myObject.EmailId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EmailId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeId")))
                myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("InstructorId")))
                myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EmailAddress")))
                myObject.EmailAddress = myDataRecord.GetString(myDataRecord.GetOrdinal("EmailAddress"));

            
            return myObject;
        }
        public static Email GetItem(int emailId)
        {
            Email tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEmail", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
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
    }
}
