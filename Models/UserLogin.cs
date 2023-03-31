using System.ComponentModel.DataAnnotations;

public class UserLogin
{
    [Required]
    [UIHint("email")] // ensures the taghelper renders the appropriate form field
    public string Email { get; set; }

    [Required]
    [UIHint("password")] // ensures the taghelper renders the appropriate form field
    public string Password { get; set; }
}
