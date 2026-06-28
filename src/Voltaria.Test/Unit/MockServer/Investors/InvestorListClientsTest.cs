using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Investors;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InvestorListClientsTest : BaseMockServerTest
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
                  "status": "active"
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
                    .WithPath("/v2/investors/clients")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListClientsAsync(
            new InvestorListClientsRequest()
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
                    .WithPath("/v2/investors/clients")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListClientsAsync(
            new InvestorListClientsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
