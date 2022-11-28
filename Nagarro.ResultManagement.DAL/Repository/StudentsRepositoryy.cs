
using System;
using Nagarro.ResultManagement.DAL.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Nagarro.ResultManagement.DAL.Repository
{
    public class StudentsRepository
    {

        private List<Student> _Students;

        public StudentsRepository()
        {
            _Students = new() { new Student { Id = Guid.NewGuid(), RollNo = 40, Name = "Kirtesh", Score = 201 } };
        }
        public void CreateStudent(Student student)
        {
            _Students.Add(student);
            //throw new NotImplementedException();
        }

        public void DeleteStudent(Guid id)
        {
            var studentIndex = _Students.FindLastIndex(x => x.Id == id);
            if (studentIndex > -1)
                _Students.RemoveAt(studentIndex);
            //throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _Students;
           
        }

        public Student GetStudent(Guid id)
        {
            var student = _Students.Where(x => x.Id == id).SingleOrDefault();
            return student;
            //throw new NotImplementedException();
        }

        public void UpdateStudent(Guid id, Student student)
        {
            var studentIndex = _Students.FindLastIndex(x => x.Id == id);
            if (studentIndex > -1)
                _Students[studentIndex] = student;
            //return student;
            //throw new NotImplementedException();
        }
    }
}
