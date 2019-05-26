using DataService.Helpers;
using DataService.Model;
using DataService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService.Services
{
    public interface IUserService
    {
        User GetLogin(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User GetLogin(string username, string password)
        {
            HashHelper hashHelper = new HashHelper();
            return _userRepository.GetAll()
                .Where(u => u.Username == username &&
                            u.IsActive == true && 
                            hashHelper.VerifyHashedPassword(u.PasswordHash, password))
                .FirstOrDefault();
        }
    }
}
