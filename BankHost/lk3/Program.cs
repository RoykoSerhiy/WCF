using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace lk3
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        void ToDeposit(double sum);
        [OperationContract]
        double GetBalance();
    }
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class BankService : IBankService
    {
        static int id = 0;
        public double Balance;

        public BankService()
        {
            ++id;
            Console.WriteLine("Cоздан счет № " + id.ToString());

        }
        public void ToDeposit(double sum)
        {
            Balance += sum;
        }
        public double GetBalance()
        {
            return Balance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(BankService));
            sh.Open();
            Console.WriteLine("Press enter to end...");
            Console.ReadLine();
            sh.Close();
        }
    }
}
