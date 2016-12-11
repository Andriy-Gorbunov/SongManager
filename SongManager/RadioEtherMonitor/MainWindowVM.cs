using RadioEtherInternetAPI;
using RadioEtherMonitor.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RadioEtherMonitor
{
    public class MainWindowVM : NotifyPropertyChangedImpl, IRadiostationsData, IPerformancesData
    {
        public ICommand LoadRadiostations { get; private set; }
        public ICommand LoadPerformances { get; private set; }

        private ObservableCollection<Radiostation> radiostations = new ObservableCollection<Radiostation>();

        public ObservableCollection<Radiostation> Radiostations
        {
            get
            {
                return radiostations;
            }
            set
            {
                if (value != radiostations)
                {
                    radiostations = value;
                    NotifyPropertyChanged(nameof(Radiostations));
                }
            }
        }

        public Radiostation SelectedRadiostation { get; set; }

        public string Version { get; private set; }

        public string SelectedDay { get; set; }

        private ObservableCollection<ExtPerformance> performances = new ObservableCollection<ExtPerformance>();
        public ObservableCollection<ExtPerformance> Performances
        {
            get
            {
                return performances;
            }

            set
            {
                if (value != performances)
                {
                    performances = value;
                    NotifyPropertyChanged(nameof(Performances));
                }
            }
        }

        public MainWindowVM()
        {
            LoadRadiostations = new LoadRadiostationsCommand(this);
            LoadPerformances = new LoadPerformancesCommand(this);
            SelectedRadiostation = new Radiostation();
            SelectedDay = string.Empty;
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
