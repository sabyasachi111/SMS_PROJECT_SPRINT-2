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
    public class FeeRepository : IFeeRepository
    {

        private readonly SMSContext _context;

        //Constructor
        public FeeRepository(SMSContext context)
        {
            _context = context;
        }


        //Method to get details all Fee Details from database
        public async Task<List<FeeModel>> GetAllFeeAsync()
        {
            var records = await _context.Fees.Select(
                x => new FeeModel()
                {
                    InvoiceId = x.InvoiceId,
                    StudentId = x.StudentId,
                    CashierId = x.CashierId,
                    PaymentDate = x.PaymentDate,
                    FeesAmount = x.FeesAmount

                }
            ).ToListAsync();

            return records;
        }


        //To Add new Fees Payment in the database
        public async Task<long> AddFeeAsync(FeeModel x)
        {
            // We create a object with property values of BookEntity class
            var fee = new Fee()
            {
                InvoiceId = x.InvoiceId,
                StudentId = x.StudentId,
                CashierId = x.CashierId,
                PaymentDate = x.PaymentDate,
                FeesAmount = x.FeesAmount
            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Fees.Add(fee);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return fee.InvoiceId;
            //Since ID is primary feild it will be generated automatically
        }


        //Method to get single Fees Record from database by ID
        public async Task<FeeModel> GetFeesByIdAsync(long Id)
        {
            //Here in the "Where" we define the condition
            var records = await _context.Fees.Where(x => x.InvoiceId == Id).Select(
                x => new FeeModel()
                {
                    // Here we are doing manual conversionbut when feilds are more we use autoMapper
                    InvoiceId = x.InvoiceId,
                    StudentId = x.StudentId,
                    CashierId = x.CashierId,
                    FeesAmount = x.FeesAmount,
                    Cashier = x.Cashier,
                    PaymentDate = x.PaymentDate,
                }
            ).FirstOrDefaultAsync();

            return records;
        }


        //Delete Fee data in database
        public async Task DeleteFeeAsync(long Id)
        {
            var fees = new Fee() { InvoiceId = Id };
            _context.Fees.Remove(fees);
            await _context.SaveChangesAsync();
        }
    }
}
