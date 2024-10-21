using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.business.Abstract;
using test.data.Abstract;
using test.entity.Dto.Request;
using test.entity.Entities;

namespace test.business.Concrete
{
    public class RequestService : IRequestService
    {
        readonly private IRequestReadRepository _requestReadRepository;
        readonly private IRequestWriteRepository _requestWriteRepository;

        public RequestService(IRequestReadRepository requestReadRepository , IRequestWriteRepository requestWriteRepository)
        {
            _requestReadRepository= requestReadRepository;
            _requestWriteRepository= requestWriteRepository;
        }
        public async Task<bool> Create(CreateRequestDto model)
        {
            var request = new Request();

            request.Phone = model.Phone;
            request.Email = model.Email;
            request.Description= model.Description;
            request.Name = model.Name;

            await _requestWriteRepository.AddAsync(request);
            await _requestWriteRepository.SaveAsync();
            return true;

        }

        public async Task<bool> Delete(string id)
        {
            var request = await _requestReadRepository.GetByIdAsync(id);
            if (request == null)
            {
                throw new Exception("not found");
              
            }
                
                    
            _requestWriteRepository.Remove(request);
            await _requestWriteRepository.SaveAsync();

            return true;
        }

        public async Task<List<Request>> GetAll()
        {
          List<Request > requests = await _requestReadRepository.GetAll().ToListAsync();

            return requests;
        }

        public async Task<Request> GetById(string id)
       => await _requestReadRepository.GetByIdAsync(id);

        public async Task<bool> Update(UpdateRequestDto model)
        {
            var request = await _requestReadRepository.GetByIdAsync(model.Id);

            if (request == null) return false;  

            request.Phone = model.Phone;
            request.Email = model.Email;
            request.Description= model.Description; 
            request.Name= model.Name;   
            _requestWriteRepository.Update(request);
            await _requestWriteRepository.SaveAsync();
            return true;
        }
    }
}
