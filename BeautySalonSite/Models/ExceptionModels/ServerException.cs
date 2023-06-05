namespace BeautySalonSite.Models.ExceptionModels
{
    public class ServerException : Exception
    {
        public ServerException() { }

        public ServerException(string message) : base(message) { }
    }
}
