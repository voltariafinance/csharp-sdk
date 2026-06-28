using Voltaria.Core;

namespace Voltaria;

public partial class VoltariaApiClient : IVoltariaApiClient
{
    private readonly RawClient _client;

    public VoltariaApiClient(string? token = null, ClientOptions? clientOptions = null)
    {
        clientOptions ??= new ClientOptions();
        var platformHeaders = new Headers(
            new Dictionary<string, string>()
            {
                { "X-Fern-Language", "C#" },
                { "X-Fern-SDK-Name", "Voltaria" },
                { "X-Fern-SDK-Version", Version.Current },
            }
        );
        foreach (var header in platformHeaders)
        {
            if (!clientOptions.Headers.ContainsKey(header.Key))
            {
                clientOptions.Headers[header.Key] = header.Value;
            }
        }
        var clientOptionsWithAuth = clientOptions.Clone();
        var authHeaders = new Headers(
            new Dictionary<string, string>() { { "Authorization", $"Bearer {token ?? ""}" } }
        );
        foreach (var header in authHeaders)
        {
            clientOptionsWithAuth.Headers[header.Key] = header.Value;
        }
        _client = new RawClient(clientOptionsWithAuth);
        Clients = new ClientsClient(_client);
        Sandbox = new SandboxClient(_client);
        Accounts = new AccountsClient(_client);
        Documents = new DocumentsClient(_client);
        Investors = new InvestorsClient(_client);
        Installments = new InstallmentsClient(_client);
        Loans = new LoansClient(_client);
        Partners = new PartnersClient(_client);
        Webhooks = new WebhooksClient(_client);
        Repayments = new RepaymentsClient(_client);
        Drawdowns = new DrawdownsClient(_client);
    }

    public IClientsClient Clients { get; }

    public ISandboxClient Sandbox { get; }

    public IAccountsClient Accounts { get; }

    public IDocumentsClient Documents { get; }

    public IInvestorsClient Investors { get; }

    public IInstallmentsClient Installments { get; }

    public ILoansClient Loans { get; }

    public IPartnersClient Partners { get; }

    public IWebhooksClient Webhooks { get; }

    public IRepaymentsClient Repayments { get; }

    public IDrawdownsClient Drawdowns { get; }
}
