using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieService;
using Microsoft.AspNetCore.Mvc;
using MovieBusiness.Services;
using MovieEntity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieApi.Controllers
{
    public class UserController : Controller
    {
        UserService _userServices;

        public UserController(UserService userService)
        {
            _userServices = userService;
        }

        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userServices.SelectUser());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userServices.Register(userModel));
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(_userServices.deleteUser(id));
        }
    }
}

