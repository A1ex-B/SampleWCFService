using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DB
{
    public class ReceiptsRepository : IReceiptsRepository
    {
        private readonly string _connectionString;
        public ReceiptsRepository(string connectionString)
        {
            _connectionString = connectionString;
            SetMappingForReceiptModel();
        }
        private void SetMappingForReceiptModel()
        {
            var columnMaps = new Dictionary<string, string>
            {
                { "cheque_id", "Id" },
                { "cheque_number", "Number" },
                { "summ", "Summ" },
                { "discount", "Discount" },
                { "articles", "Articles" }
            };
            var mapper = new Func<Type, string, PropertyInfo>((type, columnName) =>
            {
                if (columnMaps.ContainsKey(columnName))
                {
                    return type.GetProperty(columnMaps[columnName]);
                }
                else
                    return type.GetProperty(columnName);
            });
            var receiptMap = new CustomPropertyTypeMap(typeof(ReceiptModel),
                (type, columname) => mapper(type, columname)
                );
            SqlMapper.SetTypeMap(typeof(ReceiptModel), receiptMap);
        }
        public async Task<int> SaveReceipt(ReceiptModel receipt)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new StringBuilder();
                string command = "exec save_cheques @id, @number, @summ, @discount, @articles";
                ;
                return await connection.ExecuteAsync(command, new
                {
                    id = receipt.Id,
                    number = receipt.Number,
                    summ = receipt.Summ,
                    discount = receipt.Discount,
                    articles = String.Join(";", receipt.Articles)
                });
            }
        }
        public async Task<ReceiptModel[]> GetLastReceipts(int number)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new StringBuilder();
                string command = "exec get_cheques_pack @num";
                ;
                var last = await connection.QueryAsync<ReceiptModel>(command, new
                {
                    num = number
                });
                return last.ToArray();
            }
        }
    }
}
