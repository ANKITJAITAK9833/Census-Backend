using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.REPOSITORY;
using DAL.ENTITY;
using BL.Helper;
using SHARED.DTOS;
using BL.Interfaces;

namespace BL
{   /// <summary>
/// HouseListingService contains all business logic of House Listing Form
/// </summary>
    public class HouseListingService :IHouseListingService
    {
        public HouseListingRepository houseListingRepository;
        CustomAutoMapper mapper;
        public PopulationRegistrationRepository populationRegistrationRepository;

        public HouseListingService()
        {
            houseListingRepository = new HouseListingRepository();
            populationRegistrationRepository = new PopulationRegistrationRepository();
            mapper = new CustomAutoMapper();
        }

        /// <summary>
        /// Fetching All Houses
        /// </summary>
        /// <returns> List of houses</returns>
        public List<HouseListingDto> GetAll() 
        {
            List<HouseListing> houses = houseListingRepository.GetAll();
            return (houses == null ? null : mapper.Mapper.Map<List<HouseListingDto>>(houses));
        }

        /// <summary>
        /// Fetching House By Id
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns> A single house corresponding to houseId</returns>
        public HouseListingDto GetById(int houseId) 
        {
            HouseListing house = houseListingRepository.GetById(houseId);
            return (house == null ? null : mapper.Mapper.Map<HouseListingDto>(house));

        }

        /// <summary>
        /// Adding New House 
        /// </summary>
        /// <param name="house"></param>
        /// <returns> return wheather house was successfully added or not</returns>

        public HouseListingDto Add(HouseListingDto house)  
        {
            if (CheckNullEntries(house))
            {
                HouseListing newHouse = mapper.Mapper.Map<HouseListing>(house);

                return mapper.Mapper.Map< HouseListingDto>(houseListingRepository.Add(newHouse));

            }
            return null;
            
        }

        /// <summary>
        /// Private Method Of Class which checks null or whitespace entries
        /// </summary>
        /// <param name="house"></param>
        /// <returns> wheather there were any null values or not</returns>
        private bool CheckNullEntries(HouseListingDto house)  
        {
            if (string.IsNullOrWhiteSpace(house.ApartmentNumber) || string.IsNullOrWhiteSpace(house.City) || string.IsNullOrWhiteSpace(house.HeadName) || string.IsNullOrWhiteSpace(house.State) || string.IsNullOrWhiteSpace(house.StreetNumber))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Method for deleting a particular house corresponding to a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> whether house was deleted or not</returns>
        public bool Delete(int id)
        {

            if (houseListingRepository.Delete(id))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Fetching State report for bar graph at front end
        /// </summary>
        /// <returns></returns>
        public List<int> GetStateReport()
        {
            List<string> StateArray = new List<string>() { "Andaman & Nicobar", "Andhra Pradesh", "Arunachal Pradesh", "Assam", "Bihar", "Chandigarh", "Chhattisgarh", "Dadra & Nagar Haveli", "Daman & Diu", "Delhi", "Goa", "Gujarat", "Haryana", "Himachal Pradesh", "Jammu & Kashmir", "Jharkhand", "Karnataka", "Kerala", "Lakshadweep", "Madhya Pradesh", "Maharashtra", "Manipur", "Meghalaya", "Mizoram", "Nagaland", "Orissa", "Pondicherry", "Punjab", "Rajasthan", "Sikkim", "Tamil Nadu", "Tripura", "Uttar Pradesh", "Uttaranchal", "West Bengal" };
            List<int> statePopulation = new List<int>();
            foreach (string state in StateArray)
            {

                List<HouseListing> houses = this.houseListingRepository.Find(house => house.State == state).ToList();
                if (houses.Count == 0)
                {
                    statePopulation.Add(0);

                }
                else
                {
                    int populationCount = 0;
                    foreach (HouseListing house in houses)
                    {
                        int counted = this.populationRegistrationRepository.Find(houseMember => houseMember.CensusHouseNumberId == house.HouseListingId).ToList().Count;
                        populationCount = populationCount + counted;
                    }
                    statePopulation.Add(populationCount);


                }
            }
            return statePopulation;



        }

    }
}
