namespace ApiCRUDWeb.Aplication.Configuration
{
    internal static class Settings
    {
		public static string PrivateKey { get; set; } = Environment.GetEnvironmentVariable("PrivateKey");
	}
}
