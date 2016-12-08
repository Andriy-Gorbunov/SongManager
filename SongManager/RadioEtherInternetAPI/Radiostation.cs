using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioEtherInternetAPI
{
    public class Radiostation
    {
        public string Name { get; set; }
        public Aggregator Site { get; set; }
        public Uri Archive { get; set; }
    }
}
