using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Recoveries;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListRecoveriesTest : BaseMockServerTest
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
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "amount": "amount",
                  "currency": "eur",
                  "recovery_date": "2023-01-15",
                  "notes": "notes"
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "amount": "amount",
                  "currency": "eur",
                  "recovery_date": "2023-01-15",
                  "notes": "notes"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/recoveries").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recoveries.ListRecoveriesAsync(new ListRecoveriesRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "recovery_abc123",
                  "created_at": "2026-07-15T10:00:00.000Z",
                  "updated_at": "2026-07-15T10:00:00.000Z",
                  "partner_id": "partner_123",
                  "client_id": "client_123",
                  "loan_id": "loan_abc123",
                  "amount": "1500.00",
                  "currency": "eur",
                  "recovery_date": "2026-07-15",
                  "notes": "notes"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/recoveries").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Recoveries.ListRecoveriesAsync(new ListRecoveriesRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
