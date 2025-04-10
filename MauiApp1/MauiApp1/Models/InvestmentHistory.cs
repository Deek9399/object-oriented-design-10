using SQLite;

namespace MauiApp1.Models;
public class InvestmentHistory
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int InvestmentId { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }

    public InvestmentHistory() { }

    public InvestmentHistory(int investmentId, decimal value, DateTime date)
    {
        InvestmentId = investmentId;
        Value = value;
        Date = date;
    }
}