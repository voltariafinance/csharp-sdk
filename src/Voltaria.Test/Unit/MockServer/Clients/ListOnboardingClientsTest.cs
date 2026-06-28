using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListOnboardingClientsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "correlation_id": "correlation_id",
                  "name": "name",
                  "type": "corporate",
                  "jurisdiction": "eu",
                  "company_number": "company_number",
                  "status": "active",
                  "limits": [
                    {
                      "currency": "eur",
                      "max_maturity_days": 1,
                      "limit": "limit",
                      "rate": "rate",
                      "outstanding": "outstanding",
                      "available": "available",
                      "created_at": "2024-01-15T09:30:00.000Z",
                      "updated_at": "2024-01-15T09:30:00.000Z"
                    },
                    {
                      "currency": "eur",
                      "max_maturity_days": 1,
                      "limit": "limit",
                      "rate": "rate",
                      "outstanding": "outstanding",
                      "available": "available",
                      "created_at": "2024-01-15T09:30:00.000Z",
                      "updated_at": "2024-01-15T09:30:00.000Z"
                    }
                  ],
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  }
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "correlation_id": "correlation_id",
                  "name": "name",
                  "type": "corporate",
                  "jurisdiction": "eu",
                  "company_number": "company_number",
                  "status": "active",
                  "limits": [
                    {
                      "currency": "eur",
                      "max_maturity_days": 1,
                      "limit": "limit",
                      "rate": "rate",
                      "outstanding": "outstanding",
                      "available": "available",
                      "created_at": "2024-01-15T09:30:00.000Z",
                      "updated_at": "2024-01-15T09:30:00.000Z"
                    },
                    {
                      "currency": "eur",
                      "max_maturity_days": 1,
                      "limit": "limit",
                      "rate": "rate",
                      "outstanding": "outstanding",
                      "available": "available",
                      "created_at": "2024-01-15T09:30:00.000Z",
                      "updated_at": "2024-01-15T09:30:00.000Z"
                    }
                  ],
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  }
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
                    .WithPath("/v2/clients/onboarding")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListOnboardingClientsAsync(
            new ListOnboardingClientsRequest()
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
                  "id": "client_As2fD1gaX2",
                  "created_at": "2025-01-01T00:00:00.000Z",
                  "updated_at": "2025-01-01T00:00:00.000Z",
                  "correlation_id": "correlation_id",
                  "name": "ACME Corp",
                  "type": "corporate",
                  "jurisdiction": "eu",
                  "company_number": "company_number",
                  "status": "active",
                  "limits": [
                    {
                      "currency": "eur",
                      "max_maturity_days": 1,
                      "limit": "limit",
                      "rate": "rate",
                      "outstanding": "outstanding",
                      "available": "available",
                      "created_at": "2024-01-15T09:30:00.000Z",
                      "updated_at": "2024-01-15T09:30:00.000Z"
                    }
                  ],
                  "data": {
                    "key": "value"
                  }
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
                    .WithPath("/v2/clients/onboarding")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListOnboardingClientsAsync(
            new ListOnboardingClientsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
