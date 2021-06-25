using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Product> WishlistProduct { get; set; }
        public List<Product> CartProduct { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}