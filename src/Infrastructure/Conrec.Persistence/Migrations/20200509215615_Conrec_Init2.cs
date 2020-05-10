using Microsoft.EntityFrameworkCore.Migrations;

namespace Conrec.Persistence.Migrations
{
    public partial class Conrec_Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectSchedule_ProjectEmployee_ProjectEmployeeId",
                table: "ProjectSchedule");

            migrationBuilder.DropIndex(
                name: "IX_ProjectSchedule_ProjectEmployeeId",
                table: "ProjectSchedule");

            migrationBuilder.DropColumn(
                name: "ProjectEmployeeId",
                table: "ProjectSchedule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectEmployeeId",
                table: "ProjectSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSchedule_ProjectEmployeeId",
                table: "ProjectSchedule",
                column: "ProjectEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectSchedule_ProjectEmployee_ProjectEmployeeId",
                table: "ProjectSchedule",
                column: "ProjectEmployeeId",
                principalTable: "ProjectEmployee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
