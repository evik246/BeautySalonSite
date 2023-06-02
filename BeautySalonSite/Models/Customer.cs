namespace BeautySalonSite.Models
{
    public class Customer
    {
        public string Name { get; set; } = string.Empty;

        public DateOnly? Birthday { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
