namespace ApiCRUDWeb.Domain.Configuration
{
    public static class Settings
    {
		public static string PrivateKey { get; set; } = Environment.GetEnvironmentVariable("PrivateKey");

	}
}
