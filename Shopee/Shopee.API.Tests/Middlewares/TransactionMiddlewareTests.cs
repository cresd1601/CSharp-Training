using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;

using Shopee.Infrastructure.UnitOfWork;

namespace Shopee.API.Tests.Middlewares
{
    public class TransactionMiddlewareTests
    {
        private readonly Mock<ILogger<TransactionMiddleware>> mockLogger;
        private readonly Mock<RequestDelegate> mockNext;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly Mock<IDbContextTransaction> mockTransaction;  // Mock transaction object
        private readonly TransactionMiddleware middleware;

        public TransactionMiddlewareTests()
        {
            mockLogger = new Mock<ILogger<TransactionMiddleware>>();
            mockNext = new Mock<RequestDelegate>();
            mockUnitOfWork = new Mock<IUnitOfWork>();
            mockTransaction = new Mock<IDbContextTransaction>();  // Initialize mock transaction
            middleware = new TransactionMiddleware(mockLogger.Object, mockNext.Object);

            // Setup mock to return the mocked transaction object
            mockUnitOfWork.Setup(u => u.BeginTransactionAsync()).ReturnsAsync(mockTransaction.Object);
        }

        private HttpContext CreateHttpContext()
        {
            return new DefaultHttpContext();
        }

        [Fact]
        public async Task InvokeAsync_CommitsTransaction_WhenNoException()
        {
            var httpContext = new DefaultHttpContext();
            mockNext.Setup(x => x.Invoke(It.IsAny<HttpContext>())).Returns(Task.CompletedTask);

            // Use the mocked transaction object in the Commit and Rollback setups
            mockUnitOfWork.Setup(u => u.CommitAsync()).Returns(Task.CompletedTask);

            await middleware.Invoke(httpContext, mockUnitOfWork.Object);

            mockUnitOfWork.Verify(u => u.BeginTransactionAsync(), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Once);
            mockUnitOfWork.Verify(u => u.RollbackAsync(), Times.Never);
        }

        [Fact]
        public async Task InvokeAsync_RollsBackTransaction_WhenExceptionThrown()
        {
            var httpContext = new DefaultHttpContext();
            mockNext.Setup(x => x.Invoke(It.IsAny<HttpContext>())).ThrowsAsync(new InvalidOperationException());

            // Use the mocked transaction object in the Commit and Rollback setups
            mockUnitOfWork.Setup(u => u.RollbackAsync()).Returns(Task.CompletedTask);

            await Assert.ThrowsAsync<InvalidOperationException>(() => middleware.Invoke(httpContext, mockUnitOfWork.Object));

            mockUnitOfWork.Verify(u => u.BeginTransactionAsync(), Times.Once);
            mockUnitOfWork.Verify(u => u.CommitAsync(), Times.Never);
            mockUnitOfWork.Verify(u => u.RollbackAsync(), Times.Once);
        }
    }
}