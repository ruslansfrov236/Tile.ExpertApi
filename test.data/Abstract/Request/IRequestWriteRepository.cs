using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test.entity.Entities;

namespace test.data.Abstract
{
    public interface IRequestWriteRepository:IWriteRepository<Request>
    {
    }
}
