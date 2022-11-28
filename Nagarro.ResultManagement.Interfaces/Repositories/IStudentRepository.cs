using Nagarro.ResultManagement.Interfaces.Domain;
using System;
using System.Collections.Generic;


namespace Nagarro.ResultManagement.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        public IEnumerable<Student> GetAllStudent();

        public Student GetStudent(int id);

        public void CreateStudent(Student student);

        public void UpdateStudent(int id, Student book);

        public void DeleteStudent(int id);

        public Student GetStudentByRollNo(int rollNo);

    }
}
