namespace BeautySalonSite.Models.ServiceModels
{
    public class ServiceWithoutCategory
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public TimeSpan ExecutionTime { get; set; }
    }
}
