using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI.Implementation
{
    public interface IWebClientProxy
    {
        string DownloadString(string address);
        string DownloadString(Uri address);
    }
}
