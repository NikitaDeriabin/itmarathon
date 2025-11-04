using CSharpFunctionalExtensions;
using Epam.ItMarathon.ApiService.Domain.Entities.User;

namespace Epam.ItMarathon.ApiService.Domain.Policies.DeletePolicies;

/// <summary>
/// User Deletion Policy 
/// </summary>
public class DeleteUserPolicy
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="admin">Room admin.</param>
    /// <param name="userToDelete">The user to be deleted.</param>
    /// <returns></returns>
    public static Result Validate(User admin, User userToDelete)
    {
        // Check if user with userId and userCode is the same
        if (admin.Id == userToDelete.Id)
        {
            return Result.Failure("User can't delete himself."); 
        }
            
        // Check if userToDelete and admin in different rooms
        if (admin.RoomId != userToDelete.RoomId)
        {
            return Result.Failure("Denied: not enough rights. Room admin can't delete user from another room."); 
        }

        return Result.Success();
    }
}