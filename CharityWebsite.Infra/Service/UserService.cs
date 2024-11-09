using CharityWebsite.Core.Data;
using CharityWebsite.Core.Repository;
using CharityWebsite.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public Userr GetUserProfile(int userID) => _userRepository.GetUserProfile(userID);

        // Update Profile Method
        public void UpdateUserProfile( Userr user) => _userRepository.UpdateUserProfile(user);
    }
}
