namespace BeautySalonSite.Models.CustomerModels
{
    public class FullCustomer
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateOnly? Birthday { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
    }
}
