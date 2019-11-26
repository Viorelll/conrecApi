using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Conrec.Persistence.Migrations
{
    public partial class Init_ConrecDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WillingMiles = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 100, nullable: true),
                    HasOwnCar = table.Column<bool>(nullable: false),
                    HasRequiredPPE = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Reference = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_Currency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_JobRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_JobRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_PaymentFrequency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_PaymentFrequency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_PaymentType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_PaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_Period",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_SalaryPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_SalaryPayment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_Skill",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_Skill", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ref_WorkDay",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ref_WorkDay", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    PostCode = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Requires = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    FilledBy = table.Column<DateTimeOffset>(nullable: false),
                    PostedOn = table.Column<DateTimeOffset>(nullable: false),
                    StartedDate = table.Column<DateTimeOffset>(nullable: false),
                    CompletedDate = table.Column<DateTimeOffset>(nullable: false),
                    ExpectedDate = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(maxLength: 100, nullable: true),
                    ShortCode = table.Column<string>(maxLength: 100, nullable: true),
                    Subject = table.Column<string>(maxLength: 100, nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    OriginalPayRate = table.Column<double>(nullable: false),
                    AdjustedPayRate = table.Column<double>(nullable: false),
                    WorkedHours = table.Column<double>(nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    PaymentFrequencyId = table.Column<int>(nullable: false),
                    PaymentTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_ref_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "ref_Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_ref_PaymentFrequency_PaymentFrequencyId",
                        column: x => x.PaymentFrequencyId,
                        principalTable: "ref_PaymentFrequency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payment_ref_PaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "ref_PaymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderId = table.Column<int>(nullable: false),
                    SalaryPaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_ref_SalaryPayment_SalaryPaymentId",
                        column: x => x.SalaryPaymentId,
                        principalTable: "ref_SalaryPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsBreakPaid = table.Column<bool>(nullable: false),
                    BreakStart = table.Column<DateTimeOffset>(nullable: false),
                    BreakEnd = table.Column<DateTimeOffset>(nullable: false),
                    DayStart = table.Column<DateTimeOffset>(nullable: false),
                    DayEnd = table.Column<DateTimeOffset>(nullable: false),
                    TotalHoursWorked = table.Column<double>(nullable: false),
                    WorkDayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_ref_WorkDay_WorkDayId",
                        column: x => x.WorkDayId,
                        principalTable: "ref_WorkDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 512, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTimeOffset>(nullable: true),
                    UserRolesId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_ref_UserRole_UserRolesId",
                        column: x => x.UserRolesId,
                        principalTable: "ref_UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ShortCode = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bank_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    NINO = table.Column<string>(maxLength: 100, nullable: true),
                    Experience = table.Column<int>(nullable: false),
                    AvailabilWorkImmediate = table.Column<bool>(nullable: false),
                    AvailabilStartsOn = table.Column<DateTimeOffset>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    SkillId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: true),
                    AdditionalInformationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AdditionalInformation_AdditionalInformationId",
                        column: x => x.AdditionalInformationId,
                        principalTable: "AdditionalInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_ref_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "ref_Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_ref_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "ref_Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Team_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    JobRoleId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employer_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employer_ref_JobRole_JobRoleId",
                        column: x => x.JobRoleId,
                        principalTable: "ref_JobRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOn = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Path = table.Column<string>(maxLength: 100, nullable: true),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    TotalTimeWork = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectEmployee_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificationClarity = table.Column<int>(nullable: false),
                    Communication = table.Column<int>(nullable: false),
                    PaymentPromptness = table.Column<int>(nullable: false),
                    Professionalism = table.Column<int>(nullable: false),
                    WorkAgain = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 200, nullable: true),
                    ProjectEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_ProjectEmployee_ProjectEmployeeId",
                        column: x => x.ProjectEmployeeId,
                        principalTable: "ProjectEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectEmployeePayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true),
                    ProjectEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectEmployeePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeePayment_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeePayment_ProjectEmployee_ProjectEmployeeId",
                        column: x => x.ProjectEmployeeId,
                        principalTable: "ProjectEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectEmployeePayment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSchedule",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EffectiveFrom = table.Column<DateTimeOffset>(nullable: false),
                    EffectiveTo = table.Column<DateTimeOffset>(nullable: false),
                    ProjectId = table.Column<int>(nullable: true),
                    ScheduleId = table.Column<int>(nullable: true),
                    ProjectEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSchedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSchedule_ProjectEmployee_ProjectEmployeeId",
                        column: x => x.ProjectEmployeeId,
                        principalTable: "ProjectEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectSchedule_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectSchedule_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Absences = table.Column<int>(nullable: false),
                    IssuesNumber = table.Column<int>(nullable: false),
                    IssuesPerDay = table.Column<int>(nullable: false),
                    Warnings = table.Column<int>(nullable: false),
                    WorkDays = table.Column<int>(nullable: false),
                    Review = table.Column<string>(maxLength: 200, nullable: true),
                    ProjectEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Report_ProjectEmployee_ProjectEmployeeId",
                        column: x => x.ProjectEmployeeId,
                        principalTable: "ProjectEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bank_UserId",
                table: "Bank",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UserId",
                table: "Contact",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_EmployeeId",
                table: "Document",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_UserId",
                table: "Document",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AdditionalInformationId",
                table: "Employee",
                column: "AdditionalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CountryId",
                table: "Employee",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SkillId",
                table: "Employee",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_TeamId",
                table: "Employee",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Employer_CompanyId",
                table: "Employer",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employer_JobRoleId",
                table: "Employer",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ProjectEmployeeId",
                table: "Feedback",
                column: "ProjectEmployeeId",
                unique: true,
                filter: "[ProjectEmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CurrencyId",
                table: "Payment",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentFrequencyId",
                table: "Payment",
                column: "PaymentFrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentTypeId",
                table: "Payment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CompanyId",
                table: "Project",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_EmployeeId",
                table: "ProjectEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployee_ProjectId",
                table: "ProjectEmployee",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeePayment_PaymentId",
                table: "ProjectEmployeePayment",
                column: "PaymentId",
                unique: true,
                filter: "[PaymentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeePayment_ProjectEmployeeId",
                table: "ProjectEmployeePayment",
                column: "ProjectEmployeeId",
                unique: true,
                filter: "[ProjectEmployeeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectEmployeePayment_ProjectId",
                table: "ProjectEmployeePayment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSchedule_ProjectEmployeeId",
                table: "ProjectSchedule",
                column: "ProjectEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSchedule_ProjectId",
                table: "ProjectSchedule",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSchedule_ScheduleId",
                table: "ProjectSchedule",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Report_ProjectEmployeeId",
                table: "Report",
                column: "ProjectEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_WorkDayId",
                table: "Schedule",
                column: "WorkDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_SalaryPaymentId",
                table: "Team",
                column: "SalaryPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RegionId",
                table: "User",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRolesId",
                table: "User",
                column: "UserRolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ProjectEmployeePayment");

            migrationBuilder.DropTable(
                name: "ProjectSchedule");

            migrationBuilder.DropTable(
                name: "ref_Period");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");

            migrationBuilder.DropTable(
                name: "ref_JobRole");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "ProjectEmployee");

            migrationBuilder.DropTable(
                name: "ref_Currency");

            migrationBuilder.DropTable(
                name: "ref_PaymentFrequency");

            migrationBuilder.DropTable(
                name: "ref_PaymentType");

            migrationBuilder.DropTable(
                name: "ref_WorkDay");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "AdditionalInformation");

            migrationBuilder.DropTable(
                name: "ref_Country");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ref_Skill");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "ref_UserRole");

            migrationBuilder.DropTable(
                name: "ref_SalaryPayment");
        }
    }
}
