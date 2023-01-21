using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class initalmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_employees",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(name: "birth_date", type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hiredate = table.Column<DateTime>(name: "hire_date", type: "datetime2", nullable: false),
                    releasedate = table.Column<DateTime>(name: "release_date", type: "datetime2", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    managerid = table.Column<int>(name: "manager_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employees", x => x.id);
                    table.UniqueConstraint("AK_tb_m_employees_phone", x => x.phone);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_jobs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    minsalary = table.Column<int>(name: "min_salary", type: "int", nullable: false),
                    maxsalary = table.Column<int>(name: "max_salary", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_jobs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_accounts",
                columns: table => new
                {
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_accounts", x => x.employeeid);
                    table.ForeignKey(
                        name: "FK_tb_m_accounts_tb_m_employees_employee_id",
                        column: x => x.employeeid,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_req_time_off",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false),
                    startdate = table.Column<DateTime>(name: "start_date", type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(name: "end_date", type: "datetime2", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    allocationid = table.Column<int>(name: "allocation_id", type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false),
                    remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ispublish = table.Column<bool>(name: "is_publish", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_req_time_off", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_req_time_off_tb_m_employees_employee_id",
                        column: x => x.employeeid,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_r_job_placements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false),
                    departmentid = table.Column<int>(name: "department_id", type: "int", nullable: false),
                    jobid = table.Column<int>(name: "job_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_r_job_placements", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_r_job_placements_tb_m_departments_department_id",
                        column: x => x.departmentid,
                        principalTable: "tb_m_departments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_r_job_placements_tb_m_employees_employee_id",
                        column: x => x.employeeid,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_r_job_placements_tb_m_jobs_job_id",
                        column: x => x.jobid,
                        principalTable: "tb_m_jobs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_r_account_roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountid = table.Column<int>(name: "account_id", type: "int", nullable: false),
                    roleid = table.Column<int>(name: "role_id", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_r_account_roles", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_r_account_roles_tb_m_accounts_account_id",
                        column: x => x.accountid,
                        principalTable: "tb_m_accounts",
                        principalColumn: "employee_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_r_account_roles_tb_m_roles_role_id",
                        column: x => x.roleid,
                        principalTable: "tb_m_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_allocations_leave",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<int>(name: "employee_id", type: "int", nullable: false),
                    remaining = table.Column<int>(type: "int", nullable: false),
                    RequestTimeOffId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_allocations_leave", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_m_allocations_leave_tb_m_employees_employee_id",
                        column: x => x.employeeid,
                        principalTable: "tb_m_employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_m_allocations_leave_tb_m_req_time_off_RequestTimeOffId",
                        column: x => x.RequestTimeOffId,
                        principalTable: "tb_m_req_time_off",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_allocations_leave_employee_id",
                table: "tb_m_allocations_leave",
                column: "employee_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_allocations_leave_RequestTimeOffId",
                table: "tb_m_allocations_leave",
                column: "RequestTimeOffId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_req_time_off_employee_id",
                table: "tb_m_req_time_off",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_account_roles_account_id",
                table: "tb_r_account_roles",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_account_roles_role_id",
                table: "tb_r_account_roles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_job_placements_department_id",
                table: "tb_r_job_placements",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_job_placements_employee_id",
                table: "tb_r_job_placements",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_job_placements_job_id",
                table: "tb_r_job_placements",
                column: "job_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_m_allocations_leave");

            migrationBuilder.DropTable(
                name: "tb_r_account_roles");

            migrationBuilder.DropTable(
                name: "tb_r_job_placements");

            migrationBuilder.DropTable(
                name: "tb_m_req_time_off");

            migrationBuilder.DropTable(
                name: "tb_m_accounts");

            migrationBuilder.DropTable(
                name: "tb_m_roles");

            migrationBuilder.DropTable(
                name: "tb_m_departments");

            migrationBuilder.DropTable(
                name: "tb_m_jobs");

            migrationBuilder.DropTable(
                name: "tb_m_employees");
        }
    }
}
