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
        #region Commands
        public ICommand LoadRadiostations { get; private set; }
        public ICommand LoadPerformances { get; private set; }
        #endregion

        #region repositories
        private readonly RadioEtherData.ICountryRepository countryRepository;
        #endregion

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

        private void CreateCommands()
        {
            LoadRadiostations = new LoadRadiostationsCommand(this);
            LoadPerformances = new LoadPerformancesCommand(this);
        }

        public MainWindowVM(RadioEtherData.ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;

            CreateCommands();

            SelectedRadiostation = new Radiostation();
            SelectedDay = string.Empty;
            Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // just a test of reading countries
            var countries = countryRepository.GetAll();
            if (countries.Count < 1)
            {
                var wikiCountries = RadioEtherInternetAPI.APIFactory.GetAPI().LoadCountries();
                wikiCountries.ForEach(c => countryRepository.AddOrReplace(c.ISOCode, c.Name));
                countries = countryRepository.GetAll();
            }
        }
    }
}
