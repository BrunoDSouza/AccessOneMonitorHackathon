using Microsoft.EntityFrameworkCore.Migrations;

namespace AccessOneMonitor.Data.Migrations
{
    public partial class AlterNameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Executions_dbo.Commands_CommandId",
                table: "dbo.Executions");

            migrationBuilder.DropForeignKey(
                name: "FK_dbo.Executions_dbo.Computers_ComputerId",
                table: "dbo.Executions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Executions",
                table: "dbo.Executions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Computers",
                table: "dbo.Computers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbo.Commands",
                table: "dbo.Commands");

            migrationBuilder.RenameTable(
                name: "dbo.Executions",
                newName: "Executions");

            migrationBuilder.RenameTable(
                name: "dbo.Computers",
                newName: "Computers");

            migrationBuilder.RenameTable(
                name: "dbo.Commands",
                newName: "Commands");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Executions_ComputerId",
                table: "Executions",
                newName: "IX_Executions_ComputerId");

            migrationBuilder.RenameIndex(
                name: "IX_dbo.Executions_CommandId",
                table: "Executions",
                newName: "IX_Executions_CommandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Executions",
                table: "Executions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Computers",
                table: "Computers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commands",
                table: "Commands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Executions_Commands_CommandId",
                table: "Executions",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Executions_Computers_ComputerId",
                table: "Executions",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Executions_Commands_CommandId",
                table: "Executions");

            migrationBuilder.DropForeignKey(
                name: "FK_Executions_Computers_ComputerId",
                table: "Executions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Executions",
                table: "Executions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Computers",
                table: "Computers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commands",
                table: "Commands");

            migrationBuilder.RenameTable(
                name: "Executions",
                newName: "dbo.Executions");

            migrationBuilder.RenameTable(
                name: "Computers",
                newName: "dbo.Computers");

            migrationBuilder.RenameTable(
                name: "Commands",
                newName: "dbo.Commands");

            migrationBuilder.RenameIndex(
                name: "IX_Executions_ComputerId",
                table: "dbo.Executions",
                newName: "IX_dbo.Executions_ComputerId");

            migrationBuilder.RenameIndex(
                name: "IX_Executions_CommandId",
                table: "dbo.Executions",
                newName: "IX_dbo.Executions_CommandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Executions",
                table: "dbo.Executions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Computers",
                table: "dbo.Computers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbo.Commands",
                table: "dbo.Commands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Executions_dbo.Commands_CommandId",
                table: "dbo.Executions",
                column: "CommandId",
                principalTable: "dbo.Commands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_dbo.Executions_dbo.Computers_ComputerId",
                table: "dbo.Executions",
                column: "ComputerId",
                principalTable: "dbo.Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
