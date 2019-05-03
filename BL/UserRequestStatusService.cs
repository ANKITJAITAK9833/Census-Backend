using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Helper;
using BL.Interfaces;
using DAL.ENTITY;
using DAL.REPOSITORY;
using SHARED;
using SHARED.DTOS;
using SHARED.ENUMS;

namespace BL
{  /// <summary>
/// User Request status class handles all requests of volunteer
/// </summary>
    public class UserRequestStatusService :IUserRequestStatusService
    {
        public UserRequestStatusRepository userRequestStatusRepository;
        CustomAutoMapper mapper;
        public UserRequestStatusService()
        {
            userRequestStatusRepository = new UserRequestStatusRepository();
            mapper = new CustomAutoMapper();
        }

        /// <summary>
        /// Fetching all requests
        /// </summary>
        /// <returns> list of all requests</returns>
        public List<UserRequestStatusDto> GetAllRequests()
        {
            List<UserRequestStatus> allRequests = userRequestStatusRepository.GetAllRequests();
            return ( allRequests==null? null: mapper.Mapper.Map<List<UserRequestStatusDto>>(allRequests));
        }


        /// <summary>
        /// Fetching status of user according to user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> a single request corresponding to userId</returns>
        public UserRequestStatusDto GetUserStatusById(int userId)
        {
            UserRequestStatus userStatus = userRequestStatusRepository.GetUserStatusById(userId);
            return  ( userStatus==null? null:  mapper.Mapper.Map<UserRequestStatusDto>(userStatus));
        }

        /// <summary>
        /// Creating new UserRequest
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> whether new request was succesfully added or not</returns>
        public bool CreateUserRequest(int userId)
        {
                bool result = userRequestStatusRepository.CreateUserRequest(userId);
                return result;
        }
        
        /// <summary>
        /// Fetching all users according to there status
        /// </summary>
        /// <param name="status"></param>
        /// <returns> list of all user statuses by status</returns>
        public List<UserRequestStatusDto> GetUserByStatus(Status status)
        {
            List<UserRequestStatus> userByStatus = userRequestStatusRepository.GetUserByStatus(status);
           return (userByStatus ==null ? null:   mapper.Mapper.Map<List<UserRequestStatusDto>>(userByStatus));
        }

        /// <summary>
        /// Updating userstatus corresponding to id and status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns> whether user status was successfully updated or not</returns>
        public bool UpdateUserStatus(int statusId,Status status )
        {
            if (userRequestStatusRepository.UpdateUserStatus(statusId,status))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// deleting uses request by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteUserRequest(int statusId)
        {
            if(userRequestStatusRepository.DeleteUserRequest(statusId))
            {
                return true;
            }
            return false;
        }

      
    }
}
