using System.ComponentModel.DataAnnotations;

namespace userMan.Models;

public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "First name is required")]
    public string FirstName { get; set; } = string.Empty;  
    [Required(ErrorMessage = "Last name is required")]
    public string LastName { get; set; } = string.Empty;  
    [Required(ErrorMessage = "Username is required")]
    public string Email { get; set; } = string.Empty;  
    [Required(ErrorMessage = "Password is required")]
    public string Department { get; set; }= string.Empty;  
}