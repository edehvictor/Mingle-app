using System.ComponentModel.DataAnnotations;
using API.DTOs.Users.Validations;

namespace API.DTOs.Users;

public class RegisterRequest
{
    private string? _firstname;
    [Required(ErrorMessage = " {0} is required!")]
    [MinLength(3, ErrorMessage = "{0}should be atleast 3 characters.")]
    // [StringLength(10, MinimumLength = 3, ErrorMessage = "{0}should be atleast 3 characters and not above 10 charcters.")]
    public string? Firstname { get => _firstname; set => _firstname = value?.Trim(); }
    private string? _lastname;
    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(3, ErrorMessage = "{0}should be atleast 3 characters.")]
    // [StringLength(10, MinimumLength = 3, ErrorMessage = "{0}should be atleast 3 characters and not above 10 charcters.")]
    public string? Lastname { get => _lastname; set => _lastname = value?.Trim(); }
    [Required(ErrorMessage = "{0} is required!")]
    [Gender(ErrorMessage ="{0} should be either 'male' or 'female!'")]
    public string? Gender { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    public DateTime DateOfBirth { get; set; }
    
    [Required(ErrorMessage = "{0} is required!")]
    [RegularExpression("^[0-9]*$", ErrorMessage ="Not a valid phone number.")]
    public string? Phonenumber { get; set; }

    [Required(ErrorMessage = "{0} is invalid!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(3, ErrorMessage = "{0}should be atleast 3 characters.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(3, ErrorMessage = "{0}should be atleast 3 characters.")]
    public string? City { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(3, ErrorMessage = "{0}should be atleast 3 characters.")]
    public string? Country { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [MinLength(6, ErrorMessage = "{0}should be atleast 6 characters.")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "{0} is required!")]
    [Compare(nameof(Password), ErrorMessage = "Password do  not match!")]
    public string? ConfirmPassword { get; set; }

}