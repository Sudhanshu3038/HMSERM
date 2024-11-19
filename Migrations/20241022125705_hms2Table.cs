using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace HMSERM.Migrations
{
    /// <inheritdoc />
    public partial class hms2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Practitioners");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Clinics");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "ClinicAdmins");

            migrationBuilder.DropColumn(
                name: "BaseId",
                table: "Appointments");   

            migrationBuilder.RenameColumn(
                name: "FastName",
                table: "Practitioners",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Practitioners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(

               table: "Clinics",

               columns: new[] { "ClinicId", "Name", "Address", "Email", "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy" },

               values: new object[,]

               {

        { 1, "Health Clinic A", "123 Main St, City A", "contact@healthclinica.com", DateTime.Now, "system", DateTime.Now, "system" }

               });

            migrationBuilder.InsertData(

               table: "Users",

               columns: new[] { "UserId", "Email", "Role", "PasswordHash", "PasswordSalt", "ClinicId", "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy" },

               values: new object[,]

               {

        { 1, "user@healthclinic.com", "User", "hashed_password_2", new byte[] { }, 1, DateTime.Now, "system", DateTime.Now, "system" },

        { 2, "practitioner1@healthclinic.com", "Practitioner1", "hashed_password_2", new byte[] { }, 1, DateTime.Now, "system", DateTime.Now, "system" },

        { 3, "practitioner@healthclinic.com", "Practitioner2", "hashed_password_2", new byte[] { }, 1, DateTime.Now, "system", DateTime.Now, "system" },

               });

            migrationBuilder.InsertData(

                table: "Practitioners",

                columns: new[] { "PractitionerId", "FirstName", "MiddleName", "LastName", "Phone", "DOB", "Email", "ClinicId", "UserId", "CreatedDate", "CreatedBy", "ModifiedDate", "ModifiedBy" },

                values: new object[,]

                {

        { 1, "Jane", "B", "Smith", 1234567890, new DateTime(1988, 7, 14), "practitioner1@clinica.com", 1, 2, DateTime.Now, "system", DateTime.Now, "system" },

        { 2, "Dyan", "B", "Smith", 1234567890, new DateTime(1985, 5, 15), "practitioner2@clinica.com", 1, 3, DateTime.Now, "system", DateTime.Now, "system" },

                });

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Practitioners");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Practitioners",
                newName: "FastName");

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Practitioners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Clinics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "ClinicAdmins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BaseId",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
