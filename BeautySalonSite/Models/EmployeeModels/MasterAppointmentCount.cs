namespace BeautySalonSite.Models.EmployeeModels
{
    public class MasterAppointmentCount
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string? Specialization { get; set; }

        public long AppointmentsCount { get; set; }

        public override string ToString()
        {
            return Name + " " + LastName;
        }
    }
}
