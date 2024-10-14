using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.business.Abstract;
using test.data.Abstract;
using test.entity.Dto.History;
using test.entity.Entities;

namespace test.business.Concrete
{

    public class HistoryService : IHistoryService
    {
        readonly private IHistoryReadRepository _historyReadRepository;
        readonly private IHistoryWriteRepository _historyWriteRepository;

        public HistoryService(IHistoryReadRepository historyReadRepository, IHistoryWriteRepository historyWriteRepository)
        {
            _historyReadRepository = historyReadRepository; 
            _historyWriteRepository = historyWriteRepository;   
        }
        public async Task<bool> Create(CreateHistoryDto model)
        {

            await _historyWriteRepository.AddAsync(new History() { Title=model.Title });
            await _historyWriteRepository.SaveAsync();
            return true;

           
        }

        public async Task<bool> Delete(string id)
        {
            var _id = await _historyReadRepository.GetByIdAsync(id);

            if(_id != null ) 

                _historyWriteRepository.Remove(_id);
            await _historyWriteRepository.SaveAsync();
               return true;
        }

        public async Task<List<History>> GetALL()
        {
            List<History> history = await _historyReadRepository.GetAll().ToListAsync();

            return history;
        }

        public Task<History> GetById(string id)
        => _historyReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateHistoryDto model)
        {
            var history = new History();

            history.Title = model.Title;

             _historyWriteRepository.Update(history);
            await _historyWriteRepository.SaveAsync();  
            return true;
        }
    }
}
