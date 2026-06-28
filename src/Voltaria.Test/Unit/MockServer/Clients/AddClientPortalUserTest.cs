using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Clients;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AddClientPortalUserTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "first_name": "first_name",
              "last_name": "last_name",
              "email": "email",
              "role_type": "role_type"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/users")
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

        var response = await Client.Clients.AddClientPortalUserAsync(
            new ClientUserInviteRequest
            {
                ClientId = "client_id",
                FirstName = "first_name",
                LastName = "last_name",
                Email = "email",
                Phone = null,
                RoleType = "role_type",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "first_name": "first_name",
              "last_name": "last_name",
              "email": "email",
              "role_type": "role_type"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/clients/client_id/users")
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

        var response = await Client.Clients.AddClientPortalUserAsync(
            new ClientUserInviteRequest
            {
                ClientId = "client_id",
                FirstName = "first_name",
                LastName = "last_name",
                Email = "email",
                RoleType = "role_type",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
