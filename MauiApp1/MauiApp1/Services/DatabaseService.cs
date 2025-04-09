using SQLite;
using MauiApp1.Models;

namespace MauiApp1.Services;

public class DatabaseService
{
    private static SQLiteAsyncConnection _database = null!; // Fix for the null warning

    private static bool _initialized = false;

    public static async Task InitAsync()
    {
        if (_initialized)
            return;

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "financeapp.db3");
        _database = new SQLiteAsyncConnection(dbPath); // Initialized here

        await _database.CreateTableAsync<User>();
        await _database.CreateTableAsync<Investment>();
        await _database.CreateTableAsync<Expense>();
        await _database.CreateTableAsync<Budget>();

        _initialized = true;
    }

    public static async Task PrintAllUsersAsync()
    {
        var users = await GetUsersAsync();
        foreach (var user in users)
        {
            System.Diagnostics.Debug.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}, PasswordHash: {user.PasswordHash}, IsAdmin: {user.IsAdmin}");
        }
    }


    // ---------- USER ----------
    public static Task<List<User>> GetUsersAsync() =>
        _database.Table<User>().ToListAsync();

    public static Task<User> GetUserByEmailAsync(string email) =>
        _database.Table<User>().FirstOrDefaultAsync(u => u.Email == email);

    public static Task<int> AddUserAsync(User user) =>
        _database.InsertAsync(user);

    // ---------- INVESTMENT ----------
    public static Task<List<Investment>> GetInvestmentsForUserAsync(int userId) =>
        _database.Table<Investment>().Where(i => i.UserId == userId).ToListAsync();

    public static Task<int> AddInvestmentAsync(Investment investment) =>
        _database.InsertAsync(investment);

    // ---------- EXPENSE ----------
    public static Task<List<Expense>> GetExpensesForUserAsync(int userId) =>
        _database.Table<Expense>().Where(e => e.UserId == userId).ToListAsync();

    public static Task<int> AddExpenseAsync(Expense expense) =>
        _database.InsertAsync(expense);

    // ---------- BUDGET ----------
    public static Task<List<Budget>> GetBudgetsForUserAsync(int userId) =>
        _database.Table<Budget>().Where(b => b.UserId == userId).ToListAsync();

    public static Task<int> AddBudgetAsync(Budget budget) =>
        _database.InsertAsync(budget);
}