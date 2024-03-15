namespace FinancialGoals.Domain.Results.Errors
{
    public static class GenericErrors
    {
        public static Error NotFound(string objectName)
            => new Error("NotFound", $"{objectName} not found");

        public static Error AlreadyExists(string objectName)
            => new Error("AlreadyExists", $"{objectName} already exists");

        public static Error ValidationProblem(string message)
            => new Error("ValidationProblem", message);

        public static Error? NoError() => default;
    }
}
