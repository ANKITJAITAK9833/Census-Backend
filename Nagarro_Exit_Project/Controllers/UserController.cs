using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using BL;
using SHARED;
using SHARED.DTOS;
using SHARED.ENUMS;

namespace Nagarro_Exit_Project.Controllers
{
    public class UserController : ApiController
    {
        UserService userService;
        public UserController()
        {
            userService = new UserService();

        }

        // GET: api/Home
        public HttpResponseMessage Get()
        {
            ResponseFormat<List<UserDto>> response = new ResponseFormat<List<UserDto>>();
            response.Data = userService.GetAllUsers();
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

        [HttpGet]
        [Route("api/User/{aadharNumber}")]
        public HttpResponseMessage GetByAadhar(string aadharNumber)
        {
            ResponseFormat<UserDto> response = new ResponseFormat<UserDto>();
            response.Data = userService.GetByAadharNumber(aadharNumber);
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
        [Route("api/User/{status}")]
        public HttpResponseMessage GetByStatus(Status status)
        {
            ResponseFormat<List<UserRequestDto>> response = new ResponseFormat<List<UserRequestDto>>();
            response.Data = userService.GetAllByStatus(status);
            if (response.Data != null)
            {
                for (int i = 0; i < response.Data.Count(); i++)
                {
                    response.Data[i].Image = getImage(response.Data[i].Image);
                }
                response.message = "Successfully Retreived";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Not Found";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }


        // GET: api/Home/5
        public HttpResponseMessage Get(string email)
        { 
            ResponseFormat<UserDto> response = new ResponseFormat<UserDto>();
            response.Data = userService.GetUserByEmailId(email);
            if(response.Data!=null)
            {
                
                response.message = "Successfully Retreived";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Not Found";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        // POST: api/Home
        public HttpResponseMessage Post(UserImageModel user)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            UserDto userDto = user.user;
            userDto.ProfileImage = saveImage(user.image, user.name);
            response.Data = userService.CreateUser(userDto);
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
       
        private string saveImage(string image, string name)
        {
            string imageName = null;
            imageName = new string(Path.GetFileNameWithoutExtension(name).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(name);

            byte[] bytes = Convert.FromBase64String(image);
            using (Image actualImage = Image.FromStream(new MemoryStream(bytes)))
            {
                //actualImage.Save("output.jpg", ImageFormat.Jpeg); 
                actualImage.Save(System.Web.HttpContext.Current.Server.MapPath("~/Images/" + imageName));// Or Png
            }

            return imageName;
        }


        private string getImage(string imageName)
        {

            string path = HttpContext.Current.Server.MapPath("~/Images/") + imageName;
            string base64String;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(path))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }

        }





        // DELETE: api/Home/5
        public HttpResponseMessage Delete(int id)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = userService.DeleteUser(id);

            if (response.Data)
            {
                response.message = "User Deleted Successfully";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Delete Operation Failed";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }
    }
}
