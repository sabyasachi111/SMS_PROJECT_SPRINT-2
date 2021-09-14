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
    public class CashierController : ControllerBase
    {
        private readonly ICashierRepository _cashierRepository;

        public CashierController(ICashierRepository cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }

        //Creating Action Methods to handle the incomming HTTP Requests



        //Method to get all Student record from database
        [HttpGet]
        public async Task<IActionResult> GetAllCashiers()
        {
            var cashier = await _cashierRepository.GetAllCashierAsync();
            return Ok(cashier);
        }



        //Method to Get single student Detail from Database based on ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashierById([FromRoute] long id)
        {
            var cashier = await _cashierRepository.GetCashierByIdAsync(id);
            if (cashier == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cashier);
            }
        }


        //Method to Add a new Student
        [HttpPost]
        public async Task<IActionResult> AddNewCashier([FromBody] CashierModel cModel)
        {
            var id = await _cashierRepository.AddCashierAsync(cModel); //This method returns id of new added book

            //Since we are crating a new record. We expect 201. So we use CreatedAtAction response
            return CreatedAtAction(nameof(GetCashierById), new { id = id, Controller = "Cashier" }, id);
        }



        //Method to Update student data in database
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCashierPatch([FromRoute] long id, [FromBody] JsonPatchDocument cModel)
        {
            await _cashierRepository.UpdateCashierPatchAsync(id, cModel); //This method does not have any return type


            return Ok();
        }


        //Method to delete student data in database
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashier([FromRoute] long id)
        {
            await _cashierRepository.DeleteCashierAsync(id);

            return Ok();
        }
    }
}
