using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.Request;
using test.entity.Entities;

namespace test.business.Abstract
{
    public interface IRequestService
    {
        Task<List<Request>> GetAll();
        Task<Request> GetById(string id);

        Task<bool> Create(CreateRequestDto model);
        Task<bool> Update(UpdateRequestDto model);
        Task<bool> Delete(string id);
    }
}
