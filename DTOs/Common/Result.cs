namespace WhereToGoTonight.DTOs.Common
{
    public class Result<T>
    {
        private Result(bool succeeded, T? data, IEnumerable<ValidationError>? errors, string? errorMessage)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
            ErrorMessage = errorMessage;
        }
        public bool Succeeded { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public IEnumerable<ValidationError>? Errors { get; set; }

        public static Result<T> Success(T result)
        {
            return new Result<T>(true, result, [], string.Empty);
        }

        public static Result<T> Failure(IEnumerable<ValidationError> errors, string? errorMessage = "")
        {
            return new Result<T>(false, default, errors, errorMessage);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default, [], errorMessage);
        }
    }
    public class ValidationError
    {
        public string? Name { get; set; }
        public string? Error { get; set; }
    }
}
