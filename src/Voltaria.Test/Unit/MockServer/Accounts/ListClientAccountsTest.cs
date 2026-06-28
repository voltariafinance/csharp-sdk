using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Accounts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListClientAccountsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
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
                },
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
              ],
              "page": 1,
              "page_size": 1,
              "items_in_page": 1,
              "total_items": 1,
              "total_pages": 1,
              "has_next": true,
              "has_previous": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/accounts")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Accounts.ListClientAccountsAsync(
            new ListClientAccountsRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
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
                    "line1": "123 Main St"
                  },
                  "status": "pending"
                }
              ],
              "page": 1,
              "page_size": 1,
              "items_in_page": 1,
              "total_items": 1,
              "total_pages": 1,
              "has_next": true,
              "has_previous": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/accounts")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Accounts.ListClientAccountsAsync(
            new ListClientAccountsRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
