using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.ENTITY
{
    /// <summary>
    /// User class consists of columns that are to added to db
    /// </summary>
    public class User
    {
        public int UserId { get; set; }

        
        [Required]
        [MaxLength(120)]
        [Index(IsUnique = true)]
        public string EmailId { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ProfileImage { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "AADHAR NUMBER MUST BE 12 DIGITS LONG")]
        [Index(IsUnique = true)]
        public string AadharNumber { get; set; }

        [Required]
        public bool IsApprover { get; set; }

        





    }
}
