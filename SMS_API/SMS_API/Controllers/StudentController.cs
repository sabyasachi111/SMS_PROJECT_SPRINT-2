using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMS_API.Data;
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
    public class StudentController : ControllerBase
    {
        //Inject the Interface
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        //Creating Action Methods to handle the incomming HTTP Requests



        //Method to get all Student record from database
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var student = await _studentRepository.GetAllStudentAsync();
            return Ok(student);
        }



        //Method to Get single student Detail from Database based on ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById([FromRoute] long id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }
        }


        //Method to Add a new Student
        [HttpPost]
        public async Task<IActionResult> AddNewStudent([FromBody] StudentModel sModel)
        {
            var id = await _studentRepository.AddStudentAsync(sModel); //This method returns id of new added book

            //Since we are crating a new record. We expect 201. So we use CreatedAtAction response
            return CreatedAtAction(nameof(GetStudentById), new { id = id, Controller = "Student" }, id);
        }



        //Method to Update student data in database
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStudentPatch([FromRoute] long id, [FromBody] JsonPatchDocument sModel)
        {
            await _studentRepository.UpdateStudentPatchAsync(id, sModel); //This method does not have any return type


            return Ok();
        }


        //Method to delete student data in database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            await _studentRepository.DeleteStudentAsync(id);

            return Ok();
        }
    }
}
