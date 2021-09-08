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
        Task<StudentModel> GetStudentByIdAsync(int Id);
        Task<decimal> AddStudentAsync(StudentModel x);
        Task UpdateStudentPatchAsync(decimal Id, JsonPatchDocument sModel);
        Task DeleteStudentAsync(int Id);
    }
}
