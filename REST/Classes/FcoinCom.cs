using ExchengeREST.REST.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ExchengeREST.REST.Classes
{
    class Response
    {
        public string status;
        public string data;
    }

    class FcoinCom: WebConector
    {
        public FcoinCom(string username, string password)
        {
            baseUrl = "https://api.fcoin.com/v2";
            this.username = username;
            this.password = password;
        }
        public async Task<string> CreateOrder(string symbol, string side, string type, double amount, double price)
        {
            List<Tuple<string, string>> heder = new List<Tuple<string, string>>();
            heder.Add(new Tuple<string, string>("FC-ACCESS-KEY", username));
            var json_serializer = new JavaScriptSerializer();
            var data = ReqwestGetAsync(baseUrl + "/public/server-time").Result;
            Response datatime = json_serializer.Deserialize<Response>(data);
            heder.Add(new Tuple<string, string>("FC-ACCESS-TIMESTAMP", datatime.data));
            string signature = "POST" + baseUrl.ToString() + "/orders" + datatime.data + "amount=" + amount + "&price=" + price + "&side=" + side + "&symbol=" + symbol + "&type=" + type;
            signature = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(signature));
            signature = CreateToken(signature, password);
            signature = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(signature));
            heder.Add(new Tuple<string, string>("FC-ACCESS-SIGNATURE", signature));
            string jsonData = @"{""symbol"":""" + symbol + @""",""amount"":""" + amount + @""",""price"":""" + price + @""",""side"":""" + side + @""",""symbol"":""" + symbol + @""",""type"":""" + type + @"""}";
            var realt = await ReqwestPOSTAsync(baseUrl + "/orders", jsonData,heder);

            heder.Clear();
            heder.Add(new Tuple<string, string>("FC-ACCESS-KEY", username));
            json_serializer = new JavaScriptSerializer();
            data = ReqwestGetAsync(baseUrl + "/public/server-time").Result;
            datatime = json_serializer.Deserialize<Response>(data);
            heder.Add(new Tuple<string, string>("FC-ACCESS-TIMESTAMP", datatime.data));
            signature = "GET" + baseUrl.ToString() + "/accounts/balance" + datatime.data;
            signature = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(signature));
            signature = CreateToken(signature, password);
            signature = Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(signature));
            heder.Add(new Tuple<string, string>("FC-ACCESS-SIGNATURE", signature));

            return await ReqwestGetAsync(baseUrl + "/accounts/balance",heder);
        }

        private string Encode(string input, byte[] key)
        {
            HMACSHA1 myhmacsha1 = new HMACSHA1(key);
            byte[] byteArray = Encoding.ASCII.GetBytes(input);
            MemoryStream stream = new MemoryStream(byteArray);
            return myhmacsha1.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
        }

        private string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }

    }
}
