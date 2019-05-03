using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using BL;
using SHARED;
using SHARED.DTOS;
using SHARED.ENUMS;

namespace Nagarro_Exit_Project.Controllers
{
    public class UserRequestStatusController : ApiController
    {
        UserRequestStatusService userRequestStatusService;

        public UserRequestStatusController()
        {
            userRequestStatusService = new UserRequestStatusService();

        }

        // GET: api/UserRequestStatus
        public HttpResponseMessage Get()
        {
            ResponseFormat<List<UserRequestStatusDto>> response = new ResponseFormat<List<UserRequestStatusDto>>();
            response.Data = userRequestStatusService.GetAllRequests();
            if (response.Data == null)
            {
                response.success = false;
                response.message = "List Found";
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.success = true;
            response.message = "Data Fetched Successfully";
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        // GET: api/UserRequestStatus/5
        public HttpResponseMessage Get(int id)
        {
            ResponseFormat<UserRequestStatusDto> response = new ResponseFormat<UserRequestStatusDto>();
            response.Data = userRequestStatusService.GetUserStatusById(id);
            if (response.Data != null)
            {
                response.message = "Successfully Retreived";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Not Found";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

    


        [HttpGet]
        [Route("api/UserRequestStatus/{status}")]
        // GET: api/UserRequestStatus/5
        public HttpResponseMessage GetByStatus(Status status)
        {
            ResponseFormat<List<UserRequestStatusDto>> response = new ResponseFormat<List<UserRequestStatusDto>>();
            response.Data = userRequestStatusService.GetUserByStatus(status);
            if (response.Data != null)
            {

                response.message = "Successfully Retreived";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Not Found";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

       


        // POST: api/UserRequestStatus
        public HttpResponseMessage Post(int userId)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = userRequestStatusService.CreateUserRequest(userId);
            if (response.Data)
            {
                response.message = "New User Added";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Cannot Enter User ";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/UserRequestStatus/5
        public HttpResponseMessage Put([FromBody]UserRequestStatusModel updatableStatus)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = userRequestStatusService.UpdateUserStatus(updatableStatus.UserId,updatableStatus.Status);
            if (response.Data)
            {
                response.message = "New Status Updated";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Cannot Update Status ";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/UserRequestStatus/5
        public HttpResponseMessage Delete(int id)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = userRequestStatusService.deleteUserRequest(id);

            if (response.Data)
            {
                response.message = "User Deleted Successfully";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Delete Operation Failed";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
