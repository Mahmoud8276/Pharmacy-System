using System.ComponentModel.DataAnnotations;

namespace Pharmacy.System.Core.Dtos.AccountDtos
{
    public class ConfirmEmailDto
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
