using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;

namespace DAL.Interfaces
{  /// <summary>
/// HouseListingRepository Interface contains declaration of functions which are to be implemented by HouseListingRepository Class
/// </summary>
    interface IHouseListingRepository
    {
         HouseListing AddHouseData(HouseListing houseListing);
        List<HouseListing> GetAll();
        HouseListing GetById(int id);
        HouseListing Add(HouseListing house);
        bool Delete(int id);
    }
}
