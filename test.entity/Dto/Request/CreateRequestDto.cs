using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.entity.Dto.Request
{
    public class CreateRequestDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
        public string Description { get; set; }
    }
}
