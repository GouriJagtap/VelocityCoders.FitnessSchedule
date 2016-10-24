using System.Configuration;

namespace VelocityCoders.FitnessSchedule.DAL
{
    //Returns the ConnectionString for the application
    public static class AppConfiguration
    {


        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }

        }
        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }
        }
    }
}