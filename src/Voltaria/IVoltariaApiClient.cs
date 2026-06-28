namespace Voltaria;

public partial interface IVoltariaApiClient
{
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
