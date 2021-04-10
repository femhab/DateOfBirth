using DateOfBirthApp.Business.Interface;
using DateOfBirthApp.ViewModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateOfBirthApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserFormModel model)
        {
            if (model != null)
            {
                var response = await _userService.Create(model);
                return Ok(response);
            }
            return null;
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != Guid.Empty)
            {
                var response = await _userService.Delete(id);
                return Ok(response);
            }
            return null;
        }

        [HttpPut]
        public async Task<IActionResult> Update(UserModel model)
        {
            if (model != null)
            {
                var response = await _userService.Update(model);
                return Ok(response);
            }
            return null;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetById(Guid id)
        //{
        //    var response = await _userService.GetById(id);
        //    return Ok(response);
        //}
    }
}
