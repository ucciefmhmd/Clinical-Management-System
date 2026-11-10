namespace ClinicManagement.Core
{
    /// <summary>A rule was broken by user input; the message is meant to be shown to the user.</summary>
    public sealed class ClinicValidationException : Exception
    {
        public ClinicValidationException(string message) : base(message)
        {
        }
    }
}
