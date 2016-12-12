using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherData
{
    public interface ICountryRepository
    {
        List<Country> GetAll();
        void AddOrReplace(string ISOCode, string countryName);
    }
}
