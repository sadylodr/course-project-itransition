using System.ComponentModel.DataAnnotations;

namespace CourseProject.ViewModels;

public class RegisterViewModel
{ 
    [Required] 
    [Display(Name = "Name")]
    public string DisplayName { get; set; }

    [Required] 
    [EmailAddress] 
    [Display(Name = "Email")] 
    public string Email { get; set; }
        
    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }
        
    [DataType(DataType.Password)]
    [Display(Name = "Retype your password")]
    [Compare("Password", ErrorMessage = "Passwords don't match")] 
    public string ConfirmPassword { get; set; }
}
