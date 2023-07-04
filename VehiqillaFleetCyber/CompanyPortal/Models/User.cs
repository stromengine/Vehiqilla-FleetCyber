using System.ComponentModel.DataAnnotations;

namespace CompanyPortal.Models
{
    public class UserViewModel
    {
        public string ID { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$#!%*?&]{8,}$", ErrorMessage = "minimum 8 characters with 1 of each Uppercase,Lowercase,digit and special characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$#!%*?&]{8,}$", ErrorMessage = "minimum 8 characters with 1 of each Uppercase,Lowercase,digit and special characters")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$#!%*?&]{8,}$", ErrorMessage = "minimum 8 characters with 1 of each Uppercase,Lowercase,digit and special characters")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string ConfirmPassword { get; set; }
    }

    public class UserModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Company_ID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }


}