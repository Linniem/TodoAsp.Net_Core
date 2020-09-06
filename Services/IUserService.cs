using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskCore.ViewModels;

namespace TaskCore.Services
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(LoginViewModel newUser);
        Task<bool> ValidUserAsync(LoginViewModel userInputInfo);

        Task<int?> GetUserIdAsync(string userName);
    }
}
