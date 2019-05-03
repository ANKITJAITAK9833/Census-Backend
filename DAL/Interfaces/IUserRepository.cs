using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;

namespace DAL.Interfaces
{   /// <summary>
/// UserRepository Interface contains declaration of functions which are to be implemented by UserRepository Class
/// </summary>
    interface IUserRepository
    {
        bool CreateUser(User createNewUser);
        User GetUserById(int id);
        bool LoginUser(User loginUser);
        bool Update(int id);
        bool IsEmailExists(string emailId);
        User GetByAadharNumber(string aadharNumber);
        User GetUserByEmailId(string email);
        List<User> GetAllUsers();
        bool DeleteUser(int userId);
    }
}
