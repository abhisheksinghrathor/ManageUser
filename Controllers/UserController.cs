using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ManageUser.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using MongoDB.Driver;

namespace ManageUser.Controllers
{
    [ApiController]
    [Route("api/Manage/User")]
    public class UserController : ControllerBase
    {
        private IManageUserServices _userService; 

        public UserController(IManageUserServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<bool> AddUsers(Users user)
        {
            if(_userService == null)
            {
                return NotFound();
            }

            var result = _userService.AddUsers(user);

            return result;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers(){
            var allRecords = await _userService.GetAllUsers();
            return new ObjectResult(allRecords);
        } 

        [HttpDelete]
        public ActionResult<bool> DeleteUsers(int id)
        {
            if(_userService == null)
            {
                return NotFound();
            }

            var result = _userService.DeleteUsers(id);

            return result;
        }

        [HttpPut]
        public ActionResult<bool> UpdateUsers(Users user)
        {
            if(_userService == null)
            {
                return NotFound();
            }
            
            var result = _userService.UpdateUsers(user);

            return result;
        }

    }
}
