using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Partners;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPartnerWaterfallsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "partner_id": "partner_id",
                  "name": "name",
                  "date": "2023-01-15",
                  "status": "pending",
                  "cash_balance": "cash_balance",
                  "cash_balance_currency": "cash_balance_currency",
                  "cash_balance_date": "2023-01-15",
                  "file_url": "file_url",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "partner_id": "partner_id",
                  "name": "name",
                  "date": "2023-01-15",
                  "status": "pending",
                  "cash_balance": "cash_balance",
                  "cash_balance_currency": "cash_balance_currency",
                  "cash_balance_date": "2023-01-15",
                  "file_url": "file_url",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v2/partners/waterfalls")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Partners.ListPartnerWaterfallsAsync(
            new ListPartnerWaterfallsRequest()
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
                  "id": "id",
                  "partner_id": "partner_id",
                  "name": "name",
                  "date": "2023-01-15",
                  "status": "pending",
                  "cash_balance": "cash_balance",
                  "cash_balance_currency": "cash_balance_currency",
                  "cash_balance_date": "2023-01-15",
                  "file_url": "file_url",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
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
                    .WithPath("/v2/partners/waterfalls")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Partners.ListPartnerWaterfallsAsync(
            new ListPartnerWaterfallsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
