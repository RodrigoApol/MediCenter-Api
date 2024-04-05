using MediCenter.Application.Errors.Patient;
using MediCenter.Application.Models.ViewModel.UserViewModel;

namespace MediCenter.Application.Errors;

public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid Error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    private bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }
    public static Result Success() => new(true, Error.None);
    public static Result Fail(Error error) => new(false, error);
}

public class Result<T> : Result
{
    private T _value;

    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException();
            }

            return _value;
        } 
        
        private set => _value = value;
    }

    private Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        Value = value;
    }

    public static Result<T> Success(T value) => new Result<T>(value, true, Error.None);
    public static Result<T> Fail(Error error) => new Result<T>(default(T), false, error);
}