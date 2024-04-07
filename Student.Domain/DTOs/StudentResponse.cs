using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Domain.DTOs
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public Guid Hash { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
