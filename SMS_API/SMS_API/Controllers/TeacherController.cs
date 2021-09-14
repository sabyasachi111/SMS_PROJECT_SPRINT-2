using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMS_API.Models;
using SMS_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        //Inject the Interface
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }


        //Creating a action methods to handle the incomming HTTP Request

        //Method to Get all Books from Database
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherRepository.GetAllTeacherAsync();
            return Ok(teachers);
        }

        //Method to Get single Book from Database based on ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacherById([FromRoute] long id)
        {
            var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(teacher);
            }
        }

        //Method to Add a new Book in the database
        [HttpPost]
        public async Task<IActionResult> AddNewTeacher([FromBody] TeacherModel tModel)
        {
            var id = await _teacherRepository.AddTeacherAsync(tModel); //This method returns id of new added book

            //Since we are crating a new record. We expect 201. So we use CreatedAtAction response
            return CreatedAtAction(nameof(GetTeacherById), new { id = id, Controller = "Teacher" }, id);
        }

        
        //Method to Update
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTeacherPatch([FromRoute] long id, [FromBody] JsonPatchDocument bModel)
        {
            await _teacherRepository.UpdateTeacherPatchAsync(id, bModel); //This method does not have any return type


            return Ok();
        }

        //Method to Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] long id)
        {
            await _teacherRepository.DeleteTeachersAsync(id);

            return Ok();
        }
    }
}
