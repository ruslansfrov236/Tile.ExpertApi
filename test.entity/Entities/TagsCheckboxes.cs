using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities.Customers;

namespace test.entity.Entities
{
    public  class TagsCheckboxes:BaseEntity
    {
        public Tags Tags { get; set; }  
        public Guid TagsId { get; set; }        
        public bool isChecked { get; set; }
    }
}
