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
    public class InstructorDAL
    {
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

        private static Instructor FillDataRecord(IDataRecord myDataRecord)
        {
            Instructor myObject = new Instructor();

            myObject.InstructorId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("InstructorId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("PersonId")))
                myObject.PersonId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("PersonId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HireDate")))
                myObject.HireDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("HireDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("TermDate")))
                myObject.TermDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("TermDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
                myObject.CreateDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("CreateDate"));

            return myObject;
        }
        public static Instructor GetItem(int instructorID)
        {
            Instructor tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetInstructor", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@InstructorId", instructorID);

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

