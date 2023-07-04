using Microsoft.Identity.Client;

namespace ExpenseTrackerApi.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
