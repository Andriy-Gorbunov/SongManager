using RadioEtherInternetAPI.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI
{
    public static class APIFactory
    {
        public static IRadioEtherInternetAPI GetAPI()
        {
            return new RadioEtherInternetImpl();
        }
    }
}
