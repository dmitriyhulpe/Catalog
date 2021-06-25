using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Member> WishlistMember { get; set; }
        public List<Member> CartMember { get; set; }
        public Category Category { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
