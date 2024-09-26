using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Utilities.APIUtility
{
    public class APIUtility
    {
        private RestClient restClient;
        private RestRequest restRequest;
        private string path = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/Data/RequestedData.txt";
        public APIUtility(string url)
        {
            restClient = new RestClient(url);
        }
        public RestRequest GetRestRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }
        public T Get<T>(string endpoint, Dictionary<string, string> headers = null, Dictionary<string, string> parameter = null)
        {
            restRequest = GetRestRequest(endpoint, Method.Get);

            if (headers != null) AddHeaders(headers);
            if (parameter != null) AddParameter(parameter);

            var data = restClient.Execute(restRequest);
            //File.WriteAllText(path, data.Content);

            return JsonConvert.DeserializeObject<T>(data.Content);
        }
        public void AddHeaders(Dictionary<string, string> headers)
        {
            restRequest.AddHeaders(headers);
        }
        public void AddParameter(Dictionary<string, string> parameters)
        {
            foreach (KeyValuePair<string, string> key in parameters)
            {
                restRequest.AddParameter(key.Key, key.Value);
            }
        }
    }
}
