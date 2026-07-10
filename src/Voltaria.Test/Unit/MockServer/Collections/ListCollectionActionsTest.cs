using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Collections;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListCollectionActionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "id",
                  "name": "name",
                  "action_type": "email",
                  "is_active": true,
                  "description": "description",
                  "timing": "timing"
                },
                {
                  "id": "id",
                  "name": "name",
                  "action_type": "email",
                  "is_active": true,
                  "description": "description",
                  "timing": "timing"
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
                    .WithPath("/v2/collection-actions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Collections.ListCollectionActionsAsync(
            new ListCollectionActionsRequest()
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
                  "id": "collection_action_123",
                  "name": "Overdue reminder email",
                  "action_type": "email",
                  "is_active": true,
                  "description": "description",
                  "timing": "d-5"
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
                    .WithPath("/v2/collection-actions")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Collections.ListCollectionActionsAsync(
            new ListCollectionActionsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
