using Microsoft.EntityFrameworkCore.Migrations;

namespace AkvelonTestTask.Migrations
{
    public partial class fk_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tasks_tbl_projects_tbl_project_id",
                table: "tasks_tbl");

            migrationBuilder.DropIndex(
                name: "IX_tasks_tbl_project_id",
                table: "tasks_tbl");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tasks_tbl",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "projects_tbl",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tasks_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "projects_tbl",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_tasks_tbl_project_id",
                table: "tasks_tbl",
                column: "project_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tasks_tbl_projects_tbl_project_id",
                table: "tasks_tbl",
                column: "project_id",
                principalTable: "projects_tbl",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
