using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessOneMonitor.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbo.Computers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HostName = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "dbo.Processes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MemoryAllocation = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    ComputerId = table.Column<long>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "dbo.Executions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComputerId = table.Column<long>(nullable: false),
                    ProcessId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbo.Executions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dbo.Executions_dbo.Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "dbo.Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dbo.Executions_dbo.Processes_ProcessId",
                        column: x => x.ProcessId,
                        principalTable: "dbo.Processes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Executions_ComputerId",
                table: "dbo.Executions",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Executions_ProcessId",
                table: "dbo.Executions",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_dbo.Processes_ComputerId",
                table: "dbo.Processes",
                column: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbo.Executions");

            migrationBuilder.DropTable(
                name: "dbo.Processes");

            migrationBuilder.DropTable(
                name: "dbo.Computers");
        }
    }
}
