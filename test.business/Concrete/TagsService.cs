using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.business.Abstract;
using test.data.Abstract;
using test.entity.Dto.Tags;
using test.entity.Entities;

namespace test.business.Concrete
{
    public class TagsService : ITagsService
    {

        readonly private ITagsReadRepository _tagsReadRepository;
        readonly private ITagsWriteRepository _tagsWriteRepository;
        public TagsService( ITagsReadRepository tagsReadRepository, ITagsWriteRepository tagsWriteRepository)
        {
            _tagsReadRepository = tagsReadRepository;
            _tagsWriteRepository = tagsWriteRepository; 
        }
        public async Task<bool> Create(CreateTagsDto model)
        {
            await _tagsWriteRepository.AddAsync(new Tags() { Title=model.Title });
            await _tagsWriteRepository.SaveAsync();
            return true;    

        }

        public async Task<bool> DeleteAsync(string id)
        {
            var tags = await _tagsReadRepository.GetByIdAsync(id);
            if (tags == null) return false;

             _tagsWriteRepository.Remove(tags);
          await _tagsWriteRepository.SaveAsync();


            return true;
        }

        public async Task<Tags> GetAllByIdAsync(string id)
        => await _tagsReadRepository.GetByIdAsync(id);

        public async Task<List<Tags>> GetAsync()
        {
            List<Tags> tags =await  _tagsReadRepository.GetAll().ToListAsync();
            


            return tags;    
        }

        public async Task<List<Tags>> GetFilter(string? search)
        {
            var filter = await _tagsReadRepository.GetWhere(a => a.Title.ToLower().Contains(search.ToLower())).ToListAsync();

            if (!filter.Any())

                return null;

           
            return filter;
        }

        public async Task<bool> Update(UpdateTagsDto model)
        {
            var tags = await _tagsReadRepository.GetByIdAsync(model.Id);

            if(tags is null) return false;

            tags.Title = model.Title;
            
             _tagsWriteRepository.Update(tags);
            await _tagsWriteRepository.SaveAsync();

            return true;

        }
    }
}
