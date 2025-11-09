namespace Epam.ItMarathon.ApiService.Application.Tests.UserCases.Commands;
using Epam.ItMarathon.ApiService.Application.UseCases.User.Handlers;
using Epam.ItMarathon.ApiService.Domain.Abstract;
using Epam.ItMarathon.ApiService.Domain.Entities.User;
using Epam.ItMarathon.ApiService.Domain.Shared.ValidationErrors;
using FluentAssertions;
using FluentValidation.Results;
using NSubstitute;
using ValidationResult = FluentValidation.Results.ValidationResult;

// <summary>
/// Unit tests for the <see cref="DeleteUserHandler"/> class.
/// </summary>
public class DeleteUserHandlerTests
{
    private readonly IRoomRepository _roomRepositoryMock;
    private readonly IUserReadOnlyRepository _userRepositoryMock;
    private readonly DeleteUserHandler _handler;
    
    public DeleteUserHandlerTests()
    {
        _roomRepositoryMock = Substitute.For<IRoomRepository>();
        _userRepositoryMock = Substitute.For<IUserReadOnlyRepository>();
        _handler = new DeleteUserHandler(_roomRepositoryMock, _userRepositoryMock);
    }
    
}