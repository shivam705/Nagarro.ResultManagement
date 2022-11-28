using Nagarro.ResultManagement.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.ResultManagement.Interfaces.Services
{
    public interface IStudentService
    {
        public IEnumerable<Student> GetAllStudent();

        public Student GetStudent(int id);

        public void CreateStudent(Student student);

        public void UpdateStudent(int id, Student book);

        public void DeleteStudent(int id);

        public Student GetStudentByRollNo(int rollNo);
    }
}
