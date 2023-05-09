using System.Collections;
using Application.Core;

namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public SaveError Error { get; set; }
        public static Result<T> Success(T value) => new Result<T>{IsSuccess = true, Value = value};
        public static Result<T> Failure(SaveError error) => new Result<T>{IsSuccess = false, Error = error};
    }
}