using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Drawdowns;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListDrawdownsTest : BaseMockServerTest
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
                  "currency": "eur",
                  "amount": "amount",
                  "status": "requested",
                  "drawdown_date": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "currency": "eur",
                  "amount": "amount",
                  "status": "requested",
                  "drawdown_date": "2024-01-15T09:30:00.000Z"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/drawdowns").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Drawdowns.ListDrawdownsAsync(new ListDrawdownsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "drawdown_12345",
                  "created_at": "2023-10-05T14:48:00.000Z",
                  "updated_at": "2023-10-06T10:15:00.000Z",
                  "currency": "eur",
                  "amount": "1000.00",
                  "status": "requested",
                  "drawdown_date": "2023-10-05T14:48:00.000Z"
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/drawdowns").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Drawdowns.ListDrawdownsAsync(new ListDrawdownsRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
