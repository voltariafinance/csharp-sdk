using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Accounts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetClientAccountTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "account_holder_name": "account_holder_name",
              "label": "label",
              "account_holder_type": "private",
              "currency": "eur",
              "sort_code": "sort_code",
              "account_number": "account_number",
              "iban": "iban",
              "bic": "bic",
              "routing_number": "routing_number",
              "account_type": "account_type",
              "address": {
                "country": "country",
                "city": "city",
                "postal_code": "postal_code",
                "state": "state",
                "line1": "line1"
              },
              "status": "active"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/accounts/account_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Accounts.GetClientAccountAsync(
            new GetClientAccountRequest { ClientId = "client_id", AccountId = "account_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "account_abc123",
              "account_holder_name": "Acme Ltd",
              "label": "Main GBP account",
              "account_holder_type": "business",
              "currency": "gbp",
              "sort_code": "40-47-84",
              "account_number": "12345678",
              "iban": "iban",
              "bic": "bic",
              "routing_number": "routing_number",
              "account_type": "account_type",
              "address": {
                "country": "US",
                "city": "New York",
                "postal_code": "10001",
                "state": "state",
                "line1": "123 Main St"
              },
              "status": "pending"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/accounts/account_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Accounts.GetClientAccountAsync(
            new GetClientAccountRequest { ClientId = "client_id", AccountId = "account_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
