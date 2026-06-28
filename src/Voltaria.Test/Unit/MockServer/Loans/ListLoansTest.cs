using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Loans;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListLoansTest : BaseMockServerTest
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
                  "amount": "amount",
                  "status": "pending",
                  "irr": "irr",
                  "loan_date": "2023-01-15",
                  "currency_rate": "currency_rate",
                  "correlation_id": "correlation_id",
                  "payment_status": "pending",
                  "payment_reference": "payment_reference",
                  "early_settlement_date": "2023-01-15",
                  "early_settlement_amount": "early_settlement_amount",
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  },
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
                  "amount": "amount",
                  "status": "pending",
                  "irr": "irr",
                  "loan_date": "2023-01-15",
                  "currency_rate": "currency_rate",
                  "correlation_id": "correlation_id",
                  "payment_status": "pending",
                  "payment_reference": "payment_reference",
                  "early_settlement_date": "2023-01-15",
                  "early_settlement_amount": "early_settlement_amount",
                  "data": {
                    "data": {
                      "key": "value"
                    }
                  },
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/loans").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.ListLoansAsync(new ListLoansRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "items": [
                {
                  "id": "loan_12345",
                  "created_at": "2023-05-01T10:00:00.000Z",
                  "updated_at": "2023-05-01T10:00:00.000Z",
                  "partner_id": "partner_1",
                  "client_id": "client_ACME",
                  "currency": "eur",
                  "amount": "50000.00",
                  "status": "pending",
                  "irr": "irr",
                  "loan_date": "2023-01-15",
                  "currency_rate": "1.00",
                  "correlation_id": "correlation_id",
                  "payment_status": "pending",
                  "payment_reference": "payment_reference",
                  "early_settlement_date": "2023-01-15",
                  "early_settlement_amount": "early_settlement_amount",
                  "data": {
                    "key": "value"
                  },
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
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/v2/loans").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Loans.ListLoansAsync(new ListLoansRequest());
        JsonAssert.AreEqual(response, mockResponse);
    }
}
