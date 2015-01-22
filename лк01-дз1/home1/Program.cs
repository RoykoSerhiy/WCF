using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace home1
{
    [ServiceContract]
    public interface IStart
    {
        [OperationContract]
        string TotalSpace(string diskName);
        [OperationContract]
        string FreeSpace(string diskName);
    }
    public class Start : IStart
    {
        public string TotalSpace(string diskName)
        {
            try
            {
                
                DriveInfo di = new DriveInfo(diskName.Substring(0 , 1));
                string totalSpace = di.TotalSize.ToString();
                return totalSpace + " Bytes";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public string FreeSpace(string diskName)
        {
            try
            {
                DriveInfo di = new DriveInfo(diskName.Substring(0,1));
                string freeSpace = di.TotalFreeSpace.ToString();
                return freeSpace + " Bytes";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(Start));
            
            sh.Open();
            Console.WriteLine("Press Enter");
            Console.ReadLine();
            sh.Close();
        }
    }
}
