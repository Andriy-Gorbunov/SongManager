using RadioEtherInternetAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherMonitor.Commands
{
    public interface IPerformancesData
    {
        ObservableCollection<ExtPerformance> Performances { get; set; }
        Radiostation SelectedRadiostation { get; }
        string SelectedDay { get; }
    }
}
