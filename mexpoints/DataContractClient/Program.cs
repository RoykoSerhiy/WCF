using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using DataContractClient.ServiceReference1;

namespace DataContractClient
{
    //[ServiceContract]
    //public interface IMyMath
    //{
    //    [OperationContract]
    //    int Add(int a, string c, int b);
    //}
   
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ChannelFactory<IMyMath> factory = new ChannelFactory<IMyMath>(
                //    new WSHttpBinding(),
                //    new EndpointAddress("http://localhost/MathService/ep1")
                //    );
                //IMyMath channel = factory.CreateChannel();

                MyMathClient proxy = new MyMathClient();
                MathResult mr = proxy.Total(35, 48);
                
                Console.WriteLine("result: {0} {1} {2} {3}" , mr.sum , mr.subrt , mr.div , mr.mult);
                Console.WriteLine("Для завершения нажмите <ENTER>\n");
                Console.ReadLine();
                //factory.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
}
