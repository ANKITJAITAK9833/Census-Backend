using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.ENUMS;
namespace SHARED.DTOS
{
   public  class HouseListingDto
    {
        public int HouseListingId { get; set; }


        public string ApartmentNumber { get; set; }

       
        public string StreetNumber { get; set; }

        
        public string City { get; set; }

        
        public string State { get; set; }

        
        public string HeadName { get; set; }

        
        public OwnershipStatus OwnerShipStatus { get; set; }

        
        public int NumberOfRooms { get; set; }
    }
}
