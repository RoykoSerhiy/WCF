using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace mexpoints
{
    [ServiceContract]
    public interface IMyMath
    {
        [OperationContract]
        int Add(int a, string c, int b);

    }

    public class MyMath : IMyMath
    {

        public int Add(int a, string c, int b)
        {
            switch (c)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    {

                        return a * b;
                    }
                case "/":
                    {
                        if (a == 0 || b == 0)
                        {
                            return -2;
                        }
                        return a / b;
                    }
            }
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(MyMath));
            sh.Open();
            Console.WriteLine("Для завершения нажмите <ENTER>\n");
            Console.ReadLine();
            sh.Close();
            
        }
    }
}
