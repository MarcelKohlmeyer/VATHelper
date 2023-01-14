using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VATHelper.Migrations
{
    /// <inheritdoc />
    public partial class fixedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionPositions_Transactions_TransactionId",
                table: "TransactionPositions");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransactionId",
                table: "TransactionPositions",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionPositions_Transactions_TransactionId",
                table: "TransactionPositions",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionPositions_Transactions_TransactionId",
                table: "TransactionPositions");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransactionId",
                table: "TransactionPositions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionPositions_Transactions_TransactionId",
                table: "TransactionPositions",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id");
        }
    }
}
