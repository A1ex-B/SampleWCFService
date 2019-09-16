using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace DB
{
    public class FakeRepository : IReceiptsRepository
    {
        private readonly string _pathToRepo;
        public FakeRepository(string pathToRepo)
        {
            _pathToRepo = pathToRepo ?? throw new ArgumentNullException(nameof(pathToRepo));
            try
            {
                if (!Directory.Exists(_pathToRepo))
                {
                    Directory.CreateDirectory(_pathToRepo);
                }
            }
            catch (Exception ex)
            {
                throw new DirectoryNotFoundException($"Cant find or create directory {pathToRepo}", ex);
            }
        }

        public async Task<ReceiptModel[]> GetLastReceipts(int number)
        {
            var receiptCollection = new ReceiptModel[number];
            for (int i = 0; i < number; i++)
            {
                receiptCollection[i] = new ReceiptModel
                {
                    Id = Guid.NewGuid(),
                    Number = $"{i}",
                    Articles = "",
                    Discount = 0,
                    Summ = 0
                };
                await Task.Delay(10); // Типо ждём, пока база вернёт чек.
            }
            return receiptCollection;
        }

        public async Task<int> SaveReceipt(ReceiptModel receipt)
        {
            int rows;
            try
            {
                using (var writer = new StreamWriter(Path.Combine(_pathToRepo, $"{DateTime.Now.Ticks:X16}.txt")))
                {
                    await writer.WriteAsync(JsonConvert.SerializeObject(receipt));
                }
                rows = 1;
            }
            catch (Exception)
            {
                rows = 0;
            }
            
            return rows;
        }
    }
}
