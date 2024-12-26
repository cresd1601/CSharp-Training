using Shopee.Infrastructure.UnitOfWork;

public class TransactionMiddleware
{
    private readonly ILogger<TransactionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public TransactionMiddleware(ILogger<TransactionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
    {
        var transaction = await unitOfWork.BeginTransactionAsync();

        try
        {
            await _next(context);
            await unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing request, rolling back transaction");
            await unitOfWork.RollbackAsync();
            throw; // Rethrow the exception after logging and rolling back
        }
    }
}
