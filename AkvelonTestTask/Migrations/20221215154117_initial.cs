using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AkvelonTestTask.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "projects_tbl",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    start_date = table.Column<DateTime>(nullable: false),
                    completion_date = table.Column<DateTime>(nullable: false),
                    project_status = table.Column<byte>(nullable: false),
                    priority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects_tbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tasks_tbl",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    task_status = table.Column<byte>(nullable: false),
                    priority = table.Column<int>(nullable: false),
                    project_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasks_tbl", x => x.id);
                    table.ForeignKey(
                        name: "FK_tasks_tbl_projects_tbl_project_id",
                        column: x => x.project_id,
                        principalTable: "projects_tbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tasks_tbl_project_id",
                table: "tasks_tbl",
                column: "project_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tasks_tbl");

            migrationBuilder.DropTable(
                name: "projects_tbl");
        }
    }
}
