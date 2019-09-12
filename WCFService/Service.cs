using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    public class Service : IService
    {
        private string _testField;

        public Service(string testField)
        {
            _testField = testField ?? throw new ArgumentNullException(nameof(testField));
        }

        public async Task GetReceiptsAsync(int number)
        {
            ;// throw new NotImplementedException();
        }

        public async Task PutReceiptAsync(Receipt receipt)
        {
            ; // Do something
        }
    }
}
