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
        public async Task<IActionResult> Create([FromBody] UserForCreate user)
        {
            var userCore = _mapper.Map<UserForCreate, Core.Repositories.User>(user);
            int id = await _userService.Create(userCore);

            return Ok(id);
        }

        [HttpGet("/id/{id:int}")]
        public async Task<IActionResult> Get ([FromRoute] int id)
        {
            var userCore = await _userService.Get(id);
            var userContract = _mapper.Map<Core.Repositories.User, UserForGet>(userCore);
            return Ok(userContract);
        }

        [HttpDelete("/delete/id/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _userService.Delete(id));
        }

    }
}
