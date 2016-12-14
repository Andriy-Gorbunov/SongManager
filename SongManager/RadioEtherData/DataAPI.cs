using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherData
{
    public class DataAPI
    {
        private static readonly string connectionString;
        private const string DB_NAME = "songs.sdf";

        static DataAPI()
        {
            string databaseDirectory = $"{ Directory.GetCurrentDirectory() }\\Data_v1\\";
            if (!Directory.Exists(databaseDirectory))
            {
                Directory.CreateDirectory(databaseDirectory);
            }
            connectionString = $"Data Source = {databaseDirectory}{DB_NAME}";
            var en = new SqlCeEngine(connectionString);
            if (!en.Verify())
            {
                en.CreateDatabase();

            }
        }

        public static ModelContainer GetDbContext()
        {
            var container = new ModelContainer();
            container.Database.Connection.ConnectionString = connectionString;
            return container;
        }

        public static void ReCreateDatabaseContent()
        { 
            using (var connection = new SqlCeConnection(connectionString))
            {
                connection.Open();

                var script = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("RadioEtherData.Model.edmx.sql")).ReadToEnd();
                foreach (var cmd in script.Split(new[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    using (var cmdd = new SqlCeCommand(cmd, connection))
                    {
                        try
                        {
                            cmdd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Ignorable SQL exception: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
