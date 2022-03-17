using ToDo.Core.Repositories;
using ToDo.Core.Services;

namespace ToDo.BusinessLogic
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoriy _userRepositorie;

        public UserService(IUserRepositoriy userRepositorie)
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

        public async Task<User> Get(int id)
        {
            if (id == default(int))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _userRepositorie.Get(id);
            
        }

        public async Task<bool> Delete(int id)
        {
            if (id == default(int))
            {
                throw new ArgumentNullException(nameof(id));
            }
            return await _userRepositorie.Delete(id);
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