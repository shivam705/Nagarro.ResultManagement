using Nagarro.ResultManagement.Interfaces.Domain;
using Nagarro.ResultManagement.Interfaces.Repositories;
using Nagarro.ResultManagement.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.ResultManagement.BL
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void CreateStudent(Student student)
        {
            //If i want to change anything in the student object do it in the business layer here itself
            _studentRepository.CreateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _studentRepository.GetAllStudent();
        }

        public Student GetStudent(int id)
        {
            return _studentRepository.GetStudent(id);
        }

        public void UpdateStudent(int id, Student book)
        {
            _studentRepository.UpdateStudent(id,book);
        }

        public Student GetStudentByRollNo(int rollNo)
        {
            return _studentRepository.GetStudentByRollNo(rollNo);
        }
    }
}
