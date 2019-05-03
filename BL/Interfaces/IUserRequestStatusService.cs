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
    /// UserRequestStatusService Interface consists of basic functionalities which has to be inplemented by UserRequestStatusService Class
    /// </summary>
    interface IUserRequestStatusService
    {
        List<UserRequestStatusDto> GetAllRequests();
        UserRequestStatusDto GetUserStatusById(int id);
        bool CreateUserRequest(int userId);
        List<UserRequestStatusDto> GetUserByStatus(Status status);
        bool UpdateUserStatus(int id, Status status);
        bool deleteUserRequest(int id);
    }
}
