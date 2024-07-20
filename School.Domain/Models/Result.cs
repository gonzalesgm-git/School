﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace School.Domain.Models
{
    public class Result<T> : Result
    where T : class
    {
        public T? Value { get; private set; }

        internal Result(T value)
            : base()
        {
            Value = value;
        }

        internal Result(Error[] errors)
            : base(errors)
        {
            Value = default;
        }

        public static Result<T> OK(T value)
        {
            return new Result<T>(value);
        }

        public static new Result<T> Fail(string message, string? propertyName = null)
        {
            Error[] errors = { new Error(message, propertyName) };
            return new Result<T>(errors);
        }

        public static new Result<T> Fail(Error error)
        {
            Error[] errors = { error };
            return new Result<T>(errors);
        }

        public static new Result<T> Fail(Error[] errors)
        {
            return new Result<T>(errors);
        }

        public static implicit operator Result<T>(Error error)
            => Fail(error);

        public static implicit operator Result<T>(Error[] errors)
           => Fail(errors);

        public static implicit operator Result<T>(T value)
            => OK(value);
    }

    public class Result
    {
        public bool Success { get; private set; }
        public Error[] Errors { get; private set; }

        internal Result()
        {
            Success = true;
            Errors = Array.Empty<Error>();
        }

        internal Result(Error[] errors)
        {
            Success = false;
            Errors = errors;
        }

        public static Result OK()
        {
            return new Result();
        }

        public static Result Fail(string message, string? propertyName = null)
        {
            Error[] errors = { new Error(message, propertyName) };
            return new Result(errors);
        }

        public static Result Fail(Error error)
        {
            Error[] errors = { error };
            return new Result(errors);
        }

        public static Result Fail(Error[] errors)
        {
            return new Result(errors);
        }

        public bool IsSuccess() => Success;
        public bool IsFailed() => !Success;

        public static implicit operator Result(Error error)
            => Fail(error.Message, error.PropertyName);

        public static implicit operator Result(Error[] errors)
            => Fail(errors);
    }

    public class Error
    {
        public string Message { get; private set; }
        public string? PropertyName { get; set; }

        public Error(string message, string? propertyName = null)
        {
            Message = message;
            PropertyName = propertyName;
        }
    }
}
