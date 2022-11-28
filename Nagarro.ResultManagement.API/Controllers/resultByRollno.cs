using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nagarro.ResultManagement.API.Models;
using Nagarro.ResultManagement.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nagarro.ResultManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class resultByRollno : ControllerBase
    {

        private readonly IStudentService _studentService;

        public resultByRollno(IStudentService studentService)
        {
            _studentService = studentService;

        }

        [HttpGet("{rollNo}")]
        public ActionResult<StudentDetail> GetStudentByRollNo(int rollNo)
        {
            var student = _studentService.GetStudentByRollNo(rollNo);
            if (student == null)
                return NotFound();
            var studentDetails = new StudentDetail { Id = student.Id, RollNo = student.RollNo, Name = student.Name, DOB = student.DOB, Score = student.Score };
            return studentDetails;
            //return _StudentsRepo.GetStudent(id).Select(x => new StudentDetails { Id = x.Id, Name = x.Name, RollNo = x.RollNo, Score = x.Score });
        }
    }
}
