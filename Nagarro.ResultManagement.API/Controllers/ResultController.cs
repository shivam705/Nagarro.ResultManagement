using Microsoft.AspNetCore.Mvc;
using Nagarro.ResultManagement.API.Models;
using Nagarro.ResultManagement.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Nagarro.ResultManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public ResultController(IStudentService studentService)
        {
            _studentService = studentService;
            
        }


        
        [HttpGet]
        public ActionResult<IEnumerable<StudentDetail>> GetAllStudent()
        {
            return _studentService.GetAllStudent().Select(x=>new StudentDetail { Id=x.Id,Name=x.Name,RollNo=x.RollNo,DOB=x.DOB,Score=x.Score}).ToList();//new string[] { "value1", "value2" };
        }



        // GET api/<ResultController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentDetail> GetStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            var studentDetails = new StudentDetail { Id=student.Id, RollNo=student.RollNo,Name=student.Name,DOB=student.DOB,Score=student.Score};
            return studentDetails;
           
        }



        // POST api/<ResultController>
        [HttpPost]
        public ActionResult CreateStudent([FromBody] StudentDetail studentDetails)
        {
            var student = new Interfaces.Domain.Student();
            student.RollNo = studentDetails.RollNo;
            student.Name = studentDetails.Name;
            student.DOB = studentDetails.DOB;
            student.Score = studentDetails.Score;

            _studentService.CreateStudent(student);
            return Ok();
        }



        // PUT api/<ResultController>/5
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, [FromBody] StudentDetail studentDetails)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            student.RollNo = studentDetails.RollNo;
            student.Name = studentDetails.Name;
            student.DOB = studentDetails.DOB;
            student.Score = studentDetails.Score;
            _studentService.UpdateStudent(id,student);
            return Ok();
        }



        // DELETE api/<ResultController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudent(id);
            if (student == null)
                return NotFound();
            _studentService.DeleteStudent(id);
            return Ok();
        }

        
    }
}
