using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Helper;
using BL.Interfaces;
using DAL;
using DAL.ENTITY;
using DAL.REPOSITORY;
using SHARED;
using SHARED.DTOS;
using SHARED.ENUMS;

namespace BL
{  /// <summary>
/// User service class contains functions of user entry 
/// </summary>
    public class UserService : IUserService
    {
        public UserRepository userRepository;
        CustomAutoMapper mapper;
        public UserService()
        {
            userRepository = new UserRepository();
            mapper = new CustomAutoMapper();
        }
        /// <summary>
        /// Fetching all users
        /// </summary>
        /// <returns>list of all users</returns>
        public List<UserDto> GetAllUsers()
        {
            List<User> allMembers = userRepository.GetAllUsers();
            return ( allMembers==null? null: mapper.Mapper.Map<List<UserDto>>(allMembers));
        }

        /// <summary>
        /// Fetching all users according to status
        /// </summary>
        /// <param name="status"></param>
        /// <returns> list of all users according to status</returns>
        public List<UserRequestDto> GetAllByStatus(Status status)
        {

            List<User> users = userRepository.GetAllUsers();
            UserRequestStatusRepository userRequestStatusRepository = new UserRequestStatusRepository();
            List<UserRequestStatus> statuses = userRequestStatusRepository.GetAllRequests();
            if (users == null)
                return null;
            else
            {
                List<UserRequestDto> userRequestDto = (from m in users
                                                                   join s in statuses
                                                                   on m.UserId equals s.UserId
                                                                   where s.RequestStatus == status
                                                                   select new UserRequestDto
                                                                   {
                                                                       UserId = m.UserId,
                                                                       AadharNumber = m.AadharNumber,
                                                                       IsApprover = m.IsApprover,
                                                                       Status = s.RequestStatus.ToString(),
                                                                       FullName = m.FirstName + m.LastName,
                                                                       Email = m.EmailId,
                                                                       Image = m.ProfileImage,
                                                                       Password = m.Password
                                                                   }).ToList();
                return (userRequestDto);
            }
        }

        /// <summary>
        /// Fethching a user by aadhar number
        /// </summary>
        /// <param name="aadharNumber"></param>
        /// <returns>user corresponding to aadhar number</returns>
        public UserDto GetByAadharNumber(string aadharNumber)
        {
            User getByAadharNumber = userRepository.GetByAadharNumber(aadharNumber);
            return  mapper.Mapper.Map<UserDto>(getByAadharNumber);
        }

        /// <summary>
        /// fetching user by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns> user corresponding to userId</returns>
        public UserDto GetUserById(int userId)
        {
            User user = userRepository.GetUserById(userId);
            return mapper.Mapper.Map<UserDto>(user);
        }


        /// <summary>
        /// Adding new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>whether user was successfully added or not</returns>
        public bool CreateUser(UserDto user)
        {
            if (CheckNullEntries(user)) //checking for null or whitspace entries
            {
                User newUser = mapper.Mapper.Map<User>(user);
                bool result = userRepository.CreateUser(newUser);
                return result;
            }
            return false;

        }

        /// <summary>
        /// checking for null or white space entries
        /// </summary>
        /// <param name="user"></param>
        /// <returns>whether form contains null entries or not</returns>
        private bool CheckNullEntries(UserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.EmailId) || string.IsNullOrWhiteSpace(user.AadharNumber) || string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.ProfileImage))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// deleting user according to userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> whether user was successfully deleted or not</returns>
        public bool DeleteUser(int userId)
        {
            if (userRepository.DeleteUser(userId))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// updating user according to userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>whether user was successfully updated or not</returns>
        public bool Update(int userId)
        {
            if (userRepository.Update(userId))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// fetching user by emailid
        /// </summary>
        /// <param name="email"></param>
        /// <returns>user corresponding to emailid</returns>
        public UserDto GetUserByEmailId(string email)
        {
            User userByEmailId = userRepository.GetUserByEmailId(email);
            return mapper.Mapper.Map<UserDto>(userByEmailId);
        }
    }
}
