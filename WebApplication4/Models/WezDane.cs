using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace WebApplication4.Models
{
    public class WezDane
    {
        private string resource = "http://api.football-data.org";
        public string queryString { get; set; } 
        public Dane  MojeDane()
        {
            Uri requestUri = new Uri(resource + queryString);
            HttpWebRequest req = WebRequest.Create(requestUri) as HttpWebRequest;
            req.Headers["X-Auth-Token"] = "64b77074a4404f459ef2f81aa0d2c29e";
            HttpWebResponse response1 = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(response1.GetResponseStream());
            string ligaJson = sr.ReadToEnd();
            Dane dane = JsonConvert.DeserializeObject<Dane>(ligaJson);
            return dane;
        }
    }
}