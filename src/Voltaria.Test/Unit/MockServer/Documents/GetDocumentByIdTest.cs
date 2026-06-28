using NUnit.Framework;
using Voltaria;
using Voltaria.Test.Unit.MockServer;
using Voltaria.Test.Utils;

namespace Voltaria.Test.Unit.MockServer.Documents;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetDocumentByIdTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "id": "id",
              "category": "category",
              "file_name": "file_name",
              "file_type": "file_type",
              "client_id": "client_id",
              "file_url": "file_url",
              "loan_id": "loan_id",
              "installment_id": "installment_id",
              "folder_path": "folder_path",
              "document_date": "2023-01-15",
              "expiry_date": "2023-01-15",
              "created_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/documents/document_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Documents.GetDocumentByIdAsync(
            new GetDocumentByIdRequest { DocumentId = "document_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "id": "id",
              "category": "category",
              "file_name": "file_name",
              "file_type": "file_type",
              "client_id": "client_id",
              "file_url": "file_url",
              "loan_id": "loan_id",
              "installment_id": "installment_id",
              "folder_path": "folder_path",
              "document_date": "2023-01-15",
              "expiry_date": "2023-01-15",
              "created_at": "2024-01-15T09:30:00.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2/documents/document_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Documents.GetDocumentByIdAsync(
            new GetDocumentByIdRequest { DocumentId = "document_id" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
