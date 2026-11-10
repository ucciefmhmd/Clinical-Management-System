using System.ComponentModel.DataAnnotations;

namespace ClinicManagement.Core.Services
{
    internal static class EntityRules
    {
        /// <summary>Applies the entity's data-annotation rules (EF Core does not) and throws a user-facing error.</summary>
        public static void Validate(object entity)
        {
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(entity, new ValidationContext(entity), results, validateAllProperties: true))
                throw new ClinicValidationException(string.Join(Environment.NewLine, results.Select(r => r.ErrorMessage)));
        }

        public static void RequireSelection(int id, string what)
        {
            if (id <= 0)
                throw new ClinicValidationException($"Please select a {what} from the list first.");
        }

        public static ClinicValidationException NotFound(string what) =>
            new($"The selected {what} no longer exists. The list has been refreshed.");
    }

    /// <summary>Id + display name, used for combo boxes.</summary>
    public sealed record LookupItem(int Id, string Name);
}
