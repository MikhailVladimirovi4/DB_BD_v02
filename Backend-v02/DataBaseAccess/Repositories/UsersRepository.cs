using Backend_v02.DataBaseAccess.Entities;
using Backend_v02.DataBaseCore.Abstractions;
using Backend_v02.DataBaseCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_v02.DataBaseAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataBaseDbContext _context;

        public UsersRepository(DataBaseDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Get()
        {
            var usersEntities = await _context.Users
                .AsNoTracking()
                .ToListAsync();

            var user = usersEntities
                .Select(b => User.Create(b.Id, b.Login, b.Password, b.Level))
                .ToList();

            return user;
        }

        public async Task<Guid> Create(User user, int level)
        {
            UserEntity userEntity = new UserEntity
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.GetPassword(level, user.Login),
                Level = user.Level,
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();

            return userEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string login, string password, int level)
        {
            await _context.Users
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(b => b.Login, b => login)
                .SetProperty(b => b.Password, b => password)
                .SetProperty(b => b.Level, b => level));

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Users
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();

            await _context.SaveChangesAsync();

            return id;
        }
    }
}
