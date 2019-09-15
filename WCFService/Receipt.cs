using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace WCFService
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Summ { get; set; }
        public decimal Discount { get; set; }
        public string[] Articles { get; set; }
        public override string ToString()
        {
            var s = new StringBuilder();
            s.Append($"Id: {Id}\n");
            s.Append($"Number: {Number}\n");
            s.Append($"Summ: {Summ}\n");
            s.Append($"Discount: {Discount}\n");
            s.Append("Articles: [");
            for (int i = 0; i < Articles.Length; i++)
            {
                s.Append($"\"{Articles[i]}\"");
                if (i < Articles.Length - 1)
                {
                    s.Append(", ");
                }
            }
            s.Append("]\n");
            return s.ToString();
        }
        public static implicit operator ReceiptModel(Receipt r)
        {
            return new ReceiptModel
            {
                Articles = String.Join(";", r.Articles),
                Discount = r.Discount,
                Id = r.Id,
                Number = r.Number,
                Summ = r.Summ
            };
        }
        public static implicit operator Receipt(ReceiptModel rm)
        {
            return new Receipt
            {
                Articles = rm.Articles.Split(new char[] { ';' }),
                Discount = rm.Discount,
                Id = rm.Id,
                Number = rm.Number,
                Summ = rm.Summ
            };
        }
    }
    public static class ReceiptExtension
    {
        public static Receipt[] ConvertToReceiptArray(this ReceiptModel[] rm)
        {
            return rm.Select(m => (Receipt)m).ToArray();
        }
    }
}
