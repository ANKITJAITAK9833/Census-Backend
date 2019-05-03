using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.ENUMS;
namespace SHARED.DTOS
{
    public class PopulationRegistrationDto
    {
        public int PopulationRegistrationId { get; set; }

        
        public int UserId { get; set; }

        
        public string FullName { get; set; }

      
        public int CensusHouseNumberId { get; set; }

        
        public RelationToHead RelationToHead { get; set; }

        
        public Gender Gender { get; set; }

       
        public DateTime DateOfBirth { get; set; }

       
        public MaritalStatus MaritalStatus { get; set; }

        
        public int AgeAtMarriage { get; set; }

        
        public Occupation Occupation { get; set; }

        
        public NatureOfOccupation NatureOfOccupation { get; set; }
    }
}
