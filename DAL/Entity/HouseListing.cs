using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.ENUMS;

namespace DAL.ENTITY
{  /// <summary>
/// houselisting class consists of columns that are to added to db
/// </summary>
    public class HouseListing
    {  
        
        public int HouseListingId { get; set; }

        [Required]   
        public string ApartmentNumber { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string HeadName { get; set; }

        [Required]
        public OwnershipStatus OwnerShipStatus {get;set;}

        [Required]
        public int NumberOfRooms { get; set; }


        public virtual ICollection<PopulationRegistration> PopulationRegistrations { get; set; }
    }
}
