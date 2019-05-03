using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.DTOS;
using SHARED.ENUMS;

namespace BL.Interfaces
{
    /// <summary>
    /// UserServiceInterface consists of basic functionalities which has to be inplemented by UserService Class
    /// </summary>
    interface IUserService
    {
        List<UserDto> GetAllUsers();
        List<UserRequestDto> GetAllByStatus(Status status);
        UserDto GetByAadharNumber(string aadharNumber);
        UserDto GetUserById(int id);
        bool CreateUser(UserDto user);
        bool DeleteUser(int id);
    }
}
