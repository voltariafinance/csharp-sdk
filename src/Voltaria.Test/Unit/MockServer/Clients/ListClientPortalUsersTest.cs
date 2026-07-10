using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ListClientPortalUsersTest : BaseMockServerTest
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
                  "client_id": "client_id",
                  "email": "email",
                  "role_id": "role_id",
                  "role": {
                    "id": "id",
                    "name": "name",
                    "type": "type"
                  },
                  "status": "pending",
                  "is_email_verified": true,
                  "kyc_status": "not_started",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "phone": "phone",
                  "is_2fa_enabled": true,
                  "is_2fa_required": true,
                  "created_at": "2024-01-15T09:30:00.000Z",
                  "updated_at": "2024-01-15T09:30:00.000Z"
                },
                {
                  "id": "id",
                  "partner_id": "partner_id",
                  "client_id": "client_id",
                  "email": "email",
                  "role_id": "role_id",
                  "role": {
                    "id": "id",
                    "name": "name",
                    "type": "type"
                  },
                  "status": "pending",
                  "is_email_verified": true,
                  "kyc_status": "not_started",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "phone": "phone",
                  "is_2fa_enabled": true,
                  "is_2fa_required": true,
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
                    .WithPath("/v2/clients/client_id/users")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientPortalUsersAsync(
            new ListClientPortalUsersRequest { ClientId = "client_id" }
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
                  "id": "cu_abc123",
                  "partner_id": "partner_abc123",
                  "client_id": "client_abc123",
                  "email": "jane.doe@acme.com",
                  "role_id": "role_abc123",
                  "role": {
                    "id": "id",
                    "name": "name",
                    "type": "type"
                  },
                  "status": "pending",
                  "is_email_verified": true,
                  "kyc_status": "not_started",
                  "first_name": "first_name",
                  "last_name": "last_name",
                  "phone": "phone",
                  "is_2fa_enabled": false,
                  "is_2fa_required": false,
                  "created_at": "2024-01-15T10:30:00.000Z",
                  "updated_at": "2024-01-15T10:30:00.000Z"
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
                    .WithPath("/v2/clients/client_id/users")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Clients.ListClientPortalUsersAsync(
            new ListClientPortalUsersRequest { ClientId = "client_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
