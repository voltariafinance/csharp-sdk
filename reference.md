# Reference
## Clients
<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ListClientsAsync</a>(ListClientsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of all clients associated with your partner account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListClientsAsync(new ListClientsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">CreateClientAsync</a>(ClientCreatePayload { ... }) -> WithRawResponseTask&lt;ClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new client under your partner account. The client will remain in a pending state until reviewed by Winyield.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.CreateClientAsync(
    new ClientCreatePayload { Name = "ACME Corp", Jurisdiction = JurisdictionEnum.Eu }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ClientCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">CreateClientDataAsync</a>(ClientDataCreatePayload { ... }) -> WithRawResponseTask&lt;ClientDataResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Upload supplementary client information, such as bank account balance, accounting figures, or other relevant details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.CreateClientDataAsync(
    new ClientDataCreatePayload
    {
        ClientId = "client_123",
        Data = new Dictionary<string, object?>() { { "key1", "value1" }, { "key2", "value2" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ClientDataCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ListLimitRequestsAsync</a>(ListLimitRequestsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseLimitRequestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of all limit requests associated with your partner account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListLimitRequestsAsync(new ListLimitRequestsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListLimitRequestsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">CreateLimitRequestAsync</a>(LimitRequestCreatePayload { ... }) -> WithRawResponseTask&lt;LimitRequestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a limit review request for a client. The request will remain in a pending state until reviewed by Winyield.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.CreateLimitRequestAsync(
    new LimitRequestCreatePayload
    {
        ClientId = "client_1234567890abcdef",
        RequestedLimit = 1.1,
        Reason = "Need more credit for business expansion",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LimitRequestCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">GetLimitRequestAsync</a>(GetLimitRequestRequest { ... }) -> WithRawResponseTask&lt;LimitRequestResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific limit request by its ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.GetLimitRequestAsync(new GetLimitRequestRequest { RequestId = "request_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetLimitRequestRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ListOnboardingClientsAsync</a>(ListOnboardingClientsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all clients that have self-registered via the portal and are awaiting partner approval.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListOnboardingClientsAsync(new ListOnboardingClientsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListOnboardingClientsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ApproveOnboardingAsync</a>(ApproveOnboardingRequest { ... }) -> WithRawResponseTask&lt;ClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Accept a self-onboarded client. The client status moves to 'pending' and the owner's portal account is activated so they can begin submitting documents.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ApproveOnboardingAsync(
    new ApproveOnboardingRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ApproveOnboardingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">RejectOnboardingAsync</a>(RejectOnboardingRequest { ... }) -> WithRawResponseTask&lt;ClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Reject a self-onboarded client. The client record is kept with 'rejected' status for audit history and is not deleted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.RejectOnboardingAsync(new RejectOnboardingRequest { ClientId = "client_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RejectOnboardingRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">AddClientPortalUserAsync</a>(ClientUserInviteRequest { ... }) -> WithRawResponseTask&lt;ClientUserResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Invite a new user to a client's portal account. The invited user will receive an email with a one-time link to set their password. Partner can assign any role: 'owner', 'admin', or 'viewer'.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.AddClientPortalUserAsync(
    new ClientUserInviteRequest
    {
        ClientId = "client_id",
        FirstName = "first_name",
        LastName = "last_name",
        Email = "email",
        RoleType = "role_type",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ClientUserInviteRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ListClientWaiversAsync</a>(ListClientWaiversRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseWaiverResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all waivers associated with a specific client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListClientWaiversAsync(
    new ListClientWaiversRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientWaiversRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">GetClientByIdAsync</a>(GetClientByIdRequest { ... }) -> WithRawResponseTask&lt;ClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed information for a specific client using their client ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.GetClientByIdAsync(new GetClientByIdRequest { ClientId = "client_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetClientByIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">DeleteClientAsync</a>(DeleteClientRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a client by ID. Only clients with 'pending' status can be deleted. All client's loans must also be in 'pending' status.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.DeleteClientAsync(new DeleteClientRequest { ClientId = "client_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteClientRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Clients.<a href="/src/Voltaria/Clients/ClientsClient.cs">ListClientChecklistSummariesAsync</a>(ListClientChecklistSummariesRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseChecklistSummaryPartnerResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve the checklist summaries for one of your clients, including the AI description and item completion counts.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Clients.ListClientChecklistSummariesAsync(
    new ListClientChecklistSummariesRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientChecklistSummariesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Sandbox
<details><summary><code>client.Sandbox.<a href="/src/Voltaria/Sandbox/SandboxClient.cs">UpdateClientAsync</a>(ClientUpdateSandbox { ... }) -> WithRawResponseTask&lt;ClientResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an existing client's status or credit limit using their client ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sandbox.UpdateClientAsync(new ClientUpdateSandbox { ClientId = "client_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ClientUpdateSandbox` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sandbox.<a href="/src/Voltaria/Sandbox/SandboxClient.cs">UpdateLoanAsync</a>(LoanUpdateSandbox { ... }) -> WithRawResponseTask&lt;LoanResponseWithInstallments&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update the status of a specific loan using its unique loan ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sandbox.UpdateLoanAsync(new LoanUpdateSandbox { LoanId = "loan_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LoanUpdateSandbox` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Sandbox.<a href="/src/Voltaria/Sandbox/SandboxClient.cs">WebhookTestAsync</a>(WebhookTestSandbox { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Test a webhook subscription by ID or trigger all by event type.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Sandbox.WebhookTestAsync(
    new WebhookTestSandbox { EventType = WebhookEventTypeEnum.LoanUpdated }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WebhookTestSandbox` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Accounts
<details><summary><code>client.Accounts.<a href="/src/Voltaria/Accounts/AccountsClient.cs">ListClientAccountFieldsAsync</a>(ListClientAccountFieldsRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, CurrencyFieldSpec&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Return the required and optional bank account fields for each supported currency. Fetch once and cache; use it to build the create-account request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Accounts.ListClientAccountFieldsAsync(
    new ListClientAccountFieldsRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientAccountFieldsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Accounts.<a href="/src/Voltaria/Accounts/AccountsClient.cs">ListClientAccountsAsync</a>(ListClientAccountsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseClientAccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all bank accounts for one of your clients.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Accounts.ListClientAccountsAsync(
    new ListClientAccountsRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListClientAccountsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Accounts.<a href="/src/Voltaria/Accounts/AccountsClient.cs">CreateClientAccountAsync</a>(PartnerClientAccountCreateRequest { ... }) -> WithRawResponseTask&lt;ClientAccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a bank account for one of your clients. The account is registered with the payment provider immediately. Use the `status` field to create it as `active` (default; demotes any existing active account in the same currency to `passive`) or `passive`.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Accounts.CreateClientAccountAsync(
    new PartnerClientAccountCreateRequest
    {
        ClientId = "client_id",
        AccountHolderName = "Acme Ltd",
        AccountHolderType = AccountHolderTypeEnum.Business,
        Currency = CurrencyEnum.Gbp,
        SortCode = "40-47-84",
        AccountNumber = "12345678",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PartnerClientAccountCreateRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Accounts.<a href="/src/Voltaria/Accounts/AccountsClient.cs">GetClientAccountAsync</a>(GetClientAccountRequest { ... }) -> WithRawResponseTask&lt;ClientAccountResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific bank account for one of your clients.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Accounts.GetClientAccountAsync(
    new GetClientAccountRequest { ClientId = "client_id", AccountId = "account_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetClientAccountRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Documents
<details><summary><code>client.Documents.<a href="/src/Voltaria/Documents/DocumentsClient.cs">ListDocumentsAsync</a>(ListDocumentsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseDocumentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all documents linked to a client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.ListDocumentsAsync(new ListDocumentsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDocumentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/Voltaria/Documents/DocumentsClient.cs">UploadDocumentAsync</a>(DocumentCreatePayload { ... }) -> WithRawResponseTask&lt;DocumentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Upload a new document related to a client or loan, such as financial statements or KYC files.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.UploadDocumentAsync(
    new DocumentCreatePayload { Category = "category", FileName = "file_name" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DocumentCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/Voltaria/Documents/DocumentsClient.cs">GetAvailableDocumentCategoriesAsync</a>() -> WithRawResponseTask&lt;AvailableDocumentCategoriesResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all available document categories.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.GetAvailableDocumentCategoriesAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/Voltaria/Documents/DocumentsClient.cs">GetDocumentByIdAsync</a>(GetDocumentByIdRequest { ... }) -> WithRawResponseTask&lt;DocumentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a specific document using its document ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.GetDocumentByIdAsync(
    new GetDocumentByIdRequest { DocumentId = "document_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetDocumentByIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Documents.<a href="/src/Voltaria/Documents/DocumentsClient.cs">DeleteDocumentAsync</a>(DeleteDocumentRequest { ... })</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a specific document by using its document ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Documents.DeleteDocumentAsync(
    new DeleteDocumentRequest { DocumentId = "document_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteDocumentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Investors
<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorListClientsAsync</a>(InvestorListClientsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseClientInvestorResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all clients with at least one loan funded by this investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorListClientsAsync(new InvestorListClientsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorListClientsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorGetClientAsync</a>(InvestorGetClientRequest { ... }) -> WithRawResponseTask&lt;ClientInvestorResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific client that has a loan funded by this investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorGetClientAsync(
    new InvestorGetClientRequest { ClientId = "client_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorGetClientRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorListLoansAsync</a>(InvestorListLoansRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseLoanInvestorResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all loans funded by the current investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorListLoansAsync(new InvestorListLoansRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorListLoansRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorGetLoanAsync</a>(InvestorGetLoanRequest { ... }) -> WithRawResponseTask&lt;LoanResponseWithInstallments&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific loan funded by the current investor, with its installments.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorGetLoanAsync(new InvestorGetLoanRequest { LoanId = "loan_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorGetLoanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorListInstallmentsAsync</a>(InvestorListInstallmentsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseInstallmentResponseWithClientInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all installments for loans funded by the current investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorListInstallmentsAsync(new InvestorListInstallmentsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorListInstallmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorGetInstallmentAsync</a>(InvestorGetInstallmentRequest { ... }) -> WithRawResponseTask&lt;InstallmentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a specific installment for a loan funded by the current investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorGetInstallmentAsync(
    new InvestorGetInstallmentRequest { InstallmentId = "installment_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorGetInstallmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Investors.<a href="/src/Voltaria/Investors/InvestorsClient.cs">InvestorListRepaymentsAsync</a>(InvestorListRepaymentsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseRepaymentResponseWithClientInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all repayment logs for loans funded by the current investor.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Investors.InvestorListRepaymentsAsync(new InvestorListRepaymentsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InvestorListRepaymentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Installments
<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">ListInstallmentsAsync</a>(ListInstallmentsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseInstallmentResponseWithClientInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of all loan installments under your partner account. Supports optional filtering by loan or client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.ListInstallmentsAsync(new ListInstallmentsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListInstallmentsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">AddInstallmentAsync</a>(InstallmentCreatePayload { ... }) -> WithRawResponseTask&lt;IEnumerable&lt;InstallmentResponse&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Add new installments to a loan with its specific loan ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.AddInstallmentAsync(
    new InstallmentCreatePayload
    {
        LoanId = "loan_12345",
        Installments = new List<LoanInstallmentCreatePayload>()
        {
            new LoanInstallmentCreatePayload
            {
                ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
                Amount = "1000.00",
            },
            new LoanInstallmentCreatePayload
            {
                ExpectedRepaymentAt = new DateOnly(2026, 1, 1),
                Amount = "1000.00",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InstallmentCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">ListPaymentPromisesAsync</a>(ListPaymentPromisesRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponsePaymentPromiseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of payment promises recorded for installments under your partner account. Supports optional filtering by loan or client.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.ListPaymentPromisesAsync(new ListPaymentPromisesRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListPaymentPromisesRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">CreatePaymentPromiseAsync</a>(PaymentPromiseCreatePayload { ... }) -> WithRawResponseTask&lt;PaymentPromiseResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Record a payment promise made by a client for one of their installments. The promised date must be today or in the future.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.CreatePaymentPromiseAsync(
    new PaymentPromiseCreatePayload
    {
        InstallmentId = "inst_12345",
        Amount = 1.1,
        PromisedDate = new DateOnly(2026, 5, 15),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PaymentPromiseCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">GetInstallmentByIdAsync</a>(GetInstallmentByIdRequest { ... }) -> WithRawResponseTask&lt;InstallmentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed information for a specific installment using its installment ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.GetInstallmentByIdAsync(
    new GetInstallmentByIdRequest { InstallmentId = "installment_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetInstallmentByIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">EditInstallmentAsync</a>(InstallmentEditPayload { ... }) -> WithRawResponseTask&lt;InstallmentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update an installment's amount and expected repayment date with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.EditInstallmentAsync(
    new InstallmentEditPayload
    {
        InstallmentId = "installment_id",
        Amount = 1.1,
        ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `InstallmentEditPayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Installments.<a href="/src/Voltaria/Installments/InstallmentsClient.cs">DeleteInstallmentAsync</a>(DeleteInstallmentRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete an installment with its specific installment ID. This endpoint is available to select partners and will trigger the recalculation of the IRR and interest amounts for all installments of the loan.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Installments.DeleteInstallmentAsync(
    new DeleteInstallmentRequest { InstallmentId = "installment_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteInstallmentRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Loans
<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">ListLoansAsync</a>(ListLoansRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseLoanResponseWithClientInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all loans associated with your partner account. Supports optional filtering by client ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.ListLoansAsync(new ListLoansRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListLoansRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">CreateLoanAsync</a>(LoanCreatePayload { ... }) -> WithRawResponseTask&lt;LoanResponseWithInstallments&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new loan for an approved client with an active credit limit.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.CreateLoanAsync(
    new LoanCreatePayload
    {
        ClientId = "client_ACME",
        Currency = CurrencyEnum.Eur,
        Amount = 1.1,
        Installments = new List<LoanInstallmentCreatePayload>()
        {
            new LoanInstallmentCreatePayload
            {
                ExpectedRepaymentAt = new DateOnly(2025, 12, 1),
                Amount = 1.1,
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LoanCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">GetLoanByIdAsync</a>(GetLoanByIdRequest { ... }) -> WithRawResponseTask&lt;LoanResponseWithInstallments&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve detailed information about a specific loan by its loan ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.GetLoanByIdAsync(new GetLoanByIdRequest { LoanId = "loan_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetLoanByIdRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">DeleteLoanAsync</a>(DeleteLoanRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;?&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a loan by ID. Only loans with 'pending' status can be deleted.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.DeleteLoanAsync(new DeleteLoanRequest { LoanId = "loan_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteLoanRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">CreateBulkLoansAsync</a>(BulkLoanCreatePayload { ... }) -> WithRawResponseTask&lt;BulkLoanTaskResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create multiple loans in a single request. Processing happens asynchronously. Returns a task ID for tracking progress.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.CreateBulkLoansAsync(
    new BulkLoanCreatePayload
    {
        Loans = new List<BulkLoanItemPayload>()
        {
            new BulkLoanItemPayload
            {
                ClientId = "client_123",
                Currency = CurrencyEnum.Eur,
                Amount = "50000.00",
                CorrelationId = "LOAN_001",
                LoanDate = new DateOnly(2023, 5, 1),
                Installments = new List<LoanInstallmentCreatePayload>()
                {
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2023, 6, 1),
                        Amount = "26000.00",
                    },
                    new LoanInstallmentCreatePayload
                    {
                        ExpectedRepaymentAt = new DateOnly(2023, 7, 1),
                        Amount = "26000.00",
                    },
                },
                Data = new Dictionary<string, object?>()
                {
                    { "loan_type", "business" },
                    { "purpose", "expansion" },
                },
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkLoanCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">GetBulkLoanStatusAsync</a>(GetBulkLoanStatusRequest { ... }) -> WithRawResponseTask&lt;BulkLoanTaskStatus&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Check the status of a bulk loan creation task and retrieve results when completed.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.GetBulkLoanStatusAsync(new GetBulkLoanStatusRequest { TaskId = "task_id" });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBulkLoanStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Loans.<a href="/src/Voltaria/Loans/LoansClient.cs">SetLoanDefaultAsync</a>(LoanDefaultPayload { ... }) -> WithRawResponseTask&lt;LoanResponseWithInstallments&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Mark a loan as defaulted, recording the default date and the amount recovered from selling it. Defaults the loan's active and overdue installments and updates the loan status accordingly.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Loans.SetLoanDefaultAsync(
    new LoanDefaultPayload
    {
        LoanId = "loan_id",
        DefaultDate = new DateOnly(2026, 6, 23),
        SoldAmount = 1.1,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `LoanDefaultPayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Partners
<details><summary><code>client.Partners.<a href="/src/Voltaria/Partners/PartnersClient.cs">GetAvailableFundingAsync</a>() -> WithRawResponseTask&lt;IEnumerable&lt;AvailableFunding&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to check the available funding capacity in your dedicated lending account before initiating a new loan or submitting a drawdown request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Partners.GetAvailableFundingAsync();
```
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Partners.<a href="/src/Voltaria/Partners/PartnersClient.cs">CreatePartnerDataAsync</a>(PartnerDataCreatePayload { ... }) -> WithRawResponseTask&lt;PartnerDataResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Upload supplementary partner information, such as bank account balance, accounting figures, or other relevant details.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Partners.CreatePartnerDataAsync(
    new PartnerDataCreatePayload
    {
        Data = new Dictionary<string, object?>() { { "key1", "value1" }, { "key2", "value2" } },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `PartnerDataCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Partners.<a href="/src/Voltaria/Partners/PartnersClient.cs">ListPartnerWaterfallsAsync</a>(ListPartnerWaterfallsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseWaterfallResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Use this endpoint to get the list of waterfalls for your dedicated lending account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Partners.ListPartnerWaterfallsAsync(new ListPartnerWaterfallsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListPartnerWaterfallsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Webhooks
<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">ListWebhookSubscriptionsAsync</a>(ListWebhookSubscriptionsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseWebhookSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

List all webhook subscriptions for your partner account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ListWebhookSubscriptionsAsync(new ListWebhookSubscriptionsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListWebhookSubscriptionsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">CreateWebhookSubscriptionAsync</a>(WebhookCreatePayload { ... }) -> WithRawResponseTask&lt;WebhookSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new webhook subscription for a specific event type.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.CreateWebhookSubscriptionAsync(
    new WebhookCreatePayload
    {
        Url = "https://example.com/webhooks",
        Description = "Loan update event",
        EventType = WebhookEventTypeEnum.LoanUpdated,
        Secret = "whsec_f3o9p8h7g6j5k4l3m2n1o0p9i8u7y6t5",
        Retry = false,
        Status = WebhookStatusEnum.Active,
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WebhookCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">GetWebhookSubscriptionAsync</a>(GetWebhookSubscriptionRequest { ... }) -> WithRawResponseTask&lt;WebhookSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve details for a specific webhook subscription with its webhook ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.GetWebhookSubscriptionAsync(
    new GetWebhookSubscriptionRequest { WebhookId = "webhook_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetWebhookSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">UpdateWebhookSubscriptionAsync</a>(WebhookUpdatePayload { ... }) -> WithRawResponseTask&lt;WebhookSubscriptionResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Update a webhook subscription with its specific webhook ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.UpdateWebhookSubscriptionAsync(
    new WebhookUpdatePayload
    {
        WebhookId = "webhook_id",
        Url = "https://example.com/webhooks/v2",
        Description = "Updated webhook endpoint",
        EventType = WebhookEventTypeEnum.InstallmentUpdated,
        Status = WebhookStatusEnum.Paused,
        Retry = true,
        Secret = "whsec_updated_secret_here",
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `WebhookUpdatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">DeleteWebhookSubscriptionAsync</a>(DeleteWebhookSubscriptionRequest { ... }) -> WithRawResponseTask&lt;Dictionary&lt;string, object?&gt;&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Delete a specific webhook subscription.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.DeleteWebhookSubscriptionAsync(
    new DeleteWebhookSubscriptionRequest { WebhookId = "webhook_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DeleteWebhookSubscriptionRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Webhooks.<a href="/src/Voltaria/Webhooks/WebhooksClient.cs">ListWebhookLogsAsync</a>(ListWebhookLogsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseWebhookLogResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all webhook logs linked to your partner account.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Webhooks.ListWebhookLogsAsync(new ListWebhookLogsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListWebhookLogsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Repayments
<details><summary><code>client.Repayments.<a href="/src/Voltaria/Repayments/RepaymentsClient.cs">ListRepaymentLogsAsync</a>(ListRepaymentLogsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseRepaymentResponseWithClientInfo&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all repayments made under your partner account. Supports filtering by client, loan, or installments.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Repayments.ListRepaymentLogsAsync(new ListRepaymentLogsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListRepaymentLogsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Repayments.<a href="/src/Voltaria/Repayments/RepaymentsClient.cs">CreateRepaymentAsync</a>(RepaymentCreatePayload { ... }) -> WithRawResponseTask&lt;RepaymentResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new repayment log for an installment. Requires the installment ID, loan ID or loan correlation ID.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Repayments.CreateRepaymentAsync(new RepaymentCreatePayload { Amount = 1.1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `RepaymentCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Repayments.<a href="/src/Voltaria/Repayments/RepaymentsClient.cs">CreateBulkRepaymentsAsync</a>(BulkRepaymentCreatePayload { ... }) -> WithRawResponseTask&lt;BulkRepaymentTaskResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Initiate processing of up to 10000 repayment logs. Returns task_id for tracking progress.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Repayments.CreateBulkRepaymentsAsync(
    new BulkRepaymentCreatePayload
    {
        Repayments = new List<BulkRepaymentItemPayload>()
        {
            new BulkRepaymentItemPayload
            {
                Amount = "1000.00",
                RepaymentDate = new DateTime(2023, 10, 01, 12, 00, 00, 000),
                Data = new Dictionary<string, object?>()
                {
                    { "reference", "TXN-001" },
                    { "type", "transfer" },
                },
                InstallmentId = "installment_123",
            },
            new BulkRepaymentItemPayload
            {
                Amount = "500.50",
                Data = new Dictionary<string, object?>()
                {
                    { "notes", "Payment received in office" },
                    { "type", "cash" },
                },
                LoanId = "loan_456",
            },
            new BulkRepaymentItemPayload
            {
                Amount = "750.00",
                RepaymentDate = new DateTime(2023, 09, 30, 15, 30, 00, 000),
                CorrelationId = "LOAN-789",
            },
        },
    }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `BulkRepaymentCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Repayments.<a href="/src/Voltaria/Repayments/RepaymentsClient.cs">GetBulkRepaymentStatusAsync</a>(GetBulkRepaymentStatusRequest { ... }) -> WithRawResponseTask&lt;BulkRepaymentTaskStatus&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Check the progress and results of a bulk repayment processing task.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Repayments.GetBulkRepaymentStatusAsync(
    new GetBulkRepaymentStatusRequest { TaskId = "task_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `GetBulkRepaymentStatusRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

## Drawdowns
<details><summary><code>client.Drawdowns.<a href="/src/Voltaria/Drawdowns/DrawdownsClient.cs">ListDrawdownsAsync</a>(ListDrawdownsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseDrawdownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve a list of drawdowns.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Drawdowns.ListDrawdownsAsync(new ListDrawdownsRequest());
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDrawdownsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Drawdowns.<a href="/src/Voltaria/Drawdowns/DrawdownsClient.cs">CreateDrawdownRequestAsync</a>(DrawdownCreatePayload { ... }) -> WithRawResponseTask&lt;DrawdownResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Create a new drawdown request.
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Drawdowns.CreateDrawdownRequestAsync(new DrawdownCreatePayload { Amount = 1.1 });
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `DrawdownCreatePayload` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

<details><summary><code>client.Drawdowns.<a href="/src/Voltaria/Drawdowns/DrawdownsClient.cs">ListDrawdownChecklistsAsync</a>(ListDrawdownChecklistsRequest { ... }) -> WithRawResponseTask&lt;PaginatedResponseDrawdownChecklistResponse&gt;</code></summary>
<dl>
<dd>

#### 📝 Description

<dl>
<dd>

<dl>
<dd>

Retrieve all checklist items for a specific drawdown
</dd>
</dl>
</dd>
</dl>

#### 🔌 Usage

<dl>
<dd>

<dl>
<dd>

```csharp
await client.Drawdowns.ListDrawdownChecklistsAsync(
    new ListDrawdownChecklistsRequest { DrawdownId = "drawdown_id" }
);
```
</dd>
</dl>
</dd>
</dl>

#### ⚙️ Parameters

<dl>
<dd>

<dl>
<dd>

**request:** `ListDrawdownChecklistsRequest` 
    
</dd>
</dl>
</dd>
</dl>


</dd>
</dl>
</details>

