using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_DuplexSvc
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IDuplexSvc
    {
        [OperationContract]
        void ReturnTime(int period, int number);
    }

    public interface IClientCallback
    {
        [OperationContract]
        void ReceiveTime(string str);
    }
}
