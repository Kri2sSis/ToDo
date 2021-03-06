using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Core.Repositories;

namespace ToDo.DataAccess.MSSQL.Repositories
{
    public class UserRepositoriy : IUserRepositoriy
    {
        private readonly ToDoDbContext _context;
        private readonly IMapper _mapper;

        public UserRepositoriy(ToDoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<int> Add(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userEntitis = _mapper.Map<User, Entities.User>(user);


            await _context.Users.AddAsync(userEntitis);
            await _context.SaveChangesAsync();

            return userEntitis.Id;

        }

        public async Task<User> Get(int id)
        {
            var userEntity = await _context.Users
                .Include(x => x.ToDoBoard)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            var userCore = _mapper.Map<Entities.User, Core.Repositories.User>(userEntity);
            return userCore;
        }

        public async Task<bool> Delete(int id)
        {
            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (userEntity == null)
            {
                return false;
            }

            await _context.Entry(userEntity)
                    .Collection(x => x.ToDoBoard)
                    .LoadAsync();
            _context.Boards.RemoveRange(userEntity.ToDoBoard);
            _context.Users.Remove(userEntity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
