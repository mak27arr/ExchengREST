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
            Task<string> t = a.CreateOrder("ETHBTC", "sell", "limit", "GTC", 0.001, 1);
            //отримуєм результат
            Console.WriteLine(t.Result.ToLower());

            //FcoinCom f = new FcoinCom("6df9026188f64e879aa9039c2d013217", "d33d7a6aea05499a89ee8fc2eccfca4f");
            //Console.WriteLine(f.CreateOrder("","","","",0,0));
            Console.ReadLine();
        }
    }
}
