using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DataContractServer
{
    [DataContract]
    public class MathResult
    {
        [DataMember]
        public double sum;
        [DataMember]
        public double subrt;
        [DataMember]
        public double div;
        [DataMember]
        public double mult;
    }
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        MathResult Total(int x, int y);
    }
    public class MyMath : IMyMath
    {
        public MathResult Total(int x, int y)
        {
            MathResult mr = new MathResult();
            mr.sum = x + y;
            mr.subrt = x - y;
            if (y != 0)
                mr.div = x / y;
            mr.mult = x + y;
            return mr;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.Open();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
            sh.Close();
        }
    }
}
