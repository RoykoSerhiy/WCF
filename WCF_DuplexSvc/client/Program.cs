using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using client.ServiceReference1;
using System.ServiceModel;

namespace client
{
    public class CallbackHandler : IDuplexSvcCallback
    {
        static InstanceContext site = new InstanceContext(new CallbackHandler());
        public static DuplexSvcClient proxy = new DuplexSvcClient(site);

        public void ReceiveTime(string str)
        {
            Console.WriteLine("Receive message :\n" + str);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CallbackHandler.proxy.ReturnTime(2, 5);
            Console.ReadKey();
        }
    }
}
