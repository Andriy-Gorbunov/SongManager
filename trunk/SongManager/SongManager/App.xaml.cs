using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SongManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public SQLiteConnection Connection { get; private set; }

        public const string SqlFileName = "songs.db";

        public new static App Current { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Current = this;

            base.OnStartup(e);

            SQLiteConnection.CreateFile(SqlFileName);
            Connection = new SQLiteConnection($"Data Source = {SqlFileName}");
            Connection.Open();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Connection?.Close();
            Connection = null;

            base.OnExit(e);
        }
    }
}
