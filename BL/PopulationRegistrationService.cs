using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Helper;
using BL.Interfaces;
using DAL.ENTITY;
using DAL.REPOSITORY;
using SHARED.DTOS;

namespace BL
{   /// <summary>
/// this class consists of basic functions of Population Register
/// </summary>
    public class PopulationRegistrationService :IPopulationRegistrationService
    {
        public PopulationRegistrationRepository populationRegistrationRepository;
        CustomAutoMapper mapper;
        public PopulationRegistrationService()
        {
            populationRegistrationRepository = new PopulationRegistrationRepository();
            mapper = new CustomAutoMapper();
        }


        /// <summary>
        /// Fetching all populations registred
        /// </summary>
        /// <returns> list of all registrations</returns>
        public List<PopulationRegistrationDto> GetAll()
        {
            List<PopulationRegistration> allPopulationRegistrations = populationRegistrationRepository.GetAll();
            return (allPopulationRegistrations == null ? null : mapper.Mapper.Map<List<PopulationRegistrationDto>>(allPopulationRegistrations));
        }

        /// <summary>
        /// Fetching PopulationRegister According to a id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> population register corresponding to id</returns>
        public PopulationRegistrationDto GetById(int id)
        {
                PopulationRegistration populationRegistration = populationRegistrationRepository.GetById(id);
                return (populationRegistration == null ? null : mapper.Mapper.Map<PopulationRegistrationDto>(populationRegistration));
        }


        /// <summary>
        /// Adding new data to population register
        /// </summary>
        /// <param name="newPopulationRegistration"></param>
        /// <returns> whether registration was successfull or not</returns>
        public bool Add(PopulationRegistrationDto newPopulationRegistration)
        {
            if (CheckNullEntries(newPopulationRegistration)) //checking for null or whitespace entries
            {
                PopulationRegistration newHouse = mapper.Mapper.Map<PopulationRegistration>(newPopulationRegistration);

                bool result = populationRegistrationRepository.Add(newHouse);
                return result;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// checking null or whitespace entries to form
        /// </summary>
        /// <param name="newPopulationRegistration"></param>
        /// <returns> whether there were any null or whhitespace entry to the form</returns>
        private bool CheckNullEntries(PopulationRegistrationDto newPopulationRegistration)
        {
            if (string.IsNullOrWhiteSpace(newPopulationRegistration.FullName)||string.IsNullOrWhiteSpace((newPopulationRegistration.DateOfBirth).ToString())
               ||string.IsNullOrWhiteSpace(newPopulationRegistration.RelationToHead.ToString()) || string.IsNullOrWhiteSpace((newPopulationRegistration.Occupation).ToString())
               || string.IsNullOrWhiteSpace((newPopulationRegistration.NatureOfOccupation).ToString()) || string.IsNullOrWhiteSpace((newPopulationRegistration.MaritalStatus).ToString())
               || string.IsNullOrWhiteSpace((newPopulationRegistration.AgeAtMarriage).ToString()))
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// deleting corresponding to a given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>whether population register wad deleted or not</returns>
        public bool Delete(int id)
        {
            if (populationRegistrationRepository.Delete(id))
            {
                return true;
            }
            return false;
        }
    }
}
