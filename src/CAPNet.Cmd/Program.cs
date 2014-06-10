using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel.Syndication;
using System.Xml;

namespace CAPNet.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadNWS();

            //string xml = null;
            //var document = new XmlDocument();

            //try
            //{
            //    document.Load(@"c:\_dev\cap-net\test\nws-warning.xml");
            //}
            //catch (XmlException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //using (StringWriter sringWriter = new StringWriter())
            //{
            //    using (XmlTextWriter textWriter = new XmlTextWriter(sringWriter))
            //    {
            //        document.WriteTo(textWriter);
            //        xml = sringWriter.ToString();
            //    }
            //}

            //if (xml != null)
            //{
            //    var alert = XmlParser.Parse(xml);
            //}

            //Console.ReadLine();
        }

        static void ReadNWS()
        {
            var alerts = new List<Alert>();

            using (var reader = XmlReader.Create("http://alerts.weather.gov/cap/ok.atom"))
            {
                var feed = SyndicationFeed.Load(reader);

                foreach (var item in feed.Items)
                {
                    string url = item.Id;
                    Alert alert = GetXml(url);
                    alerts.Add(alert);
                }
            }

            foreach (var alert in alerts)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Sender: " + alert.Sender);
                Console.WriteLine("Note: " + alert.Note);

                foreach (var info in alert.Info)
                {
                    Console.WriteLine("  *******");
                    Console.WriteLine("  " + info.Headline);
                    Console.WriteLine("  Effective: " + info.Effective.ToString());
                    Console.WriteLine("  Expires: " + info.Expires.ToString());
                    Console.WriteLine("  Severity: " + (info.Severity.HasValue ? info.Severity.Value.ToString() : "n/a"));

                    string areas = String.Empty;

                    foreach (var area in info.Areas)
                    {
                        Console.WriteLine("  Area: " + area.Description);
                        areas += area.Description;
                    }

                    //if (info.Severity == Severity.Severe || info.Severity == Severity.Extreme)
                    //{
                    //    var eventRepository = new EventRepository();
                    //    var eventModel = new Event();
                    //    eventModel.Sender = alert.Sender;
                    //    eventModel.Alias = info.Event;
                    //    eventModel.DefaultMessage = info.Headline;
                    //    eventModel.Type = new EventType() { Id = 1 };
                    //    eventModel.EffectiveDateTime = info.Effective;
                    //    eventModel.ExpiresDateTime = info.Expires;
                    //    eventModel.Areas = areas;

                    //    eventRepository.Save(eventModel);
                    //}
                }
            }

            Console.WriteLine("End of process.");
            Console.ReadLine();
        }

        public static Alert GetXml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "text/xml";

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    string message = String.Format("GET failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }
                else
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(responseStream);

                        Alert alert = XmlParser.Parse(doc);

                        return alert;
                    }
                }
            }
        }

        static void ReadFromFeed(string url)
        {

        }
    }
}
