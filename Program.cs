using ExchengeREST.REST.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchengeREST
{
    class Program
    {
        static void Main(string[] args)
        {
            
            AltillyCom a = new AltillyCom("79e56b7617819ac99a2704a03d4d8a", "392b2d925326437e52cf32a89ce3fdd97f2e79ee");
            //створюєм запит
            Task<string> t = a.CreateOrder("BCHBTC", "sell", "limit", "GTC", 0.001, 1);
            //отримуєм результат
            Console.WriteLine(t.Result);

            FcoinCom f = new FcoinCom("3afdcf4a3adf4f32a360b46911936d32", "44d085bfdea74b93a21d7271863d68b5");
            //amount=100.0&price=100.0&side=buy&symbol=btcusdt&type=limit
            Console.WriteLine(f.CreateOrder("btcusdt", "buy","limit",100,100).Result);
            Console.ReadLine();
        }
    }
}
