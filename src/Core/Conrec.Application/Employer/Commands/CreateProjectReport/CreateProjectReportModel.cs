﻿namespace Conrec.Application.Employer.Commands.CreateProjectReport
{
    public class CreateProjectReportModel
    {
        public int Absences { get; set; }
        public int IssuesNumber { get; set; }
        public int IssuesPerDay { get; set; }
        public int Warnings { get; set; }
        public int WorkDays { get; set; }
        public string Review { get; set; }
    }
}