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
/// UserRequestStatus class consists of columns that are to added to db
/// </summary>
    public class UserRequestStatus
    {
        public int UserRequestStatusId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public Status RequestStatus { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
