using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface ICashierRepository
    {
        Task<List<CashierModel>> GetAllCashierAsync();
        Task<CashierModel> GetCashierByIdAsync(long Id);
        Task<decimal> AddCashierAsync(CashierModel x);
        Task UpdateCashierPatchAsync(long Id, JsonPatchDocument cModel);
        Task DeleteCashierAsync(long Id);
    }
}
