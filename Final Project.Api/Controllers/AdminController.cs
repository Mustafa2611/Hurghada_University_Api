using Final_Project.Core.Dtos.AdminDto;
using Final_Project.Core.Dtos.EmployeeDots;
using Final_Project.Core.Models;
using FinalProject.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/Create_Admin")]
        public async Task<IActionResult> Create(AddAdminDto AdminDto)
        {
            var admin = new Admin()
            {
                Name = AdminDto.Name,
                Email = AdminDto.Email,
                Password = AdminDto.Password,
            };
            var AddAdmin = await _unitOfWork.Admins.AddAsync(admin);
            if (AddAdmin == null) return BadRequest("Admin creation failed");


            await _unitOfWork.CompleteAsync();
            return Ok(admin);
        }

        [HttpGet("/Admin_Login")]
        public async Task<IActionResult> Login(AdminLoginDto adminDto)
        {
            var AdminLogin = await _unitOfWork.Admins.AdminLogin(adminDto.Email, adminDto.Password);
            if (AdminLogin == null) return BadRequest("Admin Login failed");

            return Ok(AdminLogin);
        }

    }
}
