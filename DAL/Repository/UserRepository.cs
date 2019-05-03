using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;
using DAL.Interfaces;

namespace DAL.REPOSITORY
{   /// <summary>
/// UserRepository class consists of functions nedded to add Users to db
/// </summary>
    public class UserRepository:IUserRepository
    {
        private DataCollectionContext collectionContext;
        public UserRepository()
        {
            collectionContext = new DataCollectionContext();
        }

        /// <summary>
        /// Adding new user to db
        /// </summary>
        /// <param name="createNewUser"></param>
        /// <returns>whether user was added to db or not</returns>
        public bool CreateUser(User createNewUser)
        {
           
           
            int ifExist = (from existingUser in collectionContext.Users
                           where existingUser.EmailId == createNewUser.EmailId
                           select existingUser).Count();
            if (ifExist == 0) //making sure that this is not entered before
            {

                collectionContext.Users.Add(createNewUser);
                collectionContext.SaveChanges();
                UserRequestStatusRepository userRequestStatusRepository = new UserRequestStatusRepository();
                userRequestStatusRepository.CreateUserRequest(createNewUser.UserId);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fetching User corrsponding to userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns> user corresponding to userId</returns>
        public User GetUserById(int userId)
        {
            try
            {
                User user = (from users in collectionContext.Users
                             where users.UserId == userId
                             select users).Single();
                return user;
            }
            catch
            {
                return null;
            }
        } 

        /// <summary>
        /// Logging in User
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns> whether data entred to form is valid or not</returns>
        public bool LoginUser(User loginUser)
        {
            var checkEmailId = loginUser.EmailId;
            var checkPassword = loginUser.Password;
            var data = (from user in collectionContext.Users
                        where (user.EmailId == checkEmailId && user.Password == checkPassword)
                        select user).ToList();

            int count = data.Count();
            if (count != 0)
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Updating user by userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>whether user was successfullyy updated or not</returns>
        public bool Update(int userId)
        {
            try
            {
                User updatableUser = (from user in collectionContext.Users
                             where user.UserId == userId
                             select user).Single();
                updatableUser.FirstName = "Updated";
                collectionContext.Users.AddOrUpdate(updatableUser);
                collectionContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// checking if email already exists or not
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns>whether email exists or not</returns>
        public bool IsEmailExists(string emailId)
        {
            int result = (from emails in collectionContext.Users
                          where emails.EmailId == emailId
                          select emails).Count();
            if (result != 0)
            {
                return true;
            }
            return false;

        }

        /// <summary>
        /// fethcing user by aadharNumber
        /// </summary>
        /// <param name="aadharNumber"></param>
        /// <returns>user corresponding to aadharNumber</returns>
        public User GetByAadharNumber(string aadharNumber)
        {
            List<User> allUsers = (from user in collectionContext.Users
                                   where user.AadharNumber == aadharNumber
                                   select user).ToList();
            if(allUsers.Count()!=0)
            {
                return allUsers.First();
            }
            return null;
        }

        /// <summary>
        /// fetching user by its email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>user corresponding to email id</returns>
        public User GetUserByEmailId(string email)
        {
            List<User> userList = (from user in collectionContext.Users
                                   where user.EmailId == email
                                   select user).ToList();
            if(userList.Count()!=0)
            {
                return userList.First();
            }
            return null;
           
           
        }

        /// <summary>
        /// fetching all users
        /// </summary>
        /// <returns>list of all users</returns>
        public List<User> GetAllUsers()
        {

            List<User> allMembers = (from members in collectionContext.Users
                                  select members).ToList();
            return allMembers;

        }

        /// <summary>
        /// deleting user by userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>whether deletion was successfull or not</returns>
        public bool DeleteUser(int userId)
        {
            try
            {

                var deletableUser=  (from delatableUser in collectionContext.Users
                                     where delatableUser.UserId==userId
                                          select delatableUser).Single();
                
                if(deletableUser!=null)
                {
                    collectionContext.Users.Remove(deletableUser);
                    collectionContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
