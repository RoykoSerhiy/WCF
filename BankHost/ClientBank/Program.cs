using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ClientBank.ServiceReference1;


namespace ClientBank
{
    class Program
    {
        static void Main(string[] args)
        {
            BankServiceClient proxy = new BankServiceClient();
            Console.WriteLine("Enter sum of deposit:");
            double sum = Convert.ToDouble(Console.ReadLine());
            double result = 0;

            while (sum > 0)
            {
                proxy.ToDeposit(sum);
                result = proxy.GetBalance();
                Console.WriteLine("Deposit = {0}", result);
                Console.WriteLine("Enter sum of Deposit:");
                sum = Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Press Enter to end...\n\n");
            Console.ReadLine();
        }
    }
}
