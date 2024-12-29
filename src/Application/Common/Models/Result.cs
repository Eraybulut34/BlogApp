using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogAppApplication.Common.Models;

public class Result
{
    public bool Succeeded { get; }
    public string[] Errors { get; }

    internal Result(bool succeeded, string[] errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(string[] errors)
    {
        return new Result(false, errors);
    }
}

public class Result<T> : Result
{
    public T Data { get; }

    internal Result(bool succeeded, string[] errors, T data)
        : base(succeeded, errors)
    {
        Data = data;
    }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, Array.Empty<string>(), data);
    }

    public new static Result<T> Failure(string[] errors)
    {
        return new Result<T>(false, errors, default!);
    }
}
