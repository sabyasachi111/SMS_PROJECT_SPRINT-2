using Microsoft.AspNetCore.Http;
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
    public class FeeController : ControllerBase
    {
        private readonly IFeeRepository _feeRepository;

        public FeeController(IFeeRepository feeRepository)
        {
            _feeRepository = feeRepository;
        }

        //Creating Action Methods to handle the incomming HTTP Requests



        //Method to get all fee record from database
        [HttpGet]
        public async Task<IActionResult> GetAllAttendance()
        {
            var fee = await _feeRepository.GetAllFeeAsync();
            return Ok(fee);
        }



        //Method to Add a new Student fee record
        [HttpPost]
        public async Task<IActionResult> AddNewFee([FromBody] FeeModel cModel)
        {
            var id = await _feeRepository.AddFeeAsync(cModel); //This method returns id of new added book

            //Since we are crating a new record. We expect 201. So we use CreatedAtAction response. But here we just passing 200 OK
            return Ok();
        }



        //Method to Get single Fess Detail from Database based on ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeesById([FromRoute] long id)
        {
            var fees = await _feeRepository.GetFeesByIdAsync(id);
            if (fees == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(fees);
            }
        }


        //Method to delete student fee data in database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFee([FromRoute] long id)
        {
            await _feeRepository.DeleteFeeAsync(id);

            return Ok();
        }
    }
}
