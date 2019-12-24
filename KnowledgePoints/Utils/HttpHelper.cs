using RestSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;

namespace Com.Lqn.Knowledge.Utils
{
    public static class HttpHelper
    {
        public static string HttpPostForm(string url, NameValueCollection param, Hashtable header = null)
        {
            string result = string.Empty;
            try
            {
                RestClient client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                if (header != null)
                {
                    foreach (string key in header.Keys)
                    {
                        request.AddHeader(key, header[key].ToString());
                    }
                }

                foreach (string key in param.Keys)
                {
                    request.AddParameter(key, param[key]);
                }
                RestResponse response = (RestResponse)client.Execute(request);
                result = response.Content;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public static string HttpPost(string url, string postData, Dictionary<string, string> headers = null, string contentType = null, int timeout = 0, Encoding encoding = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (KeyValuePair<string, string> header in headers)
                    {
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                    }
                }
                if (timeout > 0)
                {
                    client.Timeout = new TimeSpan(0, 0, timeout);
                }
                using (HttpContent content = new StringContent(postData ?? "", encoding ?? Encoding.UTF8))
                {
                    if (contentType != null)
                    {
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                    }
                    using (HttpResponseMessage responseMessage = client.PostAsync(url, content).Result)
                    {
                        Byte[] resultBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
                        return Encoding.UTF8.GetString(resultBytes);
                    }
                }
            }
        }
    }
}
