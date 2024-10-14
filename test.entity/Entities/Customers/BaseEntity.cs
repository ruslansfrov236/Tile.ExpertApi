﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.entity.Entities.Customers
{
    public class BaseEntity
    {
        public Guid Id { get; set; }        

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}