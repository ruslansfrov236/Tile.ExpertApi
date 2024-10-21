using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.entity.Entities.Identity
{
    public class AppUser:IdentityUser<string>
    {
        public string FullName { get; set; }

        public ICollection<Wishlist> Wishlist { get; set; }
    }
}
