using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    public class Service : IService
    {
        public Task GetReceiptsAsync(int number)
        {
            throw new NotImplementedException();
        }

        public Task PutReceiptAsync(Receipt receipt)
        {
            throw new NotImplementedException();
        }
    }
}
