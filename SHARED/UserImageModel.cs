using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED.DTOS;

namespace SHARED
{  /// <summary>
/// This class performs the fucntionality of adding image to db
/// </summary>
     public class UserImageModel
     {
        public UserDto user { get; set; }
        public string image { get; set; }
        public string name { get; set; }
     }
}
