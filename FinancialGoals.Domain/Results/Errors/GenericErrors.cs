﻿namespace FinancialGoals.Domain.Results.Errors
{
    public static class GenericErrors
    {
        public static Error NotFound(string objectName)
            => new Error("NotFound", $"{objectName} not found");

        public static Error? NoError() => default;
    }
}