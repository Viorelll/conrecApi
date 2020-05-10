using Microsoft.EntityFrameworkCore;
using Conrec.Domain.Entities;

namespace Conrec.Persistence
{
    public class ConrecDbContext : DbContext
    {
        public ConrecDbContext(DbContextOptions<ConrecDbContext> options)
            : base(options)
        {
        }

        #region Enitites DbSets
        public DbSet<AdditionalInformation> AdditionalInformation { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employer> Employer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Report> Report { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectEmployee> ProjectEmployee { get; set; }
        public DbSet<ProjectSchedule> ProjectSchedule { get; set; }
        public DbSet<ProjectPayment> ProjectPayment { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<ProjectEmployeeSchedule> ProjectEmployeeSchedule { get; set; }
        public DbSet<ProjectPaymentEmployee> ProjectPaymentEmployee { get; set; }

        #endregion

        #region Ref DbSets
        public DbSet<Country> Country { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<WorkDay> WorkDay { get; set; }
        public DbSet<JobRole> JobRole { get; set; }
        public DbSet<PaymentFrequency> PaymentFrequency { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<SalaryPayment> SalaryPayment { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().ToTable("ref_Country");
            modelBuilder.Entity<Currency>().ToTable("ref_Currency");
            modelBuilder.Entity<WorkDay>().ToTable("ref_WorkDay");
            modelBuilder.Entity<JobRole>().ToTable("ref_JobRole");
            modelBuilder.Entity<PaymentFrequency>().ToTable("ref_PaymentFrequency");
            modelBuilder.Entity<Period>().ToTable("ref_Period");
            modelBuilder.Entity<SalaryPayment>().ToTable("ref_SalaryPayment");
            modelBuilder.Entity<Skill>().ToTable("ref_Skill");
            modelBuilder.Entity<UserRole>().ToTable("ref_UserRole");
            modelBuilder.Entity<PaymentType>().ToTable("ref_PaymentType");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConrecDbContext).Assembly);
        }
    }
}
