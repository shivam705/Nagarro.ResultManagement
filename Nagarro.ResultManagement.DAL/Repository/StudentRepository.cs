
using Nagarro.ResultManagement.DAL.Data.DbContexts;
using Nagarro.ResultManagement.Interfaces.Domain;
using Nagarro.ResultManagement.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.ResultManagement.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ResultManagementContext _dbContext;

        public StudentRepository(ResultManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateStudent(Student student)
        {
            //Map this Domain entity to ef models entity

            EFModels.Student st = new EFModels.Student { Dob = student.DOB, Name = student.Name, RollNo = student.RollNo, Score = student.Score };
            _dbContext.Add(st);
            _dbContext.SaveChanges();

        }

        public void DeleteStudent(int id)
        {
            _dbContext.Remove(_dbContext.Students.Where(x => x.Id == id).FirstOrDefault());
            _dbContext.SaveChanges();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return  _dbContext.Students.Select(x=> new Student {  Id=x.Id, DOB=x.Dob, Name=x.Name,RollNo=x.RollNo,Score=x.Score});

        }

        public Student GetStudent(int id)
        {
            return _dbContext.Students.Where(x => x.Id == id).Select(x=>new Student { Id = x.Id, DOB = x.Dob, Name = x.Name, RollNo = x.RollNo, Score = x.Score }).FirstOrDefault();

        }

        public void UpdateStudent(int id, Student book)
        {
            var studentIndex = _dbContext.Students.Where(x => x.Id == id).FirstOrDefault();
            studentIndex.Name=book.Name;

            studentIndex.Score = book.Score;
            studentIndex.Dob = book.DOB;
            studentIndex.RollNo = book.RollNo;
            _dbContext.SaveChanges();
           
        }

        public Student GetStudentByRollNo(int rollNo)
        {
            return _dbContext.Students.Where(x => x.RollNo == rollNo).Select(x => new Student { Id = x.Id, DOB = x.Dob, Name = x.Name, RollNo = x.RollNo, Score = x.Score }).FirstOrDefault();

        }
    }
}
