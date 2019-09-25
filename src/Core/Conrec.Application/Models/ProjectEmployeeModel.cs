using System;
using System.Collections.Generic;

namespace Conrec.Application.Models
{
    public class ProjectEmployeeModel
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public bool IsActive { get; set; }
        public int TotalTimeWork { get; set; }
    }
}