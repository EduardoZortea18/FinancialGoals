using FinancialGoals.Domain.Results.Errors;

namespace FinancialGoals.Domain.Results
{
    public record Result
    {
        public Result(bool hasError, Error? error)
        {
            HasError = hasError;
            Error = error;
        }

        public Result()
        {
        }

        public bool HasError { get; private set; }
        public Error? Error { get; private set; }

        public Result Failure(Error? error)
            => new Result(true, error);
    }
}
