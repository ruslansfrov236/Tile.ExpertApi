using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.data.Abstract;
using test.data.Context;
using test.entity.Entities.Customers;

namespace test.data.Concrete
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {

        readonly private AppDbContext _context;

        public WriteRepository(AppDbContext context)
        {
            _context = context;
        }

        private DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;

        }

        public async Task<bool> AddRangeAsync(List<T> data)
        {
            await Table.AddRangeAsync(data);
            return true;
        }

        public bool Remove(T model)
        {
          
            EntityEntry<T> entityEntry = Table.Remove(model);

            return entityEntry.State == EntityState.Deleted;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T? entityEntry = await Table.FindAsync(Guid.Parse(id));

            if (entityEntry == null)
                return false;

            return Remove(entityEntry);
        }

        public  bool RemoveRange(List<T> data)
        {
            Table.RemoveRange(data);

            return true;
        }

        public async Task<int> SaveAsync()
        =>  await _context.SaveChangesAsync();

        public  bool Update(T model)
        {
            EntityEntry<T> entity = Table.Update(model);
            return entity.State == EntityState.Modified;

        }
    }
}
