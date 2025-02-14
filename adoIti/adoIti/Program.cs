using System.Data;


using System.Data.SqlClient;

namespace adoIti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection  sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source = DESKTOP-592OS1T; Initial Catalog=cf_1;Integrated Security=True;trustservercertificate=true;";
            sqlConnection.Open();
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.ChangeDatabase("cf_2");
             sqlConnection.Close();
            Console.WriteLine("done");
        }
    }
}
