using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;
using System.ServiceModel;

namespace WindowsServiceHostDll
{
    public partial class Service1 : ServiceBase
    {
        internal static ServiceHost myServiceHost = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            if (myServiceHost != null)
            {
                myServiceHost.Close();
            }
            myServiceHost = new ServiceHost(typeof(MyMath));
            myServiceHost.Open();
        }

        protected override void OnStop()
        {
            myServiceHost.Close();
            myServiceHost = null;
        }
    }
}
