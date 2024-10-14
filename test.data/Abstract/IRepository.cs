using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities.Customers;

namespace test.data.Abstract
{
    public interface IRepository< T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
