using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace BlogAppApplication.Common.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() 
        : base("Bir veya daha fazla doğrulama hatası meydana geldi.") 
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ValidationException(List<ValidationFailure> failures)
        : base("Bir veya daha fazla doğrulama hatası meydana geldi.")
    {
        Errors = failures
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}
