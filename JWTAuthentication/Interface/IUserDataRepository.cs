using JWTAuthentication.DataTransferObjects;

namespace JWTAuthentication.Interface
{
    public interface IUserDataRepository
    {
        Task AddUserData(UserDataDto user);
        Task<List<UserDataDto>> GetUser();
    }
}