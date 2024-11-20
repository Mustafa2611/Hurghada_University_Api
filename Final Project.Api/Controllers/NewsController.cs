﻿using Final_Project.Core.Dtos.NewsDtos;
using FinalProject.Core.Models;
using FinalProject.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/Create_News")]
        public async Task<IActionResult> Create(CreateNewsDto NewsDto)
        {
            News News = new News()
            {
                Name = NewsDto.Name,
                Description = NewsDto.Description,
                News_Date = NewsDto.News_Date,
                CollegeId = NewsDto.CollegeId,
                //College =await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == NewsDto.CollegeId, new[] { "Departments" })
            };
            var College = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == NewsDto.CollegeId, new[] { "Departments" });
            if(College == null) return NotFound("College not found");

            var NewsAdded = await _unitOfWork.News.AddAsync(News);
            if ( NewsAdded == null)
                return BadRequest("Add News operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(News);
        }

        [HttpGet("/Get_News_By_Id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var News = await _unitOfWork.News.GetByIdAsync(n => n.NewsId == id, new[] { "College" });
            if (News == null) return NotFound("News not found");

            return Ok(News);
        }

        [HttpGet("/Get_All_News")]
        public async Task<IActionResult> GetAll()
        {
            var News = await _unitOfWork.News.GetAllAsync(null,new[] {"College"});
            if (News == null) return NotFound("There is no news created");

            return Ok(News);
        }

        [HttpPut("/Update_News")]
        public async Task<IActionResult> Update(UpdateNewsDto NewsDto)
        {
            News News = await _unitOfWork.News.GetByIdAsync(n => n.NewsId == NewsDto.NewsId, new[] { "College" });
            var College = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == NewsDto.CollegeId);
           
            if (News == null) return NotFound("News not found");

            if(College == null) return NotFound("College not found");

            News = new()
            {
                NewsId = NewsDto.NewsId,
                Name = NewsDto.Name,
                Description = NewsDto.Description,
                News_Date = NewsDto.News_Date,
                CollegeId = NewsDto.CollegeId,
                //College =await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == NewsDto.CollegeId, new[] { "Departments" })
            };
            
            var NewsUpdated = await _unitOfWork.News.UpdateAsync(News);
            if (NewsUpdated == null) return BadRequest("News Update operation failed");
            await _unitOfWork.CompleteAsync();
            return Ok(News);
        }

        [HttpDelete("/Delete_News/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var News = await _unitOfWork.News.GetByIdAsync(n => n.NewsId == id, new[] { "College" });
            if (News == null) return NotFound("News Not Found");

            var NewsDeleted = await _unitOfWork.News.DeleteAsync(id);
            if (NewsDeleted == null) return BadRequest("News delete operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(News);
        }
    }
}
