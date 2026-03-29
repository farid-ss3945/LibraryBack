using Library.Application.DTOs.User;

namespace Library.Application.Interfaces;

public interface IUserRepo
{
    Task<IEnumerable<UserResponseDto>?> GetAllAsync();
}