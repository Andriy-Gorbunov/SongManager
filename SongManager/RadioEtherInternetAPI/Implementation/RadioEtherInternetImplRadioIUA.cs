﻿using HtmlAgilityPack;
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
        public List<Radiostation> GetAllRadioIUAUkr()
        {
            List<Radiostation> result = new List<Radiostation>();
            List<Radiostation> onePageRadiostations = new List<Radiostation>();
            int index = 0;
            do
            {
                string htmlCode = webClient.DownloadString("http://radio.i.ua/ukr/?p=" + index++);
                onePageRadiostations = GetOnePageRadiostationsRadioIUAUkr(htmlCode);
                result.AddRange(onePageRadiostations);
            }
            while (onePageRadiostations.Count > 0);
            return result;
        }

        public List<Radiostation> GetOnePageRadiostationsRadioIUAUkr(string pageContent)
        {
            HtmlDocument doc = new HtmlDocument();
            using (var stream = new StringReader(pageContent))
            {
                doc.Load(stream);
            }
            var radioStationNodes = doc.DocumentNode.SelectNodes("//div[contains(concat(' ', normalize-space(@class), ' '), ' post_container ')]//h2/a");

            return radioStationNodes?.Select(node => new Radiostation()
            {
                Name = node.InnerText.Trim().Replace("&quot;", "\""),
                Archive = new Uri("http://radio.i.ua" + node.GetAttributeValue("href", "") + "archive/"),
                Site = AggregatorType.RadioIUa
            }).ToList() ?? new List<Radiostation>();
        }

        public List<Performance> GetPerformanceArchive(Uri archive, DateTime day)
        {
            List<Performance> result = new List<Performance>();
            string html = webClient.DownloadString(archive.AbsoluteUri + day.Day.ToString());

            HtmlDocument doc = new HtmlDocument();
            using (var stream = new StringReader(html))
            {
                doc.Load(stream);
            }
            var performanceNodes = doc.DocumentNode.SelectNodes("//ul[contains(concat(' ', normalize-space(@class), ' '), ' radio_program ')]//li/a");
            for (int index = 0; index < performanceNodes.Count / 2; index+=2)
            {
                result.Add(new Performance()
                {
                    Performer = performanceNodes[index].InnerText.Trim(),
                    Song = performanceNodes[index+1].InnerText.Trim()
                });
            }
            return result;
        }
    }
}
