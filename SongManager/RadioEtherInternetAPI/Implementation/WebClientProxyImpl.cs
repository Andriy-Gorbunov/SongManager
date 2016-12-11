using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI.Implementation
{
    internal class WebClientProxyImpl : IWebClientProxy
    {
        public string DownloadString(Uri address)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(address);
            }
        }

        public string DownloadString(string address)
        {
            using (var client = new WebClient())
            {
                return client.DownloadString(address);
            }
        }
    }
}
