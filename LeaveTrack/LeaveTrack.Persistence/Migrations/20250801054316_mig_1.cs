using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveTrack.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LeaveTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LeaveSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Leaves",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Üretim Hattı", false, "Üretim" },
                    { 2, "Araştırma ve Geliştirme", false, "Ar-Ge" },
                    { 3, "Kalite Kontrol", false, "Kalite" },
                    { 4, "Personel ve süreç yönetimi", false, "İnsan Kaynakları" },
                    { 5, "Makine ve sistem bakımı", false, "Bakım" },
                    { 6, "IT Departmanı", false, "Bilgi İşlem" },
                    { 7, "Malzeme ve hizmet tedariki", false, "Satın Alma" },
                    { 8, "Finansal işlemler", false, "Finans" },
                    { 9, "Müşteri ilişkileri", false, "Satış" },
                    { 10, "Depolama ve taşıma", false, "Lojistik" }
                });

            migrationBuilder.InsertData(
                table: "LeaveSettings",
                columns: new[] { "Id", "AnnualLeaveLimit", "IsDeleted" },
                values: new object[] { 1, 20, false });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "Yıllık izin hakkı", false, "Yıllık İzin" },
                    { 2, "Sağlık nedeniyle izin", false, "Hastalık İzni" },
                    { 3, "Doğum yapan çalışanlar için izin", false, "Doğum İzni" },
                    { 4, "Maaşsız izin", false, "Ücretsiz İzin" },
                    { 5, "Evlilik nedeniyle verilen izin", false, "Evlilik İzni" },
                    { 6, "Yakın kaybı sonrası izin", false, "Cenaze İzni" },
                    { 7, "Görev nedeniyle verilen izin", false, "Görev İzni" },
                    { 8, "Yarım günlük izin", false, "Yarım Gün İzin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AnnualLeaveLimit", "DepartmentId", "FullName", "IsDeleted", "IsSystemUser", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, null, 1, "Ali Balun", false, true, "hashedpw1", 0, "ali.balun" },
                    { 2, 15, 2, "Ayşe Yılmaz", false, false, "hashedpw2", 1, "ayse.yilmaz" },
                    { 3, 18, 3, "Mehmet Demir", false, false, "hashedpw3", 1, "mehmet.demir" },
                    { 4, 14, 4, "Zeynep Kaya", false, false, "hashedpw4", 1, "zeynep.kaya" },
                    { 5, 20, 5, "Emre Can", false, false, "hashedpw5", 1, "emre.can" },
                    { 6, null, 6, "Burcu Aydın", false, false, "hashedpw6", 1, "burcu.aydin" },
                    { 7, 22, 7, "Deniz Yıldız", false, false, "hashedpw7", 1, "deniz.yildiz" },
                    { 8, null, 8, "Kerem Öz", false, false, "hashedpw8", 1, "kerem.oz" },
                    { 9, 16, 9, "İlayda Çetin", false, false, "hashedpw9", 1, "ilayda.cetin" },
                    { 10, null, 10, "Onur Güneş", false, false, "hashedpw10", 1, "onur.gunes" }
                });

            migrationBuilder.InsertData(
                table: "Leaves",
                columns: new[] { "Id", "CreatedByUserId", "EmployeeId", "EndDate", "IsDeleted", "LeaveTypeId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 3, new DateTime(2024, 2, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, 4, new DateTime(2024, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, 5, new DateTime(2024, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 5, new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, 6, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 6, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, 7, new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, 8, new DateTime(2024, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 7, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, 9, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 8, new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, 10, new DateTime(2024, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 3, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, 2, new DateTime(2024, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 4, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveSettings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Leaves",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LeaveSettings");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Leaves");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Departments");
        }
    }
}
