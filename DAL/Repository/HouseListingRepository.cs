using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;
using DAL.Interfaces;


namespace DAL.REPOSITORY
{  /// <summary>
/// HouseListingRepository class contains functionality to add data to db
/// </summary>
    public class HouseListingRepository :IHouseListingRepository
    {
        private DataCollectionContext collectionContext;
        public HouseListingRepository()
        {
            collectionContext = new DataCollectionContext();
        } 

        /// <summary>
        /// Adding House Data To db
        /// </summary>
        /// <param name="houseListing"></param>
        /// <returns>whethe data was successfully entred or not</returns>
        public HouseListing AddHouseData(HouseListing houseData)
        {
            try
            {
                collectionContext.HouseListings.Add(houseData);
                collectionContext.SaveChanges();
                return houseData;
            }
            catch
            {
                return null ;
            }
        }

        /// <summary>
        /// Fetching all HouseListing Data
        /// </summary>
        /// <returns> list of all HouseListing</returns>
        public List<HouseListing> GetAll()
        {
            return (from houses in collectionContext.HouseListings
                    select houses).ToList();
        }

        /// <summary>
        /// Fetching houselist by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>houselist corresponding to houseListing id</returns>
        public HouseListing GetById(int houseListingId)
        {
            try
            {
                return (from house in collectionContext.HouseListings
                        where house.HouseListingId == houseListingId
                        select house).Single();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Adding new house to db
        /// </summary>
        /// <param name="house"></param>
        /// <returns>whether added successfully or not</returns>
        public HouseListing Add(HouseListing house)
        {
            try
            {
                collectionContext.HouseListings.Add(house);
                collectionContext.SaveChanges();
                return house;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deleting house corresponding  to houseId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>whether deleted successfully or not</returns>
        public bool Delete(int houseId)
        {
            try
            {

                var deletableHouse = (from delatableHouse in collectionContext.HouseListings
                                     where delatableHouse.HouseListingId == houseId
                                     select delatableHouse).Single();
                if (deletableHouse != null)
                {
                    collectionContext.HouseListings.Remove(deletableHouse);
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


        public IEnumerable<HouseListing> Find(Expression<Func<HouseListing, bool>> predicate)
        {
            return collectionContext.HouseListings.Where(predicate);
        }
    }
}
