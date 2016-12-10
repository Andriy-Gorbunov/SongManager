using RadioEtherInternetAPI;
using RadioEtherMonitor.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RadioEtherMonitor
{
    public class MainWindowVM : NotifyPropertyChangedImpl, IRadiostationsData
    {
        public ICommand LoadRadiostationsList { get; private set; }

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

        public MainWindowVM()
        {
            LoadRadiostationsList = new LoadRadiostationsCommand(this);
            SelectedRadiostation = new Radiostation();
        }
    }
}
