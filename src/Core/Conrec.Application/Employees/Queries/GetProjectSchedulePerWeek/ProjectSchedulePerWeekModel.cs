using Conrec.Application.Models;
using Conrec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek
{
    public class ProjectSchedulePerWeekModel
    {
        public string DayName { get; set; }
        public bool IsBreakPaid { get; set; }
        public DateTimeOffset BreakStart { get; set; }
        public DateTimeOffset BreakEnd { get; set; }
        public DateTimeOffset DayStart { get; set; }
        public DateTimeOffset DayEnd { get; set; }
        public double EstimatedWorkedHoursWeekly { get; set; }

        private static DateTime GetStartOfWeek()
        {
            var dayOfWeek = (int)DateTime.Today.DayOfWeek;
            var startOfWeek = dayOfWeek == 0 ? 6 : dayOfWeek;

            return DateTime.Today.AddDays(-1 * startOfWeek);
        }

        public static Expression<Func<ProjectEmployee, ProjectSchedule>> LatestDefaultSchedule
        {
            get
            {
                return projectEmployee => projectEmployee.Project.ProjectSchedules.Last();
            }
        }

        public static List<ProjectEmployeeSchedule> CurrentWeekProjectEmployeeSchedules(ProjectEmployee projectEmployee)
        {
            var startOfWeek = GetStartOfWeek();
            var endOfWeek = startOfWeek.AddDays(6);
            var currentCustomProjectEmployeeSchedules = projectEmployee.ProjectEmployeeSchedules
                    .Where(x => x.EffectiveFrom.DateTime >= startOfWeek && x.EffectiveTo.DateTime <= endOfWeek)
                    .ToList();

            return currentCustomProjectEmployeeSchedules;
        }

        public static List<ProjectSchedulePerWeekModel> Create(ProjectEmployee projectEmployee)
        {
            var latestDefaultSchedule = LatestDefaultSchedule.Compile().Invoke(projectEmployee);
            var lastWeekCustomSchedule = CurrentWeekProjectEmployeeSchedules(projectEmployee);

            var defaultWeekSchedule = GetDefaultWeekWithSchedule(latestDefaultSchedule);

            if (!lastWeekCustomSchedule.Any()) return defaultWeekSchedule;

            var customWeekSchedule = GetCustomWeekWithSchedule(defaultWeekSchedule, lastWeekCustomSchedule);

            return customWeekSchedule;
        }

        private static List<ProjectSchedulePerWeekModel> GetCustomWeekWithSchedule(List<ProjectSchedulePerWeekModel> defaultWeekSchedule,
            List<ProjectEmployeeSchedule> lastWeekCustomSchedule)
        {
            var weekWithSchedule = new List<ProjectSchedulePerWeekModel>();
            foreach (var defaultSchedule in defaultWeekSchedule)
            {

                var customSchedule = lastWeekCustomSchedule
                    .Where(x => x.EffectiveFrom.Date <= defaultSchedule.DayStart.Date)
                    .OrderByDescending(x => x.Id)
                    .FirstOrDefault();

                if (customSchedule != null) // we have custom schedule day
                {
                    weekWithSchedule.Add(new ProjectSchedulePerWeekModel
                    {
                        DayName = defaultSchedule.DayName,
                        IsBreakPaid = customSchedule.Schedule.IsBreakPaid,
                        BreakStart = CleanHours(defaultSchedule.BreakStart).AddHours(customSchedule.Schedule.BreakStart.Hour),
                        BreakEnd = CleanHours(defaultSchedule.BreakEnd).AddHours(customSchedule.Schedule.BreakEnd.Hour),
                        DayStart = CleanHours(defaultSchedule.DayStart).AddHours(customSchedule.Schedule.DayStart.Hour),
                        DayEnd = CleanHours(defaultSchedule.DayEnd).AddHours(customSchedule.Schedule.DayEnd.Hour),
                        EstimatedWorkedHoursWeekly = customSchedule.Schedule.EstimatedWorkedHoursWeekly
                    });

                }
                else
                {
                    weekWithSchedule.Add(defaultSchedule);
                }
            }

            return weekWithSchedule;
        }

        public static DateTimeOffset CleanHours(DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset.AddHours(-1 * dateTimeOffset.Hour);
        }

        private static List<ProjectSchedulePerWeekModel> GetDefaultWeekWithSchedule(ProjectSchedule latestDefaultSchedule)
        {
            var weekWithSchedule = new List<ProjectSchedulePerWeekModel>();
            var startOfWeek = GetStartOfWeek();

            for (int beginWeekDay = 0, dayNameEnumId = 0; beginWeekDay < 7; beginWeekDay++)
            {
                ++dayNameEnumId; // start week with Monday
                weekWithSchedule.Add(new ProjectSchedulePerWeekModel
                {
                    DayName = dayNameEnumId == 7 ? ((DayOfWeek)0).ToString() : ((DayOfWeek)dayNameEnumId).ToString(),
                    IsBreakPaid = latestDefaultSchedule.Schedule.IsBreakPaid,
                    BreakStart = startOfWeek.AddDays(beginWeekDay).AddHours(latestDefaultSchedule.Schedule.BreakStart.Hour),
                    BreakEnd = startOfWeek.AddDays(beginWeekDay).AddHours(latestDefaultSchedule.Schedule.BreakEnd.Hour),
                    DayStart = startOfWeek.AddDays(beginWeekDay).AddHours(latestDefaultSchedule.Schedule.DayStart.Hour),
                    DayEnd = startOfWeek.AddDays(beginWeekDay).AddHours(latestDefaultSchedule.Schedule.DayEnd.Hour),
                    EstimatedWorkedHoursWeekly = latestDefaultSchedule.Schedule.EstimatedWorkedHoursWeekly,
                });
            }

            return weekWithSchedule;
        }
    }
}
