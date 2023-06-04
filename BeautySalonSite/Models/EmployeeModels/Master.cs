namespace BeautySalonSite.Models.EmployeeModels
{
    public class Master
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

        public string? Specialization { get; set; }
    }
}
