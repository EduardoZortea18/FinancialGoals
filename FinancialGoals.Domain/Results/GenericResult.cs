using FinancialGoals.Domain.Results.Errors;

namespace FinancialGoals.Domain.Results
{
    public record GenericResult<T> : Result where T : class
    {
        public GenericResult(T? data, bool hasError, Error? error) : base(hasError, error)
        {
            Data = data;
        }

        public GenericResult()
        {
        }

        public T? Data { get; private set; }

        public GenericResult<T> Ok(T data) => new GenericResult<T>(data, false, null);
    }
}
