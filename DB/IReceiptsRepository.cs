using System.Collections.Generic;
using System.Threading.Tasks;

namespace DB
{
    public interface IReceiptsRepository
    {
        Task<ReceiptModel[]> GetLastReceipts(int number);
        Task<int> SaveReceipt(ReceiptModel receipt);
    }
}