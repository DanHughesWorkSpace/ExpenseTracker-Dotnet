namespace ExpenseTrackerApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Created_Date { get; set; }
        public int Created_By { get; set; }
    }
}
