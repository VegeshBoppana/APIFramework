using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;

namespace Utilities.APIUtility
{
    public enum HttpMethodType
    {
        GET,
        POST,
        PUT,
        PATCH,
        DELETE
    }

    public class APIHelper
    {
        private readonly RestClient _restClient;

        public APIHelper(string baseurl)
        {
            _restClient = new RestClient(baseurl);
        }

        //add the parameters also
        private async Task<RestResponse> SendRequest<T>(string endpoint, HttpMethodType method, T data = default(T), Dictionary<string, string> headers = null, Dictionary<string, string> queryParameters = null) where T : class
        {
            var request = new RestRequest(endpoint);
            switch (method)
            {
                case HttpMethodType.GET:
                    request.Method = Method.Get;
                    break;

                case HttpMethodType.POST:
                    request.Method = Method.Post;
                    if (data != null)
                    {
                        request.AddJsonBody(data);
                    }
                    break;

                case HttpMethodType.PUT:
                    request.Method = Method.Put;
                    if (data != null)
                    {
                        request.AddJsonBody(data);
                    }
                    break;
                case HttpMethodType.PATCH:
                    request.Method = Method.Patch;
                    if (data != null)
                    {
                        request.AddJsonBody(data);
                    }
                    break;
                case HttpMethodType.DELETE:
                    request.Method = Method.Delete;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(method), method, null);

            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }


            if (queryParameters != null)
            {
                foreach (var param in queryParameters)
                {
                    request.AddParameter(param.Key, param.Value, ParameterType.QueryString);
                }
            }


            var response = await _restClient.ExecuteAsync(request);
            return response;


          

        }



        public async Task<string?> GetResponseContent<T>(string endpoint, HttpMethodType method, T data = default(T), Dictionary<string, string> headers = null, Dictionary<string, string> queryParameters = null) where T : class
        {
            var response = await SendRequest(endpoint, method, data, headers, queryParameters);
            return response.Content;
        }

        public async Task<HttpStatusCode> GetResponseStatusCode<T> (string endpoint, HttpMethodType method, T data = default(T), Dictionary<string, string> headers = null, Dictionary<string, string> queryParameters = null) where T : class
        {
            var response = await SendRequest(endpoint, method, data, headers, queryParameters);
            return response.StatusCode;
        }

    }
}


