using System.ComponentModel.DataAnnotations;

namespace MVCUserCrud.Models
{
    public class UserListEdit
    {
        public int UserId { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please ! Enter your Full name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [Required(ErrorMessage ="Please ! Enter your password")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 50 characters")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\W).+$", ErrorMessage = "Password must contain at least one uppercase, one lowercase, one special character and one number")]
        public string UserPassword { get; set; } = null!;

        [Display(Name ="Email-Password")]
        [Required(ErrorMessage = "Enter your valid Email Id")]
        public string EmailAddress { get; set; } = null!;

        [Display(Name ="User-Profile")]
        [Required(ErrorMessage ="Insert your valid image format!")]
        public string UserProfile { get; set; } = null!;


        [Display(Name = "User-Address")]
        [Required(ErrorMessage = "Enter your valid address")]
        public string UserAddress { get; set; } = null!;

        public string UserRole { get; set; } = null!;

        public bool UserStatus { get; set; }

        public string EncId { get; set; } = null!;

        [DataType(DataType.Upload)]

        public IFormFile? UserFile { get; set; } 
    }
}
