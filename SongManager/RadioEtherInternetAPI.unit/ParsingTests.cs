using Moq;
using RadioEtherInternetAPI.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RadioEtherInternetAPI.unit
{
    public class ParsingTests
    {
        private string GetHtmlFromResources(string resourceName)
        {
            string fullResourceName = "RadioEtherInternetAPI.unit.Resources." + resourceName;
            var _assembly = Assembly.GetCallingAssembly();
            var x = _assembly.GetManifestResourceNames();
            using (var _textStreamReader = new StreamReader(_assembly.GetManifestResourceStream(fullResourceName)))
            {
                return _textStreamReader.ReadToEnd();
            }
        }

        [Fact]
        public void LoadRadiostationsRadioIUATest()
        {
            string htmlMainRadioIUA = GetHtmlFromResources("radio-i-ua_ukr.html");

            var mockWebClient = new Mock<IWebClientProxy>();

            var implementation = new RadioEtherInternetImpl(mockWebClient.Object);

            var radiostations = implementation.GetOnePageRadiostationsRadioIUAUkr(htmlMainRadioIUA);

            Assert.NotNull(radiostations);
            Assert.NotEmpty(radiostations);
            Assert.Equal(10, radiostations.Count);

            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Хіт FM" && r.Archive.AbsoluteUri == "http://radio.i.ua/hit.fm/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "NRJ Україна (ex Europa plus)" && r.Archive.AbsoluteUri == "http://radio.i.ua/nrj/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Російське радіо" && r.Archive.AbsoluteUri == "http://radio.i.ua/russkoe.radio/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Kiss FM" && r.Archive.AbsoluteUri == "http://radio.i.ua/kiss.fm/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Radio ROKS" && r.Archive.AbsoluteUri == "http://radio.i.ua/radio.roks/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Шансон" && r.Archive.AbsoluteUri == "http://radio.i.ua/shanson/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Ретро FM" && r.Archive.AbsoluteUri == "http://radio.i.ua/retro.fm/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Авторадіо" && r.Archive.AbsoluteUri == "http://radio.i.ua/avtoradio/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Радіо Relax" && r.Archive.AbsoluteUri == "http://radio.i.ua/radiorelax.com.ua/" && r.Site == AggregatorType.RadioIUa);
            Assert.Contains<Radiostation>(radiostations, r => r.Name == "Люкс ФМ" && r.Archive.AbsoluteUri == "http://radio.i.ua/luxfm/" && r.Site == AggregatorType.RadioIUa);
        }

    }
}
