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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SMSContext _context;

        public TeacherRepository(SMSContext context)
        {
            _context = context;
        }


        //Method to get all Books from database
        public async Task<List<TeacherModel>> GetAllTeacherAsync()
        {
            var records = await _context.Teachers.Select(
                x => new TeacherModel()
                {
                    // Here we are doing manual conversionbut when feilds are more we use autoMapper
                    
                    TeacherId = x.TeacherId,
                    ClassName = x.ClassName,
                    TeacherName = x.TeacherName,
                    Gender = x.Gender,
                    Dob = x.Dob,
                    Contact = x.Contact,
                    Email = x.Email,
                    Address = x.Address
                }
            ).ToListAsync();

            return records;
        }

        //Method to get single book from database by ID
        public async Task<TeacherModel> GetTeacherByIdAsync(long Id)
        {
            //Here in the "Where" we define the condition
            var records = await _context.Teachers.Where(x => x.TeacherId == Id).Select(
                x => new TeacherModel()
                {
                    // Here we are doing manual conversionbut when feilds are more we use autoMapper
                    TeacherId = x.TeacherId,
                    ClassName = x.ClassName,
                    TeacherName = x.TeacherName,
                    Gender = x.Gender,
                    Dob = x.Dob,
                    Contact = x.Contact,
                    Email = x.Email,
                    Address = x.Address
                }
            ).FirstOrDefaultAsync();

            return records;
        }

        //Method to add book in database
        public async Task<long> AddTeacherAsync(TeacherModel tModel)
        {
            // We create a object with property values of BookEntity class
            var teacher = new Teacher()
            {
                TeacherId = tModel.TeacherId,
                ClassName = tModel.ClassName,
                TeacherName = tModel.TeacherName,
                Gender = tModel.Gender,
                Dob = tModel.Dob,
                Contact = tModel.Contact,
                Email = tModel.Email,
                Address = tModel.Address
            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Teachers.Add(teacher);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return teacher.TeacherId;
            //Since ID is primary feild it will be generated automatically
        }

        public async Task UpdateTeacherPatchAsync(long Id, JsonPatchDocument tModel)
        {
            var teacher = await _context.Teachers.FindAsync(Id);

            if (teacher != null)
            {
                tModel.ApplyTo(teacher);

                //Save the changes
                await _context.SaveChangesAsync();
            }
        }


        //To delete Book
        public async Task DeleteTeachersAsync(long Id)
        {
            var book = new Teacher() { TeacherId = Id };
            _context.Teachers.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}
