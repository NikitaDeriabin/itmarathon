using CSharpFunctionalExtensions;
using FluentValidation.Results;
using MediatR;
using UserEntity = Epam.ItMarathon.ApiService.Domain.Entities.User.User;

namespace Epam.ItMarathon.ApiService.Application.UseCases.User.Commands
{
    /// <summary>
    /// Query for removing User from Room.
    /// </summary>
    /// <param name="UserCode">Admin authorization code.</param>
    /// <param name="UserId">User's unique identifier.</param>
    public record DeleteUserRequest(string UserCode, ulong UserId)
        : IRequest<Result<UserEntity, ValidationResult>>;
}