using Microsoft.AspNetCore.Mvc;
using ServiceMesh.Services.Web.Models.DTO;
using ServiceMesh.Web.Service.IService;

namespace ServiceMesh.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
    }
}
