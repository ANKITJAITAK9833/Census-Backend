using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using SHARED.DTOS;

namespace Nagarro_Exit_Project.Controllers
{
    public class PopulationRegistrationController : ApiController
    {
        PopulationRegistrationService populationRegistrationService;
        public PopulationRegistrationController()
        {
            populationRegistrationService = new PopulationRegistrationService();
        }

        // GET: api/PopulationRegistration
        public HttpResponseMessage Get()
        {
            ResponseFormat<List<PopulationRegistrationDto>> response = new ResponseFormat<List<PopulationRegistrationDto>>();
            response.Data = populationRegistrationService.GetAll();
            if (response.Data.Count() == 0)
            {
                response.message = "List is Empty";
                response.success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Data Fetched Successfuly";
            response.success = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/PopulationRegistration/5
        public HttpResponseMessage Get(int id)
        {
            ResponseFormat<PopulationRegistrationDto> response = new ResponseFormat<PopulationRegistrationDto>();
            response.Data = populationRegistrationService.GetById(id);
            if (response.Data == null)
            {
                response.message = "House Not Found Corresponding To This Id";
                response.success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Success";
            response.success = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        // POST: api/PopulationRegistration
        public HttpResponseMessage Post([FromBody]PopulationRegistrationDto newPopulationRegistration)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = populationRegistrationService.Add(newPopulationRegistration);
            if (response.Data)
            {
                response.message = "New Population Registered Added";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Cannot Enter Population Data";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        // DELETE: api/PopulationRegistration/5
        public HttpResponseMessage Delete(int id)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = populationRegistrationService.Delete(id);

            if (response.Data)
            {
                response.message = " Deleted Successfully";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Delete Operation Failed";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
