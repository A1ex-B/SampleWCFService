using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace WCFService
{
    public class Service : IService
    {
        private readonly IReceiptsRepository _receiptsRepository;

        public Service(IReceiptsRepository receiptsRepository)
        {
            _receiptsRepository = receiptsRepository ?? throw new ArgumentNullException(nameof(receiptsRepository));
        }

        public async Task<Receipt[]> GetReceiptsAsync(int number)
        {
            ReceiptModel[] result;
            try
            {
                Console.WriteLine($"Called {nameof(GetReceiptsAsync)}({number});");
                result = await _receiptsRepository.GetLastReceipts(number);
                return result.ConvertToReceiptArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка в методе {nameof(GetReceiptsAsync)}:");
                Console.WriteLine($"{ex.GetType()}:\n{ex.Message}");
                return null;
            }
        }

        public async Task PutReceiptAsync(Receipt receipt)
        {
            try
            {
                Console.WriteLine($"Called {nameof(PutReceiptAsync)}(...), receipt:\n{receipt}");
                var rows = await _receiptsRepository.SaveReceipt(receipt);
                Console.WriteLine($"Rows affected = {rows}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка в методе {nameof(PutReceiptAsync)}:");
                Console.WriteLine($"{ex.GetType()}:\n{ex.Message}");
            }
        }
    }
}
