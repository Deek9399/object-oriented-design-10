using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class BudgetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BudgetController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var budget = await _context.Budget.FirstOrDefaultAsync();
            var totalExpense = await _context.Transactions
                .Where(t => t.Category.Type == "Expense")
                .SumAsync(t => t.Amount);

            ViewBag.Budget = budget?.Amount ?? 0;
            ViewBag.TotalExpense = totalExpense;
            ViewBag.Remaining = (budget?.Amount ?? 0) - totalExpense;

            return View(budget ?? new Budget());
        }

        [HttpPost]
        public async Task<IActionResult> SetBudget([Bind("Amount")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                var existingBudget = await _context.Budget.FirstOrDefaultAsync();
                if (existingBudget != null)
                {
                    existingBudget.Amount = budget.Amount;
                    _context.Update(existingBudget);
                }
                else
                {
                    _context.Add(budget);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budget);
        }
    }
} 