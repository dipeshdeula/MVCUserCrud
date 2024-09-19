using System.ComponentModel.DataAnnotations;

namespace MVCUserCrud.Models
{
    public class UserListEdit
    {
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        public string UserPassword { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public string UserProfile { get; set; } = null!;

        public string UserAddress { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public bool UserStatus { get; set; }

        public string EncId { get; set; } = null!;

        [DataType(DataType.Upload)]

        public IFormFile? UserFile { get; set; } 
    }
}
