using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace myService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            this.MyLog("Service Started");
        }

        protected override void OnStop()
        {
            this.MyLog("Service Stoped");
        }
        private void MyLog(string s)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("svclog.txt", true);
                s += "\t\t";
                s += DateTime.Now.ToLongTimeString();
                sw.WriteLine(s);
            }
            catch (Exception ex)
            {
                StreamWriter error = new StreamWriter("errors.txt", true);
                error.WriteLine(ex.Message);
                error.Close();
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
