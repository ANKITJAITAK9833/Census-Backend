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
    public class HouseListingController : ApiController
    {
        HouseListingService houseListingService; 
        public HouseListingController()
        {
            houseListingService = new HouseListingService();
        }

        // GET: api/HouseListing
        public HttpResponseMessage Get()
        {
            ResponseFormat<List<HouseListingDto>> response = new ResponseFormat<List<HouseListingDto>>();
            response.Data = houseListingService.GetAll();
            if(response.Data.Count()==0)
            {
                response.message = "List is Empty";
                response.success = false;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Data Fetched Successfuly";
            response.success = true;
            return Request.CreateResponse(HttpStatusCode.OK, response);

        }

        // GET: api/HouseListing/5
        public HttpResponseMessage Get(int id)
        {
            ResponseFormat<HouseListingDto> response = new ResponseFormat<HouseListingDto>();
            response.Data = houseListingService.GetById(id);
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

        // POST: api/HouseListing
        public HttpResponseMessage Post([FromBody]HouseListingDto house)
        {
            ResponseFormat<HouseListingDto> response = new ResponseFormat<HouseListingDto>();
            response.Data = houseListingService.Add(house);
            if (response.Data!=null)
            {
                response.message = "New Home Added";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Cannot Enter Data To Home";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


    

        // DELETE: api/HouseListing/5
        public HttpResponseMessage Delete(int id)
        {
            ResponseFormat<bool> response = new ResponseFormat<bool>();
            response.Data = houseListingService.Delete(id);

            if (response.Data)
            {
                response.message = "Home Deleted Successfully";
                response.success = true;
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            response.message = "Delete Operation Failed";
            response.success = false;
            return Request.CreateResponse(HttpStatusCode.BadRequest, response);
        }

        public HttpResponseMessage GetStateReport(string state)
        {
            List<int> stateWiseReport=houseListingService.GetStateReport();
            ResponseFormat<List<int>> response = new ResponseFormat<List<int>>();
            response.Data = stateWiseReport;
            response.success = true; 
            response.message= "Successfully Retreived";
            return Request.CreateResponse(HttpStatusCode.OK, response);


        }

    }
}
