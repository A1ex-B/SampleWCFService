using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WCFService
{
    [ServiceContract()]
    public interface IService
    {
        [OperationContract()]
        Task PutReceiptAsync(Receipt receipt);
        Task GetReceiptsAsync(int number);
    }
}
