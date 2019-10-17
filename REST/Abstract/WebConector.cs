using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExchengeREST.REST.Abstract
{
    public abstract class WebConector
    {
        protected string baseUrl {get; set;}
        protected string username { get; set; }
        protected string password { get; set; }

        private HttpClient httpClient = new HttpClient();
        protected async Task<string> ReqwestPOSTAsync(string url,string data)
        {
            httpClient.Timeout = TimeSpan.FromMinutes(10);
            return await Task.Run(() => {
                StringContent content = new StringContent(data);
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
                requestMessage.Content = content;
                HttpResponseMessage response = httpClient.SendAsync(requestMessage).Result;
                return response.Content.ReadAsStringAsync();
            });  
        }
        protected async Task<string> ReqwestGetAsync(string url)
        {
            httpClient.Timeout = TimeSpan.FromMinutes(30);
            return await Task.Run(() => {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
                HttpResponseMessage response = httpClient.SendAsync(requestMessage).Result;
                return response.Content.ReadAsStringAsync();
            });
        }

    }
}
