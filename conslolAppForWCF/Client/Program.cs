using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Client
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, string c,int b);
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChannelFactory<IMyMath> factory = new ChannelFactory<IMyMath>(
                    new WSHttpBinding(),
                    new EndpointAddress("http://localhost/MyMath/Ep1")
                    );
                IMyMath channel = factory.CreateChannel();
                int a;
                string c;
                int b;
                a = Convert.ToInt32(Console.ReadLine());
                c = Console.ReadLine();
                b = Convert.ToInt32(Console.ReadLine());
                Console.ReadLine();
                
                int result = channel.Add(a, c, b);
                if(result == -2)
                {
                    Console.WriteLine("На нуль ділити не можна ****!!!");
                }
                Console.WriteLine("result: {0}", result);
                Console.WriteLine("Для завершения нажмите <ENTER>\n");
                Console.ReadLine();
                factory.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
