using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.ENUMS;

namespace SHARED
{  
    /// <summary>
    /// This class is for Fetching user status by userId
    /// </summary>
   public class UserRequestStatusModel
    {
       public int UserId { get; set; }
       public Status Status { get; set; }
    }
}
