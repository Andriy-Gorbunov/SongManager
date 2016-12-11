using RadioEtherInternetAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RadioEtherMonitor.Commands
{
    public class LoadPerformancesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IPerformancesData data;

        public LoadPerformancesCommand(IPerformancesData data)
        {
            this.data = data;
        }

        public bool CanExecute(object parameter)
        {
            return true; // data.SelectedRadiostation != null && data.SelectedRadiostation.Archive != null && !string.IsNullOrWhiteSpace(data.SelectedRadiostation.Archive.AbsoluteUri);
        }

        public void Execute(object parameter)
        {
            string day = data.SelectedDay; // temporary solution. Use data calculation.

            data.Performances = new ObservableCollection<ExtPerformance>(
                RadioEtherInternetAPI.APIFactory.GetAPI().LoadPerformances(
                    data.SelectedRadiostation.Site, data.SelectedRadiostation.Archive, day == "Yesterday" ? DateTime.Now.AddDays(-1) : DateTime.Now.AddDays(-2))
                    .Select(p => new ExtPerformance()
                    {
                        Performer = p.Performer,
                        Song = p.Song,
                        Language = TryGetLanguageByTitle(p.Song),
                        Country = "unknown",
                        Duration = "unknown"
                    }).ToList());
        }

        private string TryGetLanguageByTitle(string title) // TODO: do this another way
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return string.Empty;
            }
            if (title.IndexOfAny(new char[] { 'і', 'ї', 'є' }) != -1)
            {
                return "Українська";
            }
            if (title.IndexOfAny(new char[] { 'ы', 'э', 'ъ', 'ё' }) != -1)
            {
                return "Російська";
            }
            return string.Empty;
        }
    }
}
