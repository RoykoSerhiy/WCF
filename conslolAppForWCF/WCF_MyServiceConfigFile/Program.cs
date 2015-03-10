using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCF_MyServiceConfigFile
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, int b);
    }
    public class MathService : IMyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MathService));
            sh.Open();
            Console.WriteLine("press enter to end\n");
            Console.ReadLine();
            sh.Close();
        }
    }
}
