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
    public class EntityTypeDAL
    {

        public static EntityTypeCollection GetCollection()
        {
            EntityTypeCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollection);

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EntityTypeCollection();
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

        public static EntityTypeCollection GetCollection(EntityEnum entityName)
        {
            EntityTypeCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionByName);
                    myCommand.Parameters.AddWithValue("@EntityName", entityName.ToString());

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EntityTypeCollection();
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

        public static EntityTypeCollection GetCollection(int entityId)
        {
            EntityTypeCollection tempList = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("[dbo].[usp_GetEntityType]", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetCollectionById);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId.ToString());

                    myConnection.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new EntityTypeCollection();
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

        private static EntityType FillDataRecord(IDataRecord myDataRecord)
        {
            EntityType myObject = new EntityType();

            myObject.EntityTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityId")))
                myObject.EntityId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("EntityId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("EntityTypeName")))
                myObject.EntityTypeName = myDataRecord.GetString(myDataRecord.GetOrdinal("EntityTypeName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DisplayName")))
                myObject.DisplayName = myDataRecord.GetString(myDataRecord.GetOrdinal("DisplayName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("CreateDate")))
            //    myObject.FirstName = myDataRecord.GetString(myDataRecord.GetOrdinal("CreateDate"));

            return myObject;
        }

        public static EntityType GetItem(int entityTypeId)
        {
            EntityType tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryID", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeId);

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

        public static int Save(int entityId, EntityType entityTypeToSave)
        {
            int result = 0;

            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (entityTypeToSave.EntityTypeId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntityType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", queryId);
                    myCommand.Parameters.AddWithValue("@EntityId", entityId);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeToSave.EntityTypeId);

                    if (entityTypeToSave.EntityTypeName != null)
                        myCommand.Parameters.AddWithValue("@EntityTypeName", entityTypeToSave.EntityTypeName);

                    if (entityTypeToSave.DisplayName != null)
                        myCommand.Parameters.AddWithValue("@DisplayName", entityTypeToSave.DisplayName);

                    if (entityTypeToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", entityTypeToSave.Description);

                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;
        }

        public static bool Delete(int entityTypeId)
        {
            int result = 0;

            using (SqlConnection MyConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteEntityType", MyConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@EntityTypeId", entityTypeId);

                    MyConnection.Open();
                    result = myCommand.ExecuteNonQuery();

                }
                MyConnection.Close();

            }
            return result > 0;

        }
    }
}
