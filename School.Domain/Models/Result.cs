using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace School.Domain.Models
{
    public class Result<T> where T : class
    {
        public bool Success { get; set; }
        public bool Fail { get; set; }
        public string[] Errors { get; set; } = [];

        public T? Value { get; private set; }

       

        public static Result<T> IsSuccess()
        {
            return new Result<T> { Success = true, Fail = false};
        }

        public static Result<T> Ok(T t)
        {
            return new Result<T> { Success = true, Fail = false, Value = t };
        }

        public static Result<T> IsFail() { 
            return new Result<T> { Fail = true, Success = false }; 
        }

        public static Result<T> IsFail(string[] errorMsg)
        {
            return new Result<T> { Fail = true, Success = false, Errors = errorMsg };
        }
    }
}
