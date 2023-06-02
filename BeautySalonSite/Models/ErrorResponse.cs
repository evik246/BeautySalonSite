namespace BeautySalonSite.Models
{
    public class ErrorResponse
    {
        public Dictionary<string, List<string>> Errors { get; set; } = new();
    }
}
