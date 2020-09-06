using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskCore.Helpers;
using TaskCore.Models;
using TaskCore.Repositories;
using TaskCore.ViewModels;

namespace TaskCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly EncryptHelper encryptHelper;

        public UserService(IUserRepository userRepo, EncryptHelper encryptHelper)
        {
            this.userRepo = userRepo;
            this.encryptHelper = encryptHelper;
        }

        public async Task<bool> CreateUserAsync(LoginViewModel newUser)
        {
            if (userRepo.GetAll().Any(x => x.UserName == newUser.UserName))
            {
                return false;
            }
            await userRepo.CreateAsync(new User()
            {
                UserName = newUser.UserName,
                Password = encryptHelper.Sha256(newUser.Password)
            });
            return true;
        }

        public async Task<bool> ValidUserAsync(LoginViewModel userInputInfo)
        {
            var findUserNameResult =
                await userRepo.Find(x => x.UserName == userInputInfo.UserName)
                    .FirstOrDefaultAsync();
            if (findUserNameResult != null &&
                findUserNameResult.Password == encryptHelper.Sha256(userInputInfo.Password))
            {
                return true;
            }
            return false;
        }

        public async Task<int?> GetUserIdAsync(string userName)
        {
            var user = await userRepo.GetAll()
                .FirstOrDefaultAsync(x => x.UserName == userName);
            if (user != null)
            {
                return user.UserId;
            }
            return null;
        }
    }
}
