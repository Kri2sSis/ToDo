using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Contracts;
using ToDo.Core.Services;

namespace ToDo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("/creat")]
        public async Task<IActionResult> Create([FromBody]User user)
        {
            var userCore = _mapper.Map<User, Core.Repositories.User>(user);
            int id = await _userService.Create(userCore);

            return Ok(id);
        }

    }
}
