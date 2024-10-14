using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Dto.History;
using test.entity.Entities;

namespace test.business.Abstract
{
    public interface IHistoryService
    {
        Task<List<History>> GetALL();
        Task<History> GetById(string id);
        Task<bool> Create(CreateHistoryDto model);
        Task<bool> Update(UpdateHistoryDto model);
        Task<bool> Delete(string id);   
        
    }
}
