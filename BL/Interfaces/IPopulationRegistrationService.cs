using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.DTOS;

namespace BL.Interfaces
{      /// <summary>
/// PopulationRegsiterService Interface consists of basic functionalities which has to be inplemented by PopulationRegisterService Class
/// </summary>
    interface IPopulationRegistrationService
    {
        List<PopulationRegistrationDto> GetAll();
        PopulationRegistrationDto GetById(int id);
        bool Add(PopulationRegistrationDto newPopulationRegistration);
        bool Delete(int id);
    }
}
