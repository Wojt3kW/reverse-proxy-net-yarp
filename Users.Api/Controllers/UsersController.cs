using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Users.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
         private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var url = Request.GetEncodedUrl();
            _logger.LogDebug($"get users from '{url}'");

            return Enumerable
                .Range(1, 5)
                .Select(index => new User(index, $"User{index}", $"email{index}@domain.com"))
                .ToList();
        }
    }
}