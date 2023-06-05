using BeautySalonSite.Models.SalonModels;

namespace BeautySalonSite.Models.EmployeeModels
{
    public class MasterWithPhotoAndSalon
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhotoPath { get; set; }

        public string? Specialization { get; set; }

        public SalonWithAddress? Salon { get; set; }

        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }
}
