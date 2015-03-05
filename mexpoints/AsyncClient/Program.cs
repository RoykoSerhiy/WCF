using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncClient.ServiceReference1;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient proxy = new MyMathClient();
            IAsyncResult arAdd;

            arAdd = proxy.BeginTotal(100, 50, GetSumCallback, proxy);
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
        static void GetSumCallback(IAsyncResult ar)
        {
            MathResult mr = ((MyMathClient)ar.AsyncState).EndTotal(ar);
            Console.WriteLine("result: {0} {1} {2} {3}" , mr.sum , mr.subrt , mr.div , mr.mult);
        }
    }

}
