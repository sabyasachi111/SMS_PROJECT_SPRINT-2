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
    public class StudentRepository : IStudentRepository
    {
        private readonly SMSContext _context;

        //Constructor
        public StudentRepository(SMSContext context)
        {
            _context = context;
        }

        //Method to get details all Students from database
        public async Task<List<StudentModel>> GetAllStudentAsync()
        {
            var records = await _context.Students.Select(
                x => new StudentModel()
                {
                    StudentId = x.StudentId,
                    ClassName = x.ClassName,
                    StudentName = x.StudentName,
                    Gender = x.Gender,
                    Dob = x.Dob,
                    BloodGroup = x.BloodGroup,
                    Contact = x.Contact,
                    Address = x.Address
                }
            ).ToListAsync();

            return records;
        }

        //Method to get single student Record from database by ID
        public async Task<StudentModel> GetStudentByIdAsync(long Id)
        {
            //Here in the "Where" we define the condition
            var records = await _context.Students.Where(x => x.StudentId == Id).Select(
                x => new StudentModel()
                {
                    // Here we are doing manual conversionbut when feilds are more we use autoMapper
                    StudentId = x.StudentId,
                    ClassName = x.ClassName,
                    StudentName = x.StudentName,
                    Gender = x.Gender,
                    Dob = x.Dob,
                    BloodGroup = x.BloodGroup,
                    Contact = x.Contact,
                    Address = x.Address
                }
            ).FirstOrDefaultAsync();

            return records;
        }


        //To Add new Student in the database
        public async Task<long> AddStudentAsync(StudentModel x)
        {
            // We create a object with property values of BookEntity class
            var student = new Student()
            {
                StudentId = x.StudentId,
                ClassName = x.ClassName,
                StudentName = x.StudentName,
                Gender = x.Gender,
                Dob = x.Dob,
                BloodGroup = x.BloodGroup,
                Contact = x.Contact,
                Address = x.Address
            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Students.Add(student);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return student.StudentId;
            //Since ID is primary feild it will be generated automatically
        }



        //Update Student data in database
        public async Task UpdateStudentPatchAsync(long Id, JsonPatchDocument sModel)
        {
            var student = await _context.Students.FindAsync(Id);

            if (student != null)
            {
                sModel.ApplyTo(student);

                //Save the changes
                await _context.SaveChangesAsync();
            }
        }

        //Delete Student data in database
        public async Task DeleteStudentAsync(long Id)
        {
            var student = new Student() { StudentId = Id };
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
