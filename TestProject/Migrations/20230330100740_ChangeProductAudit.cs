using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductAudit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Method",
                table: "ProductAudits");

            migrationBuilder.RenameColumn(
                name: "Path",
                table: "ProductAudits",
                newName: "DateNew");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "ProductAudits",
                newName: "DataOld");

            migrationBuilder.AlterColumn<string>(
                name: "ChangedBy",
                table: "ProductAudits",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateNew",
                table: "ProductAudits",
                newName: "Path");

            migrationBuilder.RenameColumn(
                name: "DataOld",
                table: "ProductAudits",
                newName: "Data");

            migrationBuilder.AlterColumn<long>(
                name: "ChangedBy",
                table: "ProductAudits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "ProductAudits",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
