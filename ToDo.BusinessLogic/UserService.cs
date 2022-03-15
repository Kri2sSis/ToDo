using ToDo.Core.Repositories;
using ToDo.Core.Services;

namespace ToDo.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepositorie _userRepositorie;

        public UserService(IUserRepositorie userRepositorie)
        {
            _userRepositorie = userRepositorie;
        }

        public async Task<int> Create(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var toDoBoards = CreateToDoBoards();
            user.ToDoBoards = toDoBoards;
            var id = await _userRepositorie.Add(user);
            return id;

        }

        public System.Threading.Tasks.Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Get(int id)
        {
            throw new NotImplementedException();
        }


        private ICollection<ToDoBoard> CreateToDoBoards()
        {
            ICollection<ToDoBoard> toDoBoards = new ToDoBoard[]
            {
                new ToDoBoard
                {
                    Name = "In the plans",
                    Status = Status.InThePlans
                },
                new ToDoBoard
                {
                    Name = "In progress",
                    Status = Status.InProgress
                },
                new ToDoBoard
                {
                    Name = "Done",
                    Status = Status.Done
                }
            };
            return toDoBoards;
        }

    }
}