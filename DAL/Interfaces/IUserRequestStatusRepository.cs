using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;
using SHARED.ENUMS;

namespace DAL.Interfaces
{
    /// <summary>
    /// UserRequestStatusRepository Interface contains declaration of functions which are to be implemented by HouseListingRepository Class
    /// </summary>
    interface IUserRequestStatusRepository
    {
        List<UserRequestStatus> GetAllRequests();
        List<UserRequestStatus> GetUserByStatus(Status status);
        UserRequestStatus GetUserStatusById(int userId);
        bool CreateUserRequest(int userId);
        bool UpdateUserStatus(int id, Status status);
        bool DeleteUserRequest(int id);

    }
}
