using AutoBogus;

namespace Perturabo.Genesis.WebApi.IntegrationTests.User;

public class UsersWebApiTests(IntegrationTestWebApplicationFactory factory) : BaseIntegrationTest(factory)
{
    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        var user = new AutoFaker<PerturaboTech.Genesis.WebApi.Data.Entities.User>()
            .RuleFor(f => f.Email, f => f.Internet.Email())
            .Generate();

        var result = await _userService.GetUserByEmail(user.Email);
    }
}