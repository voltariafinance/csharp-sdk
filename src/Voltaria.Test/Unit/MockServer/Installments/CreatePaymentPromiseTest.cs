using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Installments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CreatePaymentPromiseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "installment_id": "installment_id",
              "amount": 1.1,
              "promised_date": "2023-01-15"
            }
            """;

        const string mockResponse = """
            {
              "id": "id",
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_at": "2024-01-15T09:30:00.000Z",
              "installment_id": "installment_id",
              "partner_id": "partner_id",
              "client_id": "client_id",
              "loan_id": "loan_id",
              "amount": "amount",
              "promised_date": "2023-01-15",
              "status": "active",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/installments/payment-promises")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Installments.CreatePaymentPromiseAsync(
            new PaymentPromiseCreatePayload
            {
                InstallmentId = "installment_id",
                Amount = 1.1,
                PromisedDate = new DateOnly(2023, 1, 15),
                Notes = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "installment_id": "inst_12345",
              "amount": 1.1,
              "promised_date": "2026-05-15"
            }
            """;

        const string mockResponse = """
            {
              "id": "ppromise_12345",
              "created_at": "2026-04-28T10:00:00.000Z",
              "updated_at": "2026-04-28T10:00:00.000Z",
              "installment_id": "inst_12345",
              "partner_id": "partner_12345",
              "client_id": "client_12345",
              "loan_id": "loan_12345",
              "amount": "1500.00",
              "promised_date": "2026-05-15",
              "status": "active",
              "notes": "notes"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/installments/payment-promises")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Installments.CreatePaymentPromiseAsync(
            new PaymentPromiseCreatePayload
            {
                InstallmentId = "inst_12345",
                Amount = 1.1,
                PromisedDate = new DateOnly(2026, 5, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
