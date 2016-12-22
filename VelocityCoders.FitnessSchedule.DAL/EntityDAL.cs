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
    public class EntityDAL
    {

        public static EntityCollection GetCollection()
        {
            EntityCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntity", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EntityCollection();
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

        private static Entity FillDataRecord(IDataRecord myDataRecord)
        {
            Entity myObject = new Entity();

            myObject.EntityId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityName")))
                myObject.EntityName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayName")))
                myObject.DisplayName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            return myObject;
        }

        public static bool Delete(int entityId)
        {
            int result = 0;

            using (SqlConnection MyConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntity", MyConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);

                    MyConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                MyConnection.Close();

            }
            return result > 0;

        }

    }
}
