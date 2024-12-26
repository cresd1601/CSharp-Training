namespace Shopee.Application.DTOs
{
    public class ApiResponseDto<T>
    {
        // Public properties
        public bool Succeeded { get; private set; }
        public T Result { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
        
        // Internal property not exposed in API responses
        internal string ErrorCode { get; private set; }

        // Private constructor to enforce the use of factory methods
        private ApiResponseDto(bool succeeded, T result, IEnumerable<string> errors, string errorCode)
        {
            Succeeded = succeeded;
            Result = result;
            Errors = errors;
            ErrorCode = errorCode;
        }

        // Factory method for success
        public static ApiResponseDto<T> Success(T result)
        {
            return new ApiResponseDto<T>(true, result, new List<string>(), null);
        }

        // Factory method for failure
        public static ApiResponseDto<T> Failure(IEnumerable<string> errors, string errorCode)
        {
            return new ApiResponseDto<T>(false, default, errors, errorCode);
        }
    }
}