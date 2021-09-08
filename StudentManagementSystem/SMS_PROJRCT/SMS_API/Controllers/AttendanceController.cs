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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceRepository _attendanceRepository;

        public AttendanceController(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }


        //Creating Action Methods to handle the incomming HTTP Requests



        //Method to get all Student record from database
        [HttpGet]
        public async Task<IActionResult> GetAllAttendance()
        {
            var attendance = await _attendanceRepository.GetAllAttendanceAsync();
            return Ok(attendance);
        }



        //Method to Add a new Student
        [HttpPost]
        public async Task<IActionResult> AddNewAttendance([FromBody] AttendanceModel cModel)
        {
            var id = await _attendanceRepository.AddAttendanceAsync(cModel); //This method returns id of new added book

            //Since we are crating a new record. We expect 201. So we use CreatedAtAction response. But here we just passing 200 OK
            return Ok();
        }



        //Method to Update student data in database
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAttendancePatch([FromRoute] decimal id, [FromBody] JsonPatchDocument cModel)
        {
            await _attendanceRepository.UpdateAttendnacePatchAsync(id, cModel); //This method does not have any return type


            return Ok();
        }


        //Method to delete student data in database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance([FromRoute] int id)
        {
            await _attendanceRepository.DeleteAttendanceAsync(id);

            return Ok();
        }
    }
}
