using System;
using System.Data.SqlClient;

namespace WearMe.Database
{
    internal class AdvertsDatabase
    {
        SqlConnection sqlConnection;
        readonly string stringConnection = "Server=tcp:wearme.database.windows.net,1433;Initial Catalog=WearMe;Persist Security Info=False;User ID=klewinska;Password=Xamarin1221;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public AdvertsDatabase()
        {
            createConnection();
        }

        private void createConnection()
        {
            try
            {
                sqlConnection = new SqlConnection(stringConnection);
                sqlConnection.Open();
            } 
            catch(Exception ex)
            {
                ex.GetBaseException();
                throw new Exception("Cannot connect with database");
            }
        }
    }
}
