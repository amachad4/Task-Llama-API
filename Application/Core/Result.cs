using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ActionResult;

namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public Dictionary<string, SaveError> Error { get; set; }
        public int MyProperty { get; set; }
        public static Result<T> Success(T value) => new Result<T>{IsSuccess = true, Value = value};
        public static Result<T> Failure(Dictionary<string, SaveError> error) => new Result<T>{IsSuccess = false, Error = error};
    }
}