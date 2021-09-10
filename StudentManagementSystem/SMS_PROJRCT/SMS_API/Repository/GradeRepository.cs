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
    public class GradeRepository : IGradeRepository
    {
        private readonly SMSContext _context;

        //Constructor
        public GradeRepository(SMSContext context)
        {
            _context = context;
        }


        //Method to get details all Grades from database
        public async Task<List<GradeModel>> GetAllGradeAsync()
        {
            var records = await _context.Grades.Select(
                x => new GradeModel()
                {
                   GradeId = x.GradeId,
                   StudentId = x.StudentId,
                   GradeName = x.GradeName,
                   Description = x.Description
                }
            ).ToListAsync();

            return records;
        }



        //To Add new Cashier in the database
        
        public async Task<decimal> AddGradeAsync(GradeModel x)
        {
            // We create a object with property values of BookEntity class
            var grade = new Grade()
            {
                GradeId = x.GradeId,
                StudentId = x.StudentId,
                GradeName = x.GradeName,
                Description = x.Description

            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Grades.Add(grade);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return grade.GradeId;
            //Since ID is primary feild it will be generated automatically
        }




        //Update Cashier data in database
        public async Task UpdateGradePatchAsync(decimal Id, JsonPatchDocument cModel)
        {
            var grade = await _context.Grades.FindAsync(Id);

            if (grade != null)
            {
                cModel.ApplyTo(grade);

                //Save the changes
                await _context.SaveChangesAsync();
            }
        }

        //Delete Student data in database
        public async Task DeleteGradeAsync(int Id)
        {
            var grade = new Grade() { GradeId = Id };
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
        }
    }
}

