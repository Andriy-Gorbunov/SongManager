using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace RadioEtherData.Implementation
{
    public class CountryRepository : ICountryRepository, IDisposable
    {
        private readonly ModelContainer context;

        public CountryRepository()
        {
            context = DataAPI.GetDbContext();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void AddOrReplace(string ISOCode, string countryName)
        {
            var found = context.CountrySet.Where(c => c.IsoCode == ISOCode).ToList();
            if (found.Count < 1)
            {
                context.CountrySet.Add(new Country() { Id = Guid.NewGuid(), IsoCode = ISOCode, Name = countryName });
            }
            else
            {
                found.ForEach(f => f.Name = countryName);
                context.SaveChanges();
            }
        }

        public List<Country> GetAll()
        {
            return context.CountrySet.ToList();
        }
    }
}
