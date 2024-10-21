using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.data.Abstract;
using test.data.Context;
using test.entity.Entities;

namespace test.data.Concrete
{
    public class RequestReadRepository : ReadRepository<Request>, IRequestReadRepository
    {
        public RequestReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
