using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        public string? Passwordd { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
      
    }
}
