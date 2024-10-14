using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using test.data.Abstract;
using test.data.Context;
using test.entity.Entities.Customers;

namespace test.data.Concrete
{
    public class ReadRepository<T> : IReadRepository<T> where T :BaseEntity
    {
        readonly private AppDbContext _context;

        public ReadRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public IQueryable<T> GetAll(bool tracking = true)
        {

            var queryable = Table.AsQueryable();
            if (!tracking)
                queryable = Table.AsNoTracking();

            return queryable;

        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var queryable =  Table.AsQueryable();

            if(!tracking)
                queryable = Table.AsNoTracking();

            return await queryable.FirstOrDefaultAsync(q => q.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var queryable = Table.AsQueryable();

            if (!tracking)
                queryable = Table.AsNoTracking();

            return await queryable.FirstOrDefaultAsync(method);
        }

        public  IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var queryable = Table.AsQueryable();

            if (!tracking)
                queryable = Table.AsNoTracking();

            return  queryable.Where(method);   
        }
    }
}
