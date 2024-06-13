using JWTAuthentication.DataTransferObjects;
using JWTAuthentication.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace JWTAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserDataController : ControllerBase
    {
        private  IUserDataRepository _userDataRepository;

        public UserDataController(IUserDataRepository userDataRepository)
        {
            _userDataRepository = userDataRepository;
        }

        [HttpPost("AddUserData")]
        
        public async Task<IActionResult> AddUserData([FromBody]UserDataDto user)
        {
            await Task.Run(() =>
            {
                _userDataRepository.AddUserData(user);
            });
            return Ok();
        }

        [HttpGet("GetUsersDetails"), Authorize(Roles = "Admin , user")]
        public async Task<IActionResult> GetUserData()
        {
            return await Task.Run(async () =>
            {
                var userData =await _userDataRepository.GetUser();
                return new OkObjectResult(userData);
            });
        }
    }
}