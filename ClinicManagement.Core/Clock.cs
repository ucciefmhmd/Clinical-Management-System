namespace ClinicManagement.Core
{
    /// <summary>Abstraction over the current local time so "today" logic can be tested.</summary>
    public interface IClock
    {
        DateTime Now { get; }
    }

    public sealed class SystemClock : IClock
    {
        public static readonly SystemClock Instance = new();

        public DateTime Now => DateTime.Now;
    }
}
