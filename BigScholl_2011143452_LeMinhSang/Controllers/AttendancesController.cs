using BigScholl_2011143452_LeMinhSang.DTOs;
using BigScholl_2011143452_LeMinhSang.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace BigScholl_2011143452_LeMinhSang.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        public ApplicationDbContext _dbContex;
        public AttendancesController(ApplicationDbContext dbContex)
        {
            _dbContex = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContex.Attendances.Any(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId))
                return BadRequest("The Attendance already exists!");

            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = userId
            };
            _dbContex.Attendances.Add(attendance);
            _dbContex.SaveChanges();

            return Ok();
        }
    }
}