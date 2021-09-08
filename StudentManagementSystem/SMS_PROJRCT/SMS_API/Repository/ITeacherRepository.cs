using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface ITeacherRepository
    {
        Task<List<TeacherModel>> GetAllTeacherAsync();
        Task<TeacherModel> GetTeacherByIdAsync(int Id);
        Task<decimal> AddTeacherAsync(TeacherModel tModel);
        Task UpdateTeacherPatchAsync(decimal Id, JsonPatchDocument tModel);
        Task DeleteTeachersAsync(int Id);
    }
}
