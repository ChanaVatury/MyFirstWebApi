using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Users
    {

        public int UserId { get; set; }
       // [MinLength(10, ErrorMessage ="its so short"), MaxLength]
        public string UserName { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
