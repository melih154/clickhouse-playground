using System.ComponentModel.DataAnnotations;

namespace Clickhouse.Kata.API.Options
{
    public class ClickHouseConnectionSettings
    {
        public const string ClickHouseConnection = nameof(ClickHouseConnection);

        [Required]
        public required string Host { get; set; }

        [Required]
        public required string Port { get; set; }

        [Required]
        public required string Database { get; set; }

        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}
