using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.DTOS;

namespace BL.Interfaces
{   /// <summary>
/// HouseListingServie Interface consists of basic functionalities which has to be implemented by HouseListingService  Class
/// </summary>
    interface IHouseListingService
    {
        List<HouseListingDto> GetAll();
        HouseListingDto GetById(int id);
        HouseListingDto Add(HouseListingDto house);
        bool Delete(int id);

    }
}
