using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SHARED.ENUMS;
namespace DAL.ENTITY
{   /// <summary>
///  PopulationRegistration class consists of columns that are to added to db
/// </summary>
    public class PopulationRegistration
    {
        public int PopulationRegistrationId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int CensusHouseNumberId { get; set; }

        [Required]
        public string RelationToHead { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        public int AgeAtMarriage { get; set; }

        [Required]
        public Occupation Occupation { get; set; }

        [Required]
        public NatureOfOccupation NatureOfOccupation { get; set; }

        [ForeignKey("CensusHouseNumberId")]
        public virtual HouseListing HouseListing { get; set; }

        [ForeignKey("UserId")] 
        public virtual User User { get; set; }

    }
}
