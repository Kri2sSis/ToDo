using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Repositories;

namespace ToDo.Core.Services
{
    public interface IUserService
    {
        Task<int> Create(User user);

        Task<User> Get(int id);

        Task<bool> Delete(int id);
    }
}
