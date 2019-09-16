using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DB
{
    public class ReceiptModel
    {
        [JsonProperty(Required = Required.Always)]
        public Guid Id { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Number { get; set; }
        [JsonProperty(Required = Required.Always)]
        public decimal Summ { get; set; }
        [JsonProperty(Required = Required.Always)]
        public decimal Discount { get; set; }
        [JsonProperty(Required = Required.Always)]
        public string Articles { get; set; }
    }
}
