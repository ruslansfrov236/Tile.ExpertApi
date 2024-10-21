using System.Data.Entity;
using test.business.Abstract;
using test.data.Abstract;
using test.data.Context;
using test.entity.Dto.TagsCheckbox;
using test.entity.Entities;

namespace test.business.Concrete
{
    public class TagsCheckboxService : ITagsCheckboxService
    {

        readonly private ITagsCheckboxReadRepository _tagsCheckboxReadRepository;
        readonly private ITagsCheckboxWriteRepository _tagsCheckboxWriteRepository;
       

        public TagsCheckboxService(ITagsCheckboxReadRepository tagsCheckboxReadRepository,
                                   ITagsCheckboxWriteRepository tagsCheckboxWriteRepository)
        {
            _tagsCheckboxReadRepository = tagsCheckboxReadRepository;
            _tagsCheckboxWriteRepository = tagsCheckboxWriteRepository;
        }
       

        public async Task<bool> Delete(string id)
        {
            var tagsCheckboxes = await _tagsCheckboxReadRepository.GetByIdAsync(id);

            if (tagsCheckboxes == null)
            {
                throw new KeyNotFoundException("Not found ");

            }

            _tagsCheckboxWriteRepository.Remove(tagsCheckboxes);
            await _tagsCheckboxWriteRepository.SaveAsync();
            return true;
        }

        public async Task<List<TagsCheckboxes>> GetAll()
        {

           var tagsCheckboxes =  _tagsCheckboxReadRepository.GetAll()
                .Include(a=>a.Tags)
                
                .Select(a => new TagsCheckboxes() {
                    Id = a.Id,
                    Tags = a.Tags,
                    isChecked=a.isChecked,
                    TagsId=a.TagsId,
                    CreatedDate=a.CreatedDate,
                    UpdatedDate=a.UpdatedDate
                    
                }).ToList();

                return tagsCheckboxes ??  new List<TagsCheckboxes>(); 
          
            
        }


        public Task<TagsCheckboxes> GetById(string id)
        => _tagsCheckboxReadRepository.GetByIdAsync(id);

        public async Task<bool> Create(CreateTagsCheckboxDto model)
        {
         
                TagsCheckboxes tagsCheckbox = new TagsCheckboxes()

                {
                    TagsId =Guid.Parse(model.TagsId.ToString()),
                    isChecked = model.isChecked,




                };
                await _tagsCheckboxWriteRepository.AddAsync(tagsCheckbox);
         
         
            await _tagsCheckboxWriteRepository.SaveAsync();

            return true;
           
        }

        public async Task<bool> Update( UpdateTagsCheckboxDto models)
        {
            var id = await _tagsCheckboxReadRepository.GetByIdAsync(models.Id);
            if (id is null) throw new Exception(" not information models ");
            TagsCheckboxes _tagsCheckbox = new TagsCheckboxes();

            _tagsCheckbox.isChecked = models.isChecked;


            _tagsCheckboxWriteRepository.Update(_tagsCheckbox);
            await _tagsCheckboxWriteRepository.SaveAsync();

            return true;
        }

       
    }
}
