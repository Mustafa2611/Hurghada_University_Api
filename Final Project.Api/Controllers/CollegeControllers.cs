using Final_Project.Core.Dtos.CollegeDots;
using Final_Project.Core.Models;
using FinalProject.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollegeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // POST: api/College/Create_College
        [HttpPost("/Create_College")]
        public async Task<IActionResult> Create(CollegeCreateDto collegeDto)
        {
            College college = new College()
            {
                College_Name = collegeDto.College_Name,
                College_Description = collegeDto.College_Description,
                Contact_Information = collegeDto.Contact_Information,
               
            };

            var addCollege = await _unitOfWork.Colleges.AddAsync(college);
            if ( addCollege == null)
                return BadRequest("Add College operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(college);
        }

        // GET: api/College/Get_College_By_Id/{id}
        [HttpGet("/Get_College_By_Id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            College college =await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == id, new[] { "Departments"  });
            if (college == null)
                return NotFound("College not found");

            return Ok(college);
        }

        // GET: api/College/Get_All_Colleges
        [HttpGet("/Get_All_Colleges")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<College> colleges =await _unitOfWork.Colleges.GetAllAsync(null,new[] { "Departments" });
            if (colleges == null)
                return NotFound("There is no college created yet.");

            return Ok(colleges);
        }

        // PUT: api/College/Update_College
        [HttpPut("/Update_College")]
        public async Task<IActionResult> Update(CollegeUpdateDto collegeDto)
        {
            College college = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == collegeDto.CollegeId, new[] { "Departments" });

            if (college == null) return NotFound("College not found");


            college = new College()
            {
                CollegeId = collegeDto.CollegeId,
                College_Name = collegeDto.College_Name,
                College_Description = collegeDto.College_Description,
                Contact_Information = collegeDto.Contact_Information,

                //Departments = _unitOfWork.Colleges.GetDepartments(d => d.CollegeId == collegeDto.CollegeId)
            };

           var updateCollege = await _unitOfWork.Colleges.UpdateAsync(college);
            if (updateCollege == null) return BadRequest("College update operation failed");
           await _unitOfWork.CompleteAsync();
            return Ok(college);
        }

        // DELETE: api/College/Delete_College/{id}
        [HttpDelete("/Delete_College/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            College college = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == id, new[] { "Departments" });
            if (college == null) return NotFound("College Not Found");

            var DeleteCollege = await _unitOfWork.Colleges.DeleteAsync(id);
            if (DeleteCollege == null) return BadRequest("College delete operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(college);
        }
    }
}
