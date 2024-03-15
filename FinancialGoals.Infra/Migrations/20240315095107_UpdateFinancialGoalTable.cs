﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancialGoals.Infra.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFinancialGoalTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ActualAmount",
                table: "FinancialGoal",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FinancialGoal",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualAmount",
                table: "FinancialGoal");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FinancialGoal");
        }
    }
}
