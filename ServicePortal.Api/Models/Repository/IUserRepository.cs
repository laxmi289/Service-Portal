using ServicePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePortal.Api.Models.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserData>> GetUsers();
        Task<UserData> GetUser(int id);
        Task<UserData> AddUser(UserData user);
        Task<UserData> UpdateUser(UserData user);
        Task<UserData> DeleteUser(int id);
    }
}
