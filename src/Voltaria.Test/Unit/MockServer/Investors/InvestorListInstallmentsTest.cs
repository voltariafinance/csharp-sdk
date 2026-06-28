using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Investors;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InvestorListInstallmentsTest : BaseMockServerTest
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
                  "currency": "eur",
                  "status": "active",
                  "loan_id": "loan_id",
                  "amount": "amount",
                  "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                  "installment_number": 1,
                  "installments": 1,
                  "principal": "principal",
                  "interest": "interest",
                  "repayment_amount": "repayment_amount",
                  "repayment_at": "2024-01-15T09:30:00.000Z",
                  "client": {
                    "name": "name",
                    "type": "corporate",
                    "jurisdiction": "eu",
                    "company_number": "company_number",
                    "status": "active"
                  }
                },
                {
                  "id": "id",
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "currency": "eur",
                  "status": "active",
                  "loan_id": "loan_id",
                  "amount": "amount",
                  "expected_repayment_at": "2024-01-15T09:30:00.000Z",
                  "installment_number": 1,
                  "installments": 1,
                  "principal": "principal",
                  "interest": "interest",
                  "repayment_amount": "repayment_amount",
                  "repayment_at": "2024-01-15T09:30:00.000Z",
                  "client": {
                    "name": "name",
                    "type": "corporate",
                    "jurisdiction": "eu",
                    "company_number": "company_number",
                    "status": "active"
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
                    .WithPath("/v2/investors/installments")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListInstallmentsAsync(
            new InvestorListInstallmentsRequest()
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
                  "id": "installment_12345",
                  "created_at": "2025-01-01T00:00:00.000Z",
                  "updated_at": "2025-01-01T00:00:00.000Z",
                  "partner_id": "partner_12345",
                  "client_id": "client_12345",
                  "currency": "eur",
                  "status": "active",
                  "loan_id": "loan_12345",
                  "amount": "1000.00",
                  "expected_repayment_at": "2025-01-01T00:00:00.000Z",
                  "installment_number": 1,
                  "installments": 6,
                  "principal": "800.00",
                  "interest": "200.00",
                  "repayment_amount": "repayment_amount",
                  "repayment_at": "2024-01-15T09:30:00.000Z",
                  "client": {
                    "name": "ACME Corp",
                    "type": "corporate",
                    "jurisdiction": "eu",
                    "status": "active"
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
                    .WithPath("/v2/investors/installments")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListInstallmentsAsync(
            new InvestorListInstallmentsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
