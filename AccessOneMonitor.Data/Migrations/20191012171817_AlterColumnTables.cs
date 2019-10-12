using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessOneMonitor.Data.Migrations
{
    public partial class AlterColumnTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Executions_dbo.Processes_ProcessId",
                table: "dbo.Executions");

            migrationBuilder.DropTable(
                name: "dbo.Processes");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "dbo.Executions",
                newName: "CommandId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Executions_ProcessId",
                table: "dbo.Executions",
                newName: "IX_dbo.Executions_CommandId");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExecution",
                table: "dbo.Executions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Output",
                table: "dbo.Executions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "dbo.Executions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<long>(
                name: "FreeSpace",
                table: "dbo.Computers",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "dbo.Commands",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Commands", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Executions_dbo.Commands_CommandId",
                table: "dbo.Executions",
                column: "CommandId",
                principalTable: "dbo.Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Executions_dbo.Commands_CommandId",
                table: "dbo.Executions");

            migrationBuilder.DropTable(
                name: "dbo.Commands");

            migrationBuilder.DropColumn(
                name: "DateExecution",
                table: "dbo.Executions");

            migrationBuilder.DropColumn(
                name: "Output",
                table: "dbo.Executions");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "dbo.Executions");

            migrationBuilder.RenameColumn(
                name: "CommandId",
                table: "dbo.Executions",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Executions_CommandId",
                table: "dbo.Executions",
                newName: "IX_dbo.Executions_ProcessId");

            migrationBuilder.AlterColumn<long>(
                name: "FreeSpace",
                table: "dbo.Computers",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "dbo.Processes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<long>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MemoryAllocation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Processes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Processes_dbo.Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "dbo.Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Processes_ComputerId",
                table: "dbo.Processes",
                column: "ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Executions_dbo.Processes_ProcessId",
                table: "dbo.Executions",
                column: "ProcessId",
                principalTable: "dbo.Processes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
