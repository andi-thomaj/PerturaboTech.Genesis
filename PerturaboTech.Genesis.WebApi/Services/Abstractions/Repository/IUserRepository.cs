﻿using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;
using PerturaboTech.Genesis.WebApi.Data.Entities;

namespace PerturaboTech.Genesis.WebApi.Services.Abstractions.Repository;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User?> RegisterUserByEmailAndPassword(RegisterUserWithEmailAndPasswordRequest request);
    Task<User?> UpdateUser(UpdateUserRequest request);
    Task<bool> DeleteUserById(Guid id);
    Task<RefreshToken> CreateRefreshToken(Guid userId);
    Task<RefreshToken?> GetRefreshToken(string refreshToken);
}