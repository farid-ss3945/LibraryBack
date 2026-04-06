using AutoMapper;
using Library.Application.DTOs.User;
using Library.Application.Interfaces;
using Library.Domain;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories;

public class UserRepository:IUserRepo
{
    private readonly OnlineLibDbContext _context;
    private readonly IMapper _mapper;
    
    public UserRepository(OnlineLibDbContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<UserResponseDto>?> GetAllAsync()
    {
        var adminRoleId = await _context.Roles
            .Where(r => r.Name == "Admin")
            .Select(r => r.Id)
            .FirstOrDefaultAsync();
        
        return await _context.Users.Where(i=> !_context.UserRoles.Any(u=>u.UserId==i.Id && u.RoleId==adminRoleId))
            .Select(c=> new UserResponseDto()
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            Address = c.Address,
            PhoneNumber = c.PhoneNumber,
            Birthday = c.Birthday,
            CreatedAt = c.CreatedAt,
            UserBooks = c.UserBooks
        }).ToListAsync();
    }
}