using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface IFeeRepository
    {
        Task<List<FeeModel>> GetAllFeeAsync();
        Task<decimal> AddFeeAsync(FeeModel x);
        Task DeleteFeeAsync(int Id);
    }
}
