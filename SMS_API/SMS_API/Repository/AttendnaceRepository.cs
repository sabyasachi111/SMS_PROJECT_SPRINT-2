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
    public class AttendnaceRepository : IAttendanceRepository
    {
        private readonly SMSContext _context;

        //Constructor
        public AttendnaceRepository(SMSContext context)
        {
            _context = context;
        }


        //Method to get details all Attendance from database
        public async Task<List<AttendanceModel>> GetAllAttendanceAsync()
        {
            var records = await _context.Attendances.Select(
                x => new AttendanceModel()
                {
                    AttendanceId = x.AttendanceId,
                    StudentId = x.StudentId,
                    AttendanceDate = x.AttendanceDate,
                    Attended = x.Attended

                }
            ).ToListAsync();

            return records;
        }


        //To Add new Attendance in the database
        public async Task<decimal> AddAttendanceAsync(AttendanceModel x)
        {
            // We create a object with property values of BookEntity class
            var attendance = new Attendance()
            {
                AttendanceId = x.AttendanceId,
                StudentId = x.StudentId,
                AttendanceDate = x.AttendanceDate,
                Attended = x.Attended
            };

            //Use BookContext class which is the connection class between database and application.
            //We specify the Table name and use Add method
            _context.Attendances.Add(attendance);
            //To save the changes in database
            await _context.SaveChangesAsync();

            return attendance.AttendanceId;
            //Since ID is primary feild it will be generated automatically
        }




        //Update Cashier data in database
        public async Task UpdateAttendnacePatchAsync(long Id, JsonPatchDocument cModel)
        {
            var attendance = await _context.Attendances.FindAsync(Id);

            if (attendance != null)
            {
                cModel.ApplyTo(attendance);

                //Save the changes
                await _context.SaveChangesAsync();
            }
        }

        //Delete Attendance data in database
        public async Task DeleteAttendanceAsync(long Id)
        {
            var attendance = new Attendance() { AttendanceId = Id };
            _context.Attendances.Remove(attendance);
            await _context.SaveChangesAsync();
        }
    }
}
