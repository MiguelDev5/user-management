public class Account
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public int LoginAttempts { get; set; }
    public bool IsLocked { get; set; }
    public DateTime CreatedAt { get; set; }
}