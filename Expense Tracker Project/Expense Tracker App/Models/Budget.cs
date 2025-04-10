using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.Models
{
    public class Budget
    {
        [Key]
        public int BudgetId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater than 0")]
        public int Amount { get; set; }
    }
} 