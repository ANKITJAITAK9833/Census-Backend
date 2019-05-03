using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ENTITY;

namespace DAL.Interfaces
{
    /// <summary>
    /// PopulationRegistrationRepository Interface contains declaration of functions which are to be implemented by PopulationRegistration Class
    /// </summary>
    interface IPopulationRegistrationRepository
    {
        bool Add(PopulationRegistration newPopulationRegistration);
        List<PopulationRegistration> GetAll();
        PopulationRegistration GetById(int id);
        bool Delete(int id);
    }
}
