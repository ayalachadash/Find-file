using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        [IgnorSearch]
        public int  quantity { get; set; }
        public Product(int id, string name, int price, int quantity)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }
}
