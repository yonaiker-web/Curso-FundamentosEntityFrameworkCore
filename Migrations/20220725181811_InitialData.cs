using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FundamentosEntityFramework.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoryId", "Description", "Name", "Peso" },
                values: new object[,]
                {
                    { new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce623"), null, "Actividades Pendientes", 20 },
                    { new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce6af"), null, "Actividades Personales", 50 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TaskId", "CategoryId", "Creation", "Description", "PriorityTask", "Title" },
                values: new object[,]
                {
                    { new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce610"), new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce623"), new DateTime(2022, 7, 25, 14, 18, 10, 81, DateTimeKind.Local).AddTicks(8523), null, 1, "Pago de servicios publicos" },
                    { new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce611"), new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce6af"), new DateTime(2022, 7, 25, 14, 18, 10, 81, DateTimeKind.Local).AddTicks(8550), null, 0, "Terminar de ver Pelicula en Netflix" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce610"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TaskId",
                keyValue: new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce611"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce623"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoryId",
                keyValue: new Guid("e62a447f-de7d-4070-b4e9-435e2b0ce6af"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
