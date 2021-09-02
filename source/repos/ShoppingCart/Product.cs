using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int ProductCost { get; set; }
        public bool Active { get; set; }
    }
}
