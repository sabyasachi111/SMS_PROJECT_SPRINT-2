using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using SMS_API.Data;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public class CashierRepository : ICashierRepository
    {
        private readonly SMSContext _context;

        //Constructor
        public CashierRepository(SMSContext context)
        {
            _context = context;
        }



        //Method to get details all Cashiers from database
        public async Task<List<CashierModel>> GetAllCashierAsync()
        {
            var records = await _context.Cashiers.Select(
                x => new CashierModel()
                {
                    CashierId = x.CashierId,
                    CashierName = x.CashierName
                }
            ).ToListAsync();

            return records;
        }

        //Method to get single cashier Record from database by ID
        public async Task<CashierModel> GetCashierByIdAsync(int Id)
        {
            //Here in the "Where" we define the condition
            var records = await _context.Cashiers.Where(x => x.CashierId == Id).Select(
                x => new CashierModel()
                {
                    // Here we are doing manual conversion but when feilds are more we use autoMapper
                    CashierId = x.CashierId,
                    CashierName = x.CashierName
                }
            ).FirstOrDefaultAsync();

            return records;
        }


        //To Add new Cashier in the database
        public async Task<decimal> AddCashierAsync(CashierModel x)
        {
            // We create a object with property values of BookEntity class
            var cashier = new Cashier()
            {
                CashierId = x.CashierId,
                CashierName = x.CashierName
            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Cashiers.Add(cashier);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return cashier.CashierId;
            //Since ID is primary feild it will be generated automatically
        }
        



        //Update Cashier data in database
        public async Task UpdateCashierPatchAsync(decimal Id, JsonPatchDocument cModel)
        {
            var cashier = await _context.Cashiers.FindAsync(Id);

            if (cashier != null)
            {
                cModel.ApplyTo(cashier);

                //Save the changes
                await _context.SaveChangesAsync();
            }
        }

        //Delete Student data in database
        public async Task DeleteCashierAsync(int Id)
        {
            var cashier = new Cashier() { CashierId = Id };
            _context.Cashiers.Remove(cashier);
            await _context.SaveChangesAsync();
        }
    }
}
