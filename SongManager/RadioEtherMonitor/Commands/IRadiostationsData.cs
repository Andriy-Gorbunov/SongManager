using RadioEtherInternetAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherMonitor.Commands
{
    public interface IRadiostationsData
    {
        ObservableCollection<Radiostation> Radiostations { get; set; }
    }
}
