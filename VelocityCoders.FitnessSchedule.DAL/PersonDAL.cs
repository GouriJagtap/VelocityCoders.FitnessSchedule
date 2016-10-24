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
    }
}
