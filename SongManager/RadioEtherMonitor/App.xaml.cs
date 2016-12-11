using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlServerCe;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace RadioEtherMonitor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SqlCeConnection Connection { get; private set; }

        public const string SqlFileName = "songs.mdf";

        public new static App Current { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Current = this;

            base.OnStartup(e);


            var en = new SqlCeEngine($"Data Source = {SqlFileName}");
            if (!en.Verify())
            {
                en.CreateDatabase();

            }

            Connection = new SqlCeConnection($"Data Source = {SqlFileName}");
            
            Connection.Open();

            var script = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("RadioEtherMonitor.Model.edmx.sql")).ReadToEnd();
            foreach (var cmd in script.Split(new[] { "\r\nGO\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var cmdd = new SqlCeCommand(cmd, Connection);
                cmdd.ExecuteNonQuery();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Connection?.Close();
            Connection = null;

            base.OnExit(e);
        }
    }
}
