namespace OnlineClothes.Application.Apply.Services.Mailing.Models;

public class MailingProviderConfiguration
{
	public bool LocalEnv { get; set; }
	public string Host { get; set; } = null!;
	public ushort Port { get; set; }
	public bool StartTls { get; set; }
	public string Username { get; set; } = null!;
	public string Password { get; set; } = null!;
	public string? EmailFrom { get; set; }
}
