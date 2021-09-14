using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> GetAllStudentAsync();
        Task<StudentModel> GetStudentByIdAsync(long Id);
        Task<long> AddStudentAsync(StudentModel x);
        Task UpdateStudentPatchAsync(long Id, JsonPatchDocument sModel);
        Task DeleteStudentAsync(long Id);
    }
}
