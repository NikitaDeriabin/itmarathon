using CSharpFunctionalExtensions;
using Epam.ItMarathon.ApiService.Application.UseCases.User.Commands;
using Epam.ItMarathon.ApiService.Application.UseCases.User.Queries;
using Epam.ItMarathon.ApiService.Domain.Abstract;
using Epam.ItMarathon.ApiService.Domain.Shared.ValidationErrors;
using FluentValidation.Results;
using MediatR;
using UserEntity = Epam.ItMarathon.ApiService.Domain.Entities.User.User;

namespace Epam.ItMarathon.ApiService.Application.UseCases.User.Handlers
{
    /// <summary>
    /// Handler for Users removing.
    /// </summary>
    /// <param name="roomRepository">Implementation of <see cref="IRoomRepository"/> for operating with database.</param>
    /// <param name="userRepository">Implementation of <see cref="IUserReadOnlyRepository"/> for operating with database.</param>
    public class DeleteUserHandler(IRoomRepository roomRepository, IUserReadOnlyRepository userRepository)
        : IRequestHandler<DeleteUserRequest, Result<UserEntity, ValidationResult>>
    {
        ///<inheritdoc/>
        public async Task<Result<UserEntity, ValidationResult>> Handle(DeleteUserRequest request,
            CancellationToken cancellationToken)
        {

            // Get room by userCode
            var roomResult = await roomRepository.GetByUserCodeAsync(request.UserCode, cancellationToken);
            if (roomResult.IsFailure)
            {
                return roomResult.ConvertFailure<UserEntity>();
            }

            // Get user by userId
            var userToDeleteResult = await userRepository.GetByIdAsync(request.UserId, cancellationToken);
            // Check if user with userId not found 
            if (userToDeleteResult.IsFailure)
            {
                return userToDeleteResult;
            }
            
            // Remove user in Domain
            var room = roomResult.Value;
            var deleteResult = room.DeleteUserWithId(request.UserId, request.UserCode);
            if (deleteResult.IsFailure)
            {
                return Result.Failure<UserEntity, ValidationResult>(deleteResult.Error);
            }
            
            // Update repository
            var updatedResult = await roomRepository.UpdateAsync(room, cancellationToken);
            if (updatedResult.IsFailure)
            {
                return Result.Failure<UserEntity, ValidationResult>(new BadRequestError([
                new ValidationFailure(string.Empty, updatedResult.Error)]));
            }

            return userToDeleteResult.Value;
        }
    }
}