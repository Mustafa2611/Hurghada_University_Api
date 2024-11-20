﻿using Final_Project.Core.Dtos.NewsDtos;
using FinalProject.Core.Models;
using FinalProject.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Final_Project.Core.Dtos.EventDtos;

namespace Final_Project.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/Create_Event")]
        public async Task<IActionResult> Create(CreateEvent EventDto) {
            Event Event = new Event()
            {
                Name = EventDto.Name,
                Description = EventDto.Description,
                Event_Start_Date = EventDto.Event_Start_Date,
                CollegeId = EventDto.CollegeId,
                //College =await _unitOfWork.Colleges.GetByIdAsync(c=> c.CollegeId == EventDto.CollegeId , new[] {"Departments"})
            };

            var College = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == EventDto.CollegeId, new[] { "Departments" });
            if (College == null) return NotFound("College not found");

            var EventAdded = await _unitOfWork.Events.AddAsync(Event);
            if (EventAdded == null)
                return BadRequest("Bad Request");

           
            await _unitOfWork.CompleteAsync();
            return Ok(Event);
        }

        [HttpGet("/Get_Event_By_Id/{id}")]
        public async Task<IActionResult> Get(int id) {
            var Event = await _unitOfWork.Events.GetByIdAsync(e=> e.EventId == id , new[] {"College"});
            if (Event == null) return NotFound("News not found");

            return Ok(Event);
        }

        [HttpGet("/Get_All_Events")]
        public async Task<IActionResult> GetAll()
        {
            var Events = await _unitOfWork.Events.GetAllAsync(null,new[] { "College" } );
            if (Events == null) return NotFound("There is no news created");

            return Ok(Events);
        }

        [HttpPut("/Update_Event")]
        public async Task<IActionResult> Update(UpdateEvent EventDto)
        {
            Event Event = await _unitOfWork.Events.GetByIdAsync(e => e.EventId == EventDto.EventId, new[] { "College" });
            var College = await _unitOfWork.Colleges.GetByIdAsync(c => c.CollegeId == EventDto.CollegeId);

            if ( Event == null) return NotFound("Event Not Found");
            if ( College == null) return NotFound("College not found");

            Event = new()
            {
                EventId = EventDto.EventId,
                Name = EventDto.Name,
                Description = EventDto.Description,
                Event_Start_Date = EventDto.Event_Start_Date,
                CollegeId = EventDto.CollegeId,
                //College =await _unitOfWork.Colleges.GetByIdAsync(c=> c.CollegeId == EventDto.CollegeId , new[] {"Departments"})
            };


            var EventUpdated  = await _unitOfWork.Events.UpdateAsync(Event);
            if (EventUpdated == null) return BadRequest("Event Update operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(Event);
        }

        [HttpDelete("/Delete_Event/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Event = await _unitOfWork.Events.GetByIdAsync(e => e.EventId == id, new[] { "College" });
            if (Event == null)
                return NotFound("Event Not Found");

            var EventDeleted = await _unitOfWork.Events.DeleteAsync(id);
            if (EventDeleted == null) return BadRequest("Event delete operation failed");

            await _unitOfWork.CompleteAsync();
            return Ok(Event);
        }
    }
}
