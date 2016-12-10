using RadioEtherInternetAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RadioEtherMonitor.Commands
{
    public class LoadRadiostationsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly HashSet<string> strings = new HashSet<string>();
        private readonly HashSet<AggregatorType> aggregators = new HashSet<AggregatorType>();

        public LoadRadiostationsCommand()
        {
            foreach (var agg in Enum.GetValues(typeof(AggregatorType)))
            {
                strings.Add(agg.ToString());
                aggregators.Add((AggregatorType)agg);
            }
        }

        public bool CanExecute(object parameter)
        {
            string argument = parameter.ToString();
            return string.IsNullOrWhiteSpace(argument) || strings.Contains(argument);
        }

        public void Execute(object parameter)
        {
            AggregatorType aggregator;
            string argument = parameter.ToString();
            HashSet<AggregatorType> typesToLoad;
            if (string.IsNullOrWhiteSpace(argument))
            {
                typesToLoad = aggregators;
            }
            else if (Enum.TryParse(parameter.ToString(), out aggregator))
            {
                typesToLoad = new HashSet<AggregatorType>();
                typesToLoad.Add(aggregator);
            }
            else
            {
                return;
            }
            var radiostations = RadioEtherInternetAPI.APIFactory.GetAPI().LoadRadiostations(typesToLoad);
            MessageBox.Show(string.Concat(radiostations.Select(r => r.Name + ", ")));
        }
    }

}
