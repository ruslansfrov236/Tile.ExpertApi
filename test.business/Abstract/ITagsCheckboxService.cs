using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.TagsCheckbox;
using test.entity.Entities;

namespace test.business.Abstract
{
    public interface ITagsCheckboxService
    {
        Task<List<TagsCheckboxes>> GetAll();
     
        Task<bool> Create( CreateTagsCheckboxDto model );
        Task<bool> Update( UpdateTagsCheckboxDto model);

        Task<TagsCheckboxes> GetById(string id);
      
        Task<bool> Delete(string id );  
    }
}
