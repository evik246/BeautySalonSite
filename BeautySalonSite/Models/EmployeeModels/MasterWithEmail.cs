namespace BeautySalonSite.Models.EmployeeModels
{
    public class MasterWithEmail
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

        public string? Specialization { get; set; }

        public string Email { get; set; } = string.Empty;

        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }
}
