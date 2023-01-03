using MailKit.Net.Smtp;

namespace OnlineClothes.Application.Apply.Services.Mailing;

public interface IMailingProviderConnection
{
	bool IsConnected { get; }

	ISmtpClient SmtpClient();

	bool RetryConnect();
}
