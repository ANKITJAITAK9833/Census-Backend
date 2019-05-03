using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHARED.DTOS
{

    public class UserRequestDto
    {
        public int UserId { get; set; }

        public bool IsApprover { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string AadharNumber { get; set; }

        public string Image { get; set; }

        public string Status { get; set; }

    }



}
