
using test.data.Abstract;
using test.data.Context;
using test.entity.Entities;

namespace test.data.Concrete
{
    public class TagsCheckboxWriteRepository : WriteRepository<TagsCheckboxes>, ITagsCheckboxWriteRepository
    {
        public TagsCheckboxWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
