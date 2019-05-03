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
/// PopulationRegistrationRepository contains functions for adding population register data to db
/// </summary>
    public class PopulationRegistrationRepository:IPopulationRegistrationRepository
    {
       private DataCollectionContext collectionContext;
        public PopulationRegistrationRepository()
        {
            collectionContext = new DataCollectionContext();
        }

        /// <summary>
        /// Adding new Population Registartion to db
        /// </summary>
        /// <param name="newPopulationRegistration"></param>
        /// <returns>whether operation was successfull or not</returns>
        public bool Add(PopulationRegistration newPopulationRegistration)
        {
            try
            {
                collectionContext.PopulationRegistrations.Add(newPopulationRegistration);
                collectionContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// fetching all population registers
        /// </summary>
        /// <returns>list of all population registred</returns>
        public List<PopulationRegistration> GetAll()
        {
            return (from populationRegistrations in collectionContext.PopulationRegistrations
                                     select populationRegistrations).ToList();
            
        }

        /// <summary>
        /// fetching populationregister by populationregisterid
        /// </summary>
        /// <param name="populationRegisterId"></param>
        public PopulationRegistration GetById(int populationRegisterId)
        {
            try
            {
                return (from allPopulationRegistrations in collectionContext.PopulationRegistrations
                        where allPopulationRegistrations.PopulationRegistrationId == populationRegisterId
                        select allPopulationRegistrations).Single();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Deleting populationregister  by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int populationRegisterId)
        {
            try
            {

                var deletablePopulationRegistration = (from delatableRegistration in collectionContext.PopulationRegistrations
                                      where delatableRegistration.PopulationRegistrationId == populationRegisterId
                                      select delatableRegistration).Single();

                if (deletablePopulationRegistration != null)
                {
                    collectionContext.PopulationRegistrations.Remove(deletablePopulationRegistration);
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

        public IEnumerable<PopulationRegistration> Find(Expression<Func<PopulationRegistration, bool>> predicate)
        {
            return collectionContext.PopulationRegistrations.Where(predicate);
        }

    }
}
