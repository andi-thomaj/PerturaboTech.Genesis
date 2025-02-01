using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PerturaboTech.Genesis.WebApi.Apis.Users;

[ApiController]
[Route("api/[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
}