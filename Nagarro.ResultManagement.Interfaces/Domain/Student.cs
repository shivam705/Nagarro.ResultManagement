using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.ResultManagement.Interfaces.Domain
{
    public class Student
    {
        public int Id { get; set; }

        public int RollNo { get; set; }

        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public int Score { get; set; }
    }
}
