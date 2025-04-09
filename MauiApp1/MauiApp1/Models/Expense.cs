using SQLite;

namespace MauiApp1.Models;

public class Expense
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int UserId { get; set; } = 0;  // Default to 0 if not provided

    public string Description { get; set; } = string.Empty;  // Default to empty string
    public decimal Amount { get; set; } = 0m;  // Default to 0
    public string Category { get; set; } = string.Empty;  // Default to empty string
    public DateTime Date { get; set; } = DateTime.MinValue;  // Default to DateTime.MinValue

    public Expense() { }

    public Expense(int userId, string description, decimal amount, string category, DateTime date)
    {
        UserId = userId;
        Description = description;
        Amount = amount;
        Category = category;
        Date = date;
    }
}