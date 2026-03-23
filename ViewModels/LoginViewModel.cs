using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    public int LoginAttempts { get; set; }

    public bool IsLocked => LoginAttempts >= 5;
}