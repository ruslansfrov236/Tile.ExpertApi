using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities;
using test.entity.Entities.Customers;

namespace test.data.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tags> Tags { get; set; }
        public DbSet<Links> Links { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<History> History { get; set; } 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            TimeZoneInfo azerbaijanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Azerbaijan Standard Time");

            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, azerbaijanTimeZone);
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdatedDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, azerbaijanTimeZone);
                        break;
                    default:
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    
}
}
