using Microsoft.Data.SqlClient;

namespace CashControl
{
    internal static class Program
    {



        private static string _connectionString = "Server=(local);Database=CashControl; Trusted_Connection=True; TrustServerCertificate=True";

        private static SqlConnection db = new SqlConnection(_connectionString);

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Loginn());
        }



    }
}