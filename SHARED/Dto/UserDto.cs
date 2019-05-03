using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.DTOS
{
    public class UserDto
    {
        public int UserId { get; set; }


        public string EmailId { get; set; }

        
        public string Password { get; set; }


        public string FirstName { get; set; }

        
        public string LastName { get; set; }

      
        public string ProfileImage { get; set; }

       
        public string AadharNumber { get; set; }

        
        public bool IsApprover { get; set; }
    }
}
