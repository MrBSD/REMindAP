using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace REMindAP.Services
{
    public class SlackService
    {
        private readonly Uri uri;
        private readonly Encoding encoding = new UTF8Encoding();

        public SlackService(string urlWithToken)
        {
            uri = new Uri(urlWithToken);
        }

        //Message using string
        public void PostMessage(string text, string username = null, string channel = null)
        {
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            PostMessage(payload);
        }

        private  void  PostMessage(Payload payload)
        {
            string payloadJson = JsonConvert.SerializeObject(payload);

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;

                var response =  client.UploadValues(uri, "POST", data);

                string responseText = encoding.GetString(response);
            }
        }
    }
}
