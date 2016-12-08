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

        List<Radiostation> LoadRadiostations();

        List<string> LoadSongs(Aggregator site, Uri Archive);
    }
}
