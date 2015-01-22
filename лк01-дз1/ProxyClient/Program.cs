using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxyClient.ServiceReference1;

namespace ProxyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int chose = 9;
                StartClient sc = new StartClient();
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
                                Console.WriteLine(sc.TotalSpace(name));
                            }
                            break;
                        case 2:
                            {
                                Console.WriteLine("Enter disk Letter");
                                string name = Console.ReadLine();
                                Console.WriteLine(sc.FreeSpace(name));
                            }
                            break;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
