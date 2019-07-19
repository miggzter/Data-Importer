using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Data_Importer.Models
{
    public class Importer
    {
        public static void main()
        {

            string[] s = new string[]
            {
                "https://azure.microsoft.com/api/v2/pricing/virtual-machines-base-three-year/calculator/?culture=en-au&discount=mosp&v=20190604-1604-49924",
                "https://azure.microsoft.com/api/v2/pricing/virtual-machines-base/calculator/?culture=en-au&discount=mosp&v=20190604-1604-49924",
                "https://azure.microsoft.com/api/v2/pricing/virtual-machines-base-one-year/calculator/?culture=en-au&discount=mosp&v=20190604-1604-49924"
            };

            for (int x = 0; x < s.Length; x++)
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(s[x]);
                WebResponse response = hwr.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                JObject json = JObject.Parse(responseFromServer);
                JObject offers = (JObject)json["offers"];

                foreach (KeyValuePair<string, JToken> node in offers)
                {
                    int i = 1;
                }

            }
        }
    }
}
