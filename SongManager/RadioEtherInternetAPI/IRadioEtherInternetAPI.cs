using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI
{
    public interface IRadioEtherInternetAPI
    {
        List<string> FindSongText(string performer, string song);

        List<string> FindAssumedCountries(string performer);

        List<string> FindDuration(string song);

        List<Radiostation> LoadRadiostations(HashSet<AggregatorType> radiostationTypes);

        List<Performance> LoadPerformances(AggregatorType site, Uri Archive, DateTime date);
    }
}
