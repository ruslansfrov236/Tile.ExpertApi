using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities.Customers;
using test.entity.Entities.Identity;

namespace test.entity.Entities
{
    public class Wishlist: BaseEntity
    {


        public bool isWishlist {  get; set; }   
        public AppUser User { get; set; }

        public string UserId { get; set; } 
        public int Quantity { get; set; }   
    }
}
