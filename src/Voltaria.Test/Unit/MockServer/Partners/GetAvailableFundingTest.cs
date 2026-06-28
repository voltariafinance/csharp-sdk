using NUnit.Framework;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Partners;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAvailableFundingTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "currency": "eur",
                "limit": "limit",
                "later": "later",
                "max_maturity_days": 1,
                "rate": "rate",
                "outstanding": "outstanding",
                "available": "available"
              },
              {
                "currency": "eur",
                "limit": "limit",
                "later": "later",
                "max_maturity_days": 1,
                "rate": "rate",
                "outstanding": "outstanding",
                "available": "available"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/partners/available-funding")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Partners.GetAvailableFundingAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "currency": "usd",
                "limit": "100000.00",
                "later": "100000.00",
                "max_maturity_days": 30,
                "rate": "2.5",
                "outstanding": "10000.00",
                "available": "90000.00"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/partners/available-funding")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Partners.GetAvailableFundingAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
