using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI.Implementation
{
    public partial class RadioEtherInternetImpl : IRadioEtherInternetAPI
    {
        private readonly IWebClientProxy webClient;

        public RadioEtherInternetImpl(IWebClientProxy webClient)
        {
            this.webClient = webClient;
        }

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

        public List<Radiostation> LoadRadiostations(HashSet<AggregatorType> radiostationTypes)
        {
            List<Radiostation> result = new List<Radiostation>();
            foreach (var type in radiostationTypes)
            {
                switch (type)
                {
                    case AggregatorType.RadioIUa:
                        result.AddRange(GetAllRadioIUAUkr());
                        break;
                    //case AggregatorType.RadioscopeInUa:
                        // not supported yet
                      //  break;
                    default:
                        // not added to this switch. maybe a throw?
                        break;
                }
            }
            return result;
        }

        public List<string> LoadSongs(AggregatorType site, Uri Archive)
        {
            throw new NotImplementedException();
        }
    }
}
