using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E = test.entity.Entities;
namespace test.entity.Dto.TagsCheckbox
{
    public class UpdateTagsCheckboxDto
    {
        public string  Id { get; set; }   
      
        public Guid? TagsId { get; set; }
        public bool isChecked { get; set; } = false;

    }
}
