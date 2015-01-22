using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    [ServiceContract]
    public interface IStart
    {
        [OperationContract]
        string TotalSpace(string diskName);
        [OperationContract]
        string FreeSpace(string diskName);
    }
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IStart> factory = new ChannelFactory<IStart>(
                    new WSHttpBinding(),
                    new EndpointAddress("http://localhost/DiskService/ep2")
                    );
            IStart channel = factory.CreateChannel();
            int chose = 9;
            while (chose != 0)
            {
                Console.WriteLine("1.Total Space \n 2.Free Space \n 0.Exit");
                chose = Convert.ToInt32(Console.ReadLine());
                switch (chose)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter disk Letter");
                            string name = Console.ReadLine();
                            Console.WriteLine(channel.TotalSpace(name));
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter disk Letter");
                            string name = Console.ReadLine();
                            Console.WriteLine(channel.FreeSpace(name));
                        }
                        break;
                }

            }
        }
    }
}
