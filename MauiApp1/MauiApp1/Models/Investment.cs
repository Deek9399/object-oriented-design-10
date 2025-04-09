using SQLite;

namespace MauiApp1.Models;

public class Investment
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int UserId { get; set; } = 0;  // Default to 0 if not provided

    public string Name { get; set; } = string.Empty;  // Default to empty string
    public string Type { get; set; } = string.Empty;  // Default to empty string
    public decimal InitialValue { get; set; } = 0m;  // Default to 0
    public decimal CurrentValue { get; set; } = 0m;  // Default to 0
    public DateTime DateAcquired { get; set; } = DateTime.MinValue;  // Default to DateTime.MinValue
    public string Notes { get; set; } = string.Empty;  // Default to empty string

    public Investment() { }

    public Investment(int userId, string name, string type, decimal initialValue, decimal currentValue, DateTime dateAcquired, string notes)
    {
        UserId = userId;
        Name = name;
        Type = type;
        InitialValue = initialValue;
        CurrentValue = currentValue;
        DateAcquired = dateAcquired;
        Notes = notes;
    }
}