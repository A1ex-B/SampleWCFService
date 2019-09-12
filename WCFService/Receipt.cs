using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFService
{
    public class Receipt
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public decimal Summ { get; set; }
        public decimal Discount { get; set; }
        public string[] Articles { get; set; }
    }
}
