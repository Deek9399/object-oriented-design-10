using SQLite;

namespace MauiApp1.Models;

public class User
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;  // Default to empty string
    public string Email { get; set; } = string.Empty;  // Default to empty string
    public string PasswordHash { get; set; } = string.Empty;  // Default to empty string

    public bool IsAdmin { get; set; } = false;  // Default to false

    public User() { }

    public User(string username, string email, string passwordHash, bool isAdmin = false)
    {
        Username = username;
        Email = email;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
    }
}