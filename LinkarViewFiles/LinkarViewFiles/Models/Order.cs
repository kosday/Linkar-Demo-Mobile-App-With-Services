using System;
using System.Collections.Generic;

namespace LinkarViewFiles.Models
{
    public class Order
    {
        public string Code { get; set; }
        public string Customer { get; set; }
        public DateTime? Date { get; set; }
        public double ITotalOrder { get; set; }
        public string ICustomerName { get; set; }
        public List<MV_LstItems_CLkOrder> LstLstItems { get; set; }
    }

    public class MV_LstItems_CLkOrder 
    {
        public string Item { get; set; }
        public double Qty { get; set; }
        public double Price { get; set; }
        public double ITotalLine { get; set; }
        public string IItemDescription { get; set; }
        public double IItemStock { get; set; }

        public List<SV_LstPartial_CLkOrder> LstLstPartial { get; set; }
    }

    public class SV_LstPartial_CLkOrder 
    {
        public DateTime? DeliveryDateTime { get; set; }
        public double PartialQuantity { get; set; }
    }
}