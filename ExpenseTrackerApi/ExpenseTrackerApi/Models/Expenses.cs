namespace ExpenseTrackerApi.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public int Expense_Category_Id { get; set; }
        public string? DateCreated { get; set; }
    }
}
