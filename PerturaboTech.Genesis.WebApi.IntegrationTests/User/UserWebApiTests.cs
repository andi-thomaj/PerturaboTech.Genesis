using AutoBogus;
using PerturaboTech.Genesis.WebApi.Apis.Users.Requests;

namespace Perturabo.Genesis.WebApi.IntegrationTests.User;

public class UsersWebApiTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        var user = new AutoFaker<PerturaboTech.Genesis.WebApi.Data.Entities.User>()
            .RuleFor(f => f.Email, f => f.Internet.Email())
            .Generate();

        await _userService.RegisterUserWithEmailAndPassword(new RegisterUserWithEmailAndPasswordRequest(user.Email, user.Password, user.FirstName, user.MiddleName, user.LastName));
        
        var result = await _userService.GetUserByEmail(user.Email);
    }
}