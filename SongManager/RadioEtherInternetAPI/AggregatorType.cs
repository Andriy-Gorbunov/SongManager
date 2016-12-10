using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI
{
    public enum AggregatorType
    {
        [Description("Радіоскоп")]
        //[Url("http://radioscope.in.ua/")]

        RadioscopeInUa,

        [Description("Радіо на i.ua")]
        //[Url("http://radio.i.ua/")]

        RadioIUa
    }
}
