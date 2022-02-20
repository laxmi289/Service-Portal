using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Models
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UserData>> GetUsers()
        {
            return await appDbContext.UserData.ToListAsync();
        }

        public async Task<UserData> GetUser(int id)
        {
            return await appDbContext.UserData
                .FirstOrDefaultAsync(e => e.UserId == id);
        }

        public async Task<UserData> AddUser(UserData user)
        {
            var result = await appDbContext.UserData.AddAsync(user);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<UserData> UpdateUser(UserData user)
        {
            var result = await appDbContext.UserData
                .FirstOrDefaultAsync(e => e.UserId == user.UserId);

            if (result != null)
            {
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Email = user.Email;
                result.DOB = user.DOB;
                result.Phone = user.Phone;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<UserData> DeleteUser(int id)
        {
            var result = await appDbContext.UserData
                .FirstOrDefaultAsync(e => e.UserId == id);
            if (result != null)
            {
                appDbContext.UserData.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
