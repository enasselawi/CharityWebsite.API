using CharityWebsite.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharityWebsite.Core.Repository
{
    public interface IUserRepository
    {
        Userr GetUserProfile(int userID);

        // Method to update user profile
        void UpdateUserProfile(Userr user);

    }
}
