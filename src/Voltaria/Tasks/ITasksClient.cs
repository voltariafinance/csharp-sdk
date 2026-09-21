namespace Voltaria;

public partial interface ITasksClient
{
    /// <summary>
    /// Paginated list of the tasks shared with your partner account, optionally filtered by status or by the client, loan, installment or waterfall they relate to.
    /// </summary>
    WithRawResponseTask<PaginatedResponseTaskPartnerResponse> ListTasksAsync(
        ListTasksRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Open a task for your partner account. Any entity you link to it must belong to you.
    /// </summary>
    WithRawResponseTask<TaskPartnerResponse> CreateTaskAsync(
        TaskPartnerCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve one of your tasks by its ID.
    /// </summary>
    WithRawResponseTask<TaskPartnerResponse> GetTaskAsync(
        GetTaskRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Move one of your tasks to another status. Status is the only field you can change. Requires a signed-in user — API keys cannot change a task.
    /// </summary>
    WithRawResponseTask<TaskPartnerResponse> UpdateTaskStatusAsync(
        TaskPartnerStatusUpdatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// The status transitions of one of your tasks, and whether each one was made by your team or by Voltaria support.
    /// </summary>
    WithRawResponseTask<PaginatedResponseTaskPartnerStatusHistoryResponse> ListTaskStatusHistoryAsync(
        ListTaskStatusHistoryRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Notes exchanged with Voltaria on one of your tasks.
    /// </summary>
    WithRawResponseTask<PaginatedResponseNoteResponse> ListTaskNotesAsync(
        ListTaskNotesRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add a note to one of your tasks. Requires a signed-in user — API keys cannot write notes, because a note needs an author.
    /// </summary>
    WithRawResponseTask<NoteResponse> CreateTaskNoteAsync(
        TaskNoteCreatePayload request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
