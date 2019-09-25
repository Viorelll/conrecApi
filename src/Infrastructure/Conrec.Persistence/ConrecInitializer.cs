using Conrec.Domain.Entities;
using System;
using System.Linq;

namespace Conrec.Persistence
{
    public class ConrecInitializer
    {

        public static void Initialize(ConrecDbContext context)
        {
            var initializer = new ConrecInitializer();
            initializer.SeedEverything(context);
        }

        private void SeedEverything(ConrecDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Country.Any())
            {
                return; // Db has been seeded
            }

            SeedCountries(context);
            SeedRegions(context);
            SeedSalaryPayments(context);
            SeedUserRoles(context);
            SeedJobRoles(context);
            SeedSkills(context);
            SeedWorkDays(context);
            SeedCurrencies(context);
            SeedPaymentFrequency(context);
            SeedPaymentType(context);
        }

        private void SeedPaymentType(ConrecDbContext context)
        {
            var paymentTypes = new[]
            {
                new Currency {Name = "Hour", Description = "Pay per hour"},
                new Currency {Name = "Area", Description = "Pay per square meter"},
            };
            context.AddRange(paymentTypes);
            context.SaveChanges();
        }

        private void SeedPaymentFrequency(ConrecDbContext context)
        {
            var paymentFrequency = new[]
            {
                new Currency {Name = "Day", Description = "Pay per day"},
                new Currency {Name = "Week", Description = "Pay per week"},
            };
            context.AddRange(paymentFrequency);
            context.SaveChanges();
        }

        private void SeedRegions(ConrecDbContext context)
        {
            var regions = new[]
            {
                new Region {Name = "London", PostCode = "LON"},
                new Region {Name = "Manchester", PostCode = "MAN"},
            };
            context.AddRange(regions);
            context.SaveChanges();
        }

        private void SeedCurrencies(ConrecDbContext context)
        {
            var currencies = new[]
            {
                new Currency {Name = "USD", Description = "U.S. Dollar"},
                new Currency {Name = "EUR", Description = "Euro"},
            };
            context.AddRange(currencies);
            context.SaveChanges();
        }

        private void SeedWorkDays(ConrecDbContext context)
        {
            var worksDays = new[]
 {
                new WorkDay {Name = "PerHour", Description = "Pay per hour"},
                new WorkDay {Name = "PerDay", Description = "Pay per day"},
            };
            context.AddRange(worksDays);
            context.SaveChanges();
        }

        private void SeedSkills(ConrecDbContext context)
        {
            var skills = new[]
            {
                new Skill {Name = "Communicable", Description = "Very communicable person"},
                new Skill {Name = "HandMader", Description = "Could made everything with his hands"},
            };
            context.AddRange(skills);
            context.SaveChanges();
        }

        private void SeedJobRoles(ConrecDbContext context)
        {
            var jobRoles = new[]
            {
                new JobRole {Name = "Driver"},
                new JobRole {Name = "Electric"},
            };
            context.AddRange(jobRoles);
            context.SaveChanges();
        }

        private void SeedUserRoles(ConrecDbContext context)
        {
            var userRoles = new[]
{
                new UserRole {Name = "Employee"},
                new UserRole {Name = "Employer"},
            };
            context.AddRange(userRoles);
            context.SaveChanges();
        }

        private void SeedSalaryPayments(ConrecDbContext context)
        {
            var salaryPayments = new[]
            {
                new SalaryPayment {Name = "TeamMember", Description = "To each team member"},
                new SalaryPayment {Name = "TeamLeader", Description = "To the team leader"},
            };
            context.AddRange(salaryPayments);
            context.SaveChanges();
        }

        private void SeedCountries(ConrecDbContext context)
        {
            var countries = new []
            {
                new Country {Name = "MDA", Description = "Moldova - Best country ever"},
                new Country {Name = "UK", Description = "United Kingdom"},
                new Country {Name = "IT", Description = "Italy"},
            };
            context.Country.AddRange(countries);
            context.SaveChanges();
        }
    }
}
