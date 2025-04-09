using SQLite;

namespace MauiApp1.Models;

public class Budget
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int UserId { get; set; } = 0;  // Default to 0 if not provided

    public string Category { get; set; } = string.Empty;  // Default to empty string
    public decimal Limit { get; set; } = 0m;  // Default to 0
    public decimal Spent { get; set; } = 0m;  // Default to 0

    public Budget() { }

    public Budget(int userId, string category, decimal limit, decimal spent = 0)
    {
        UserId = userId;
        Category = category;
        Limit = limit;
        Spent = spent;
    }
}