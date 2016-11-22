
namespace VelocityCoders.FitnessSchedule.Models
{
    public enum ExecuteTypeEnum
    {

        /// <summary>
        /// Defaults to none.
        /// </summary>
        None = 0,
        /// <summary>
        /// Inserts an Item into database.
        /// </summary>
        InsertItem = 10,

        /// <summary>
        /// 
        /// Update theitem in the 
        /// </summary>
        UpdateItem = 20,

        /// <summary>
        /// Delete an Item from the database
        /// </summary>
        DeleteItem = 30


    }
}