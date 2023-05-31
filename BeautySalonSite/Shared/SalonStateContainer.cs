namespace BeautySalonSite.Shared
{
    public class SalonStateContainer
    {
        public int SalonId { get; private set; }
        public event Action? OnStateChange;

        public void SetValue (int id)
        {
            SalonId = id;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
