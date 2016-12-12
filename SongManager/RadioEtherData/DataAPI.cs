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
    public static class DataAPI
    {
        private static string connectionString = $"Data Source = songs.sdf";

        static DataAPI()
        {
            var en = new SqlCeEngine(connectionString);
            if (!en.Verify())
            {
                en.CreateDatabase();

            }
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
