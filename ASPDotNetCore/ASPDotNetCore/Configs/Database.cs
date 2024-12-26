namespace ASPDotNetCore.Configs
{
    public class DatabaseOptions
    {
        public const string Database = "Database";

        public string PostgresUser { get; set; } = String.Empty;
        public string PostgresPassword { get; set; } = String.Empty;
        public string PostgresDatabase { get; set; } = String.Empty;
        public string PostgresData { get; set; } = String.Empty;
    }
}
