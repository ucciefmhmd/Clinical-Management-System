using C_sharp_Project.YoussifMohamed.Model.Database;
using ClinicManagement.Core;
using ClinicManagement.Core.Security;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Tests
{
    /// <summary>
    /// A private SQLite in-memory database (real relational provider, foreign keys enforced)
    /// shared by every short-lived ClinicDB the services create during one test.
    /// </summary>
    public sealed class TestDatabase : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly DbContextOptions<ClinicDB> _options;

        public TestDatabase()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();
            _options = new DbContextOptionsBuilder<ClinicDB>().UseSqlite(_connection).Options;
            using var db = Create();
            db.Database.EnsureCreated();
        }

        /// <summary>Low iteration count keeps the suite fast; the format and logic are the same.</summary>
        public static PasswordHasher FastHasher { get; } = new(iterations: 1_000);

        public FakeClock Clock { get; } = new(new DateTime(2026, 3, 10, 12, 0, 0));

        public ClinicDB Create() => new(_options);

        public void Dispose() => _connection.Dispose();
    }

    public sealed class FakeClock : IClock
    {
        public FakeClock(DateTime now) => Now = now;

        public DateTime Now { get; set; }
    }
}
