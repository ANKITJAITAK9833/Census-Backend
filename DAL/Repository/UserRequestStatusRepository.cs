using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;
using DAL.Interfaces;
using SHARED.ENUMS;

namespace DAL.REPOSITORY
{  /// <summary>
/// UserRequestStatus class is to handle functinality of adding requests to db
/// </summary>
    public class UserRequestStatusRepository :IUserRequestStatusRepository
    {
        private DataCollectionContext collectionContext;

        public UserRequestStatusRepository()
        {
            collectionContext = new DataCollectionContext();
        }

        /// <summary>
        /// Fetching all requests
        /// /// </summary>
        /// <returns>List Of All Requests</returns>
        public List<UserRequestStatus> GetAllRequests()
        {
            return (from requests in collectionContext.UserRequestStatus
                                                   select requests).ToList();
        }


        /// <summary>
        /// fethching users by status   
        /// </summary>
        /// <param name="status"></param>
        /// <returns>list of users according ot status</returns>
        public List<UserRequestStatus> GetUserByStatus(Status status)
        {
            return (from requestByStatus in collectionContext.UserRequestStatus
                    where requestByStatus.RequestStatus == status
                    select requestByStatus).ToList();
        }

        /// <summary>
        /// Fetching status of User by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>user status corresponding to Id</returns>
        public UserRequestStatus GetUserStatusById(int userId)
        {
            try
            {

                UserRequestStatus requestStatus = (from user in collectionContext.UserRequestStatus
                                                   where user.UserId == userId
                                                   select user).Single();
                return requestStatus;
            }
            catch
            {
                return null;
            }
        }

        
        /// <summary>
        /// Addingg User Request to db
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> whether request added to db or not</returns>
        public bool CreateUserRequest(int userId)
        {
            try
            {

                UserRequestStatus userRequestStatus = new UserRequestStatus();
                userRequestStatus.UserId = userId;
                userRequestStatus.RequestStatus = Status.Pending;
                collectionContext.UserRequestStatus.Add(userRequestStatus);
                collectionContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete user request status by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteUserRequest(int userId)
        {
            try
            {
               List<UserRequestStatus> deletableUserList = (from requests in collectionContext.UserRequestStatus
                                                   where requests.UserId == userId
                                                   select requests).ToList();
                if(deletableUserList.Count!=0)
                {
                    collectionContext.UserRequestStatus.Remove(deletableUserList[0]);
                    collectionContext.SaveChanges();
                }
              
                return true;
            }
            catch
            {
                return false;
            }
        }

      
        /// <summary>
        /// updates user Request Status according to userId and new status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>whether updated or not</returns>
        public bool UpdateUserStatus(int userId, Status status)
        {
            try
            {
                UserRequestStatus findUserRequestId = (from users in collectionContext.UserRequestStatus
                                                       where users.UserId == userId
                                                       select users).Single();
                findUserRequestId.RequestStatus =status;

                collectionContext.Entry(findUserRequestId).State = System.Data.Entity.EntityState.Modified;
               
                collectionContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        
    }
}
