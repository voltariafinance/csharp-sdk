using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Investors;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class InvestorListRepaymentsTest : BaseMockServerTest
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
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "amount": "amount",
                  "repayment_date": "2024-01-15T09:30:00.000Z",
                  "type": "type",
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  },
                  "is_early_settlement": true,
                  "principal_amount": "principal_amount",
                  "interest_amount": "interest_amount",
                  "late_fee_amount": "late_fee_amount",
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
                  "client_id": "client_id",
                  "loan_id": "loan_id",
                  "installment_id": "installment_id",
                  "amount": "amount",
                  "repayment_date": "2024-01-15T09:30:00.000Z",
                  "type": "type",
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  },
                  "is_early_settlement": true,
                  "principal_amount": "principal_amount",
                  "interest_amount": "interest_amount",
                  "late_fee_amount": "late_fee_amount",
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
                    .WithPath("/v2/investors/repayments")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListRepaymentsAsync(
            new InvestorListRepaymentsRequest()
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
                  "id": "repayment_log_123",
                  "created_at": "2023-10-01T12:00:00.000Z",
                  "client_id": "client_123",
                  "loan_id": "loan_456",
                  "installment_id": "installment_789",
                  "amount": "1000.00",
                  "repayment_date": "2024-01-15T09:30:00.000Z",
                  "type": "type",
                  "data": {
                    "key": "value"
                  },
                  "is_early_settlement": true,
                  "principal_amount": "principal_amount",
                  "interest_amount": "interest_amount",
                  "late_fee_amount": "late_fee_amount",
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
                    .WithPath("/v2/investors/repayments")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Investors.InvestorListRepaymentsAsync(
            new InvestorListRepaymentsRequest()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
