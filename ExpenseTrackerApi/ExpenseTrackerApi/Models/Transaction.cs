namespace ExpenseTrackerApi.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }
        public int Transaction_Category_Id { get; set; }
        public string? Date_sCreated { get; set; }
    }
}
