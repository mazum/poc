namespace SecretsManagement.Api.Configuration;

public class DatabaseSettings
{
    public const string SectionName = "Database";

    public string Region { get; set; }
    public string SecretName { get; set; }
}