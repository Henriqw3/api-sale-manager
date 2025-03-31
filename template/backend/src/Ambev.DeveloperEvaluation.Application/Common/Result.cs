using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Common
{
    public static class Result
    {
        // Método para sucesso (sem dados)
        public static Result<Unit> Success()
            => Result<Unit>.Success(Unit.Value);

        // Método para sucesso (com dados)
        public static Result<T> Success<T>(T value)
            => Result<T>.Success(value);

        // Método para falha
        public static Result<T> Failure<T>(IEnumerable<ValidationErrorDetail> errors)
            => Result<T>.Failure(errors);
    }

    public sealed record Result<T>
    {
        public bool IsSuccess { get; init; }
        public T? Value { get; init; }
        public IEnumerable<ValidationErrorDetail> Errors { get; init; } = [];

        // Construtor privado para garantir criação via métodos estáticos
        private Result() { }

        // Fábrica de sucesso
        public static Result<T> Success(T value) => new()
        {
            IsSuccess = true,
            Value = value
        };

        // Fábrica de falha
        public static Result<T> Failure(IEnumerable<ValidationErrorDetail> errors) => new()
        {
            IsSuccess = false,
            Errors = errors
        };
    }
}