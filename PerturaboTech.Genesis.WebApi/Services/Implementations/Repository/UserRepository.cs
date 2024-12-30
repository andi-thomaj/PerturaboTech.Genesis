using Microsoft.EntityFrameworkCore;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Data;
using PerturaboTech.Genesis.WebApi.Data.Entities;
using PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;

namespace PerturaboTech.Genesis.WebApi.Services.Implementations.Repository;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
        => await dbContext.Users
            .AsNoTracking()
            .Where(x => x.Email == email)
            .FirstOrDefaultAsync();

    public async Task<User?> CreateUser(CreateUserRequest request)
    {
        await dbContext.Users.AddAsync(request.GetUserEntity());
        
        await dbContext.SaveChangesAsync();
        
        return await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == request.Email);
    }

    public async Task<User?> UpdateUser(UpdateUserRequest request)
    {
        var user = await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if (user is null)
        {
            return null;
        }
        
        dbContext.Users.Update(request.GetUserEntity());
        await dbContext.SaveChangesAsync();
        
        return await dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);
    }

    public async Task<bool> DeleteUserById(Guid id)
    {
        var user = await dbContext.Users.FindAsync(id);
        
        if (user is null)
        {
            return false;
        }
        
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
        
        return true;
    }
    
    public async Task<RefreshToken> CreateRefreshToken(Guid userId)
    {
        var refreshToken = new RefreshToken
        {
            Id = Guid.NewGuid(),
            Token = Guid.NewGuid().ToString(),
            ExpiresOnUtc = DateTime.UtcNow.AddDays(7),
            UserId = userId
        };

        await dbContext.RefreshTokens.AddAsync(refreshToken);
        await dbContext.SaveChangesAsync();

        return refreshToken;
    }
    
    public async Task<RefreshToken?> GetRefreshToken(string refreshToken)
        => await dbContext.RefreshTokens
            .Include(x => x.User)
            .FirstOrDefaultAsync(x => x.Token == refreshToken);
}