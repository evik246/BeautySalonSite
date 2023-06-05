namespace BeautySalonSite.Models.ExceptionModels
{
    public class ConflictException : Exception
    {
        public ConflictException() { }

        public ConflictException(string message) : base(message) { }
    }
}
