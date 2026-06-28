using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Installments;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListPaymentPromisesTest : BaseMockServerTest
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
                  "installment_id": "installment_id",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "amount": "amount",
                  "promised_date": "2023-01-15",
                  "status": "active",
                  "notes": "notes"
                },
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
                    .WithPath("/v2/installments/payment-promises")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Installments.ListPaymentPromisesAsync(
            new ListPaymentPromisesRequest()
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
                    .WithPath("/v2/installments/payment-promises")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Installments.ListPaymentPromisesAsync(
            new ListPaymentPromisesRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
