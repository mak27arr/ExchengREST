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

    public class AltillyCom : WebConector, IExchenge
    {
        public AltillyCom(string username,string password)
        {
            baseUrl = "https://api.altilly.com/api";
            this.username = username;
            this.password = password;
        }
        public string CreateOrder()
        {
            string jsonData = @"{""symbol"":""a"",""side"":""sell"",""type"":""limit"",""timeInForce"",""GTC"",""quantity"",""0.001"",""price"",""1""}";
            return ReqwestPOST(baseUrl + "/order",jsonData);
        }
    }
}
