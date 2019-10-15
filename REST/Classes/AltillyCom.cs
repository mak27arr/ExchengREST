using ExchengeREST.Interfaces;
using ExchengeREST.REST.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchengeREST.REST.Classes
{

    enum Type
    {
        limit,
        market,
        stopLimit,
        stopMarket,
        tpLimit,
        tpMarket
    }

    public class AltillyCom : WebConector
    {
        public AltillyCom(string username,string password)
        {
            baseUrl = "https://api.altilly.com/api";
            this.username = username;
            this.password = password;
        }
        public async Task<string> CreateOrder(string symbol,string side,string type,string timeInForce,double quantity,double price)
        {
            string jsonData = @"{""symbol"":"""+ symbol + @""",""side"":"""+ side + @""",""type"":"""+ type + @""",""timeInForce"","""+ timeInForce + @""",""quantity"","""+ quantity.ToString() + @""",""price"","""+ price.ToString() + @"""}";
            return await ReqwestPOSTAsync(baseUrl + "/order",jsonData);
        }
    }
}
