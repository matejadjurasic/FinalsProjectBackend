using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Exceptions;
using FitnessPal.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;   

        public UserRepository(AppDbContext appDbContext, UserManager<User> userManager) : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public async Task AddUserToClientRole(User user)
        {
            await _userManager.AddToRoleAsync(user, "Client");
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _appDbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            var user = await _appDbContext.Users
               .Include(u => u.UserRoles)
               .ThenInclude(ur => ur.Role)
               .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), id);
            }

            return user;
        }
    }
}
