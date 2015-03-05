using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCF_DuplexSvc
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class DuplexSvc : IDuplexSvc
    {
        public void ReturnTime(int period, int number)
        {
            DataValues src = new DataValues();
            src.callback = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            Thread t = new Thread
            (new ParameterizedThreadStart(src.SendTimeToClient));
            t.IsBackground = true;
            List<int> parameters = new List<int>();
            parameters.Add(period);
            parameters.Add(number);
            t.Start(parameters);
        }
        
    }
    public class DataValues
    {
        public IClientCallback callback = null;
        public void SendTimeToClient(object data)
        {
            int s = 60 - DateTime.Now.Second;
            Thread.Sleep(s * 1000);
            DateTime start = DateTime.Now;
            List<int> parameters = (List<int>)data;
            int period = parameters[0];
            int number = parameters[1];
            for (int i = 0; i < number;++i )
            {
                try
                {
                    Thread.Sleep(period * 1000);
                    TimeSpan result = DateTime.Now - start;
                    TimeSpan r = result.Add(new TimeSpan(0, 0, s));
                    callback.ReceiveTime(DateTime.Now.ToLongTimeString().ToString()
                        + " время работы со службой = " +
                        r.Minutes.ToString() + ":" +
                        r.Seconds.ToString());
                }
                catch (Exception ex)
                {
                    string str = ex.Message;
                }

            }
        }
    }
}
