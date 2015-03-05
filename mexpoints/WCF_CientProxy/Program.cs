using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_CientProxy.ServiceReference1;

namespace WCF_CientProxy
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMathClient proxy = new MyMathClient();
            int res = proxy.Add(5, "+", 5);
            Console.WriteLine("Sum = {0}" , res);
            Console.WriteLine("Press Enter");
            Console.ReadLine();
        }
    }
}
