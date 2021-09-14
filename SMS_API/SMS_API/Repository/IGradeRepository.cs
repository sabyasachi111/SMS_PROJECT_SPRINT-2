using Microsoft.AspNetCore.JsonPatch;
using SMS_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_API.Repository
{
    public interface IGradeRepository
    {
        Task<List<GradeModel>> GetAllGradeAsync();
        Task<long> AddGradeAsync(GradeModel x);
        Task UpdateGradePatchAsync(long Id, JsonPatchDocument cModel);
        Task DeleteGradeAsync(long Id);
    }
}
