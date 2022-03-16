using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Repositories
{
    public interface IUserRepositoriy
    {
        Task<int> Add(User user);

        Task<User> Get(int id);

        Task<int> AddTask(Task task);

        Task<bool> UpdateTask(Task task);

        Task<bool> DeleteTask(int id);
    }
}
