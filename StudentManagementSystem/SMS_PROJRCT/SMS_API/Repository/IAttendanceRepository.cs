using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface IAttendanceRepository
    {
        Task<List<AttendanceModel>> GetAllAttendanceAsync();
        Task<decimal> AddAttendanceAsync(AttendanceModel x);
        Task UpdateAttendnacePatchAsync(decimal Id, JsonPatchDocument cModel);
        Task DeleteAttendanceAsync(int Id);
    }
}
