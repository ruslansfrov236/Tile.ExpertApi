using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities.Enum;

namespace test.entity.Entities.Identity
{
    public class AppRole:IdentityRole<string>
    {
        public RoleModel RoleModel  { get; set; }   
    }
}
