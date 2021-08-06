using Business.Abstract;
using Core.Entities.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        //[HttpGet("getall")]
        //public User GetByMail( string email)
        //{
        //    var result = _userService.GetByMail(email);
        //    //if (result.Success)
        //    //{
        //    //    return Ok(result);
        //    //}
        //    //return BadRequest(result);
        //    return result;
        //}





    }
}
