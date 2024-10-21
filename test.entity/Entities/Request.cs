using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities.Customers;

namespace test.entity.Entities
{
    public class Request:BaseEntity
    {
        public string Name { get; set; }    

        public string Phone { get; set; }   

        public string Email { get; set; }
       
        public string Description { get; set; }


    }
}
