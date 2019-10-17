using ExchengeREST.REST.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchengeREST.REST.Classes
{
    class FcoinCom: WebConector
    {
        public FcoinCom(string username, string password)
        {
            baseUrl = "https://api.fcoin.com/v2";
            this.username = username;
            this.password = password;
        }
        public async Task<string> CreateOrder(string symbol, string side, string type, string timeInForce, double quantity, double price)
        {
            //string jsonData = @"{""symbol"":""" + symbol + @""",""side"":""" + side + @""",""type"":""" + type + @""",""timeInForce"",""" + timeInForce + @""",""quantity"",""" + quantity.ToString() + @""",""price"",""" + price.ToString() + @"""}";
            //await ReqwestPOSTAsync(baseUrl + "/orders", jsonData);
            return await ReqwestGetAsync(baseUrl + "/accounts/balance");
        }

    }
}
