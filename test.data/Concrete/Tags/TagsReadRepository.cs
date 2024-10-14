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
    public class TagsReadRepository : ReadRepository<Tags>, ITagsReadRepository
    {
        public TagsReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
