using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.ENUMS;
namespace SHARED.DTOS
{
    public class UserRequestStatusDto
    {

        public int UserRequestStatusId { get; set; }

        
        public int UserId { get; set; }

       
        public Status RequestStatus { get; set; }
    }
}
