using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCF_ConsoleClient_OneWay.ServiceReference1;

namespace WCF_ConsoleClient_OneWay
{
    class Program
    {
        static void Main(string[] args)
        {
            ReplyClient proxy = new ReplyClient();
            //proxy.FastReply();
            proxy.SlowReply();

            Console.WriteLine("Enter numeric value");
            int val = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("You enter {0}", val);
            proxy.Close();
        }
    }
}
