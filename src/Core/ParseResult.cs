using Domain.Models;
using System;
using System.Linq;

namespace Core
{
    public class ParseResult
    {
        public Class[] Classes { get; }
        public string ErrorMessage { get; }
        public bool NotSupported => (Classes?.Any() != true) && string.IsNullOrEmpty(ErrorMessage);

        public ParseResult(Class[] classes, string errorMessage)
        {
            Classes = classes;
            ErrorMessage = errorMessage;
        }

        public static ParseResult NotSupportedFile()
        {
            return new ParseResult(Array.Empty<Class>(), null);
        }

        public static ParseResult ParseFailed(string errorMessage)
        {
            return new ParseResult(Array.Empty<Class>(), errorMessage);
        }
    }
}