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
            Task<string> t = a.CreateOrder("ETHBTC", "sell", "limit", "GTC", 0.001, 1);
            Console.WriteLine("djcnjsndjc");
            Console.WriteLine(t.Result);
            Console.WriteLine("djcnjsndjc");
            Console.ReadLine();
        }
    }
}
