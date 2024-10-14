using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.Tags;
using test.entity.Entities;

namespace test.business.Abstract
{
    public interface ITagsService 
    {
       
        Task<List<Tags>> GetAsync();  
        Task<Tags> GetAllByIdAsync(string id );

        Task<bool> Create(CreateTagsDto model);
        Task<bool> Update(UpdateTagsDto model);

        Task<bool> DeleteAsync(string id );
        Task<List<Tags>> GetFilter(string? search);

    }
}
