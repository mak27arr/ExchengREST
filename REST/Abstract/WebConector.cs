using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExchengeREST.REST.Abstract
{
    public abstract class WebConector
    {
        protected string baseUrl {get; set;}
        protected string username { get; set; }
        protected string password { get; set; }

        private HttpClient httpClient;
        private WebRequest request;
        protected string ReqwestPOST(string url,string data)
        {
            HttpContent content = new HttpContent();
            HttpResponseMessage response = await client.PostAsJsonAsync("api/products", product);
            response.EnsureSuccessStatusCode();
            // return URI of the created resource.
            //request = HttpWebRequest.Create(url+data);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.ContentLength = data.Length;
            //request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username+":"+password));
            //using (Stream webStream = request.GetRequestStream())
            //using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
            //{
            //    requestWriter.Write(data);
            //}

            //Task<WebResponse> requstTask = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse,
            //                                    request.EndGetResponse,
            //                                    null);
            //requstTask.ContinueWith(task =>
            //{
            //    try
            //    {
            //        return (HttpWebResponse)task.Result;
            //    }catch(Exception ex)
            //    {
            //        Debug.WriteLine(ex);
            //        return (HttpWebResponse)task.Result;
            //    }
            //});
            //try
            //{
            //    Console.WriteLine("heder" + requstTask.Result.Headers);
            //    Console.WriteLine("response" + requstTask.Result.ContentType);
            //    StreamReader reader = new StreamReader(requstTask.Result.GetResponseStream());

            //    return reader.ReadToEnd();
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex);
            //    return "";
            //}
        }

    }
}
