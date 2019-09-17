using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class AuthController : Controller
    {
        private readonly Users _users;

        public AuthController(Users users)
        {
            _users = users;
        }
        public IActionResult User()
        {
            return View();
        }
        
        public IActionResult Admin()
        {
            return View();
        }

        public JsonResult LoginHello()
        {
            var result = new JsonAnswer();

            result.Ok = true;
            return Json(true);
        }
        
        public JsonResult Login([FromBody] LoginDto dto)
        {
            var currentUser = _users.GetUserByLoginAndPassword(dto.Login, dto.Password);
            var result = new JsonAnswer();
            if (currentUser == null)
            {
                return Json(result);
            }
            

            result.Ok = true;
            result.UserId = currentUser.Id;
            return Json(result);
        }
        public JsonResult LoginAdmin([FromBody] LoginDto dto)
        {
            var result = new JsonAnswer();
            if (dto.Login == "admin" && dto.Password == "admin")
            {
                result.Ok = true;
                return Json(result);
            }
            
            return Json(result);
        }
 
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class JsonAnswer
    {
        public bool Ok { get; set; }
        public int UserId { get; set; }
    }

    public class LoginDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserId { get; set; }
    }
}
