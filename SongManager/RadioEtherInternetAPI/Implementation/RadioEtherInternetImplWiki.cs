using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI.Implementation
{
    partial class RadioEtherInternetImpl
    {
        public List<Country> LoadCountries()
        {
            List<Country> result = new List<Country>();
            string html = webClient.DownloadString("https://uk.wikipedia.org/wiki/ISO_3166-1");

            HtmlDocument doc = new HtmlDocument();
            using (var stream = new StringReader(html))
            {
                doc.Load(stream);
            }
            var countriesCells = doc.DocumentNode.SelectNodes("//table[contains(concat(' ', normalize-space(@class), ' '), ' wikitable ')]/td");

            // TODO: return data from cells

            return result;
        }
    }
}
