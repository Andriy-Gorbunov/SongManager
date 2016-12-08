using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI.Implementation
{
    internal class RadioEtherInternetImpl : IRadioEtherInternetAPI
    {
        public List<string> FindAssumedCountries(string performer)
        {
            throw new NotImplementedException();
        }

        public List<string> FindDuration(string song)
        {
            throw new NotImplementedException();
        }

        public List<string> FindSongText(string performer, string song)
        {
            throw new NotImplementedException();
        }

        public List<Radiostation> LoadRadiostations()
        {
            throw new NotImplementedException();
        }

        public List<string> LoadSongs(Aggregator site, Uri Archive)
        {
            throw new NotImplementedException();
        }
    }
}
