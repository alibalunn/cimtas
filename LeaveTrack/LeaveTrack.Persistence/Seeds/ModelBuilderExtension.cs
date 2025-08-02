
using LeaveTrack.Domain.Common.Enums;
using LeaveTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaveTrack.Persistence.Seeds
{
    public static class ModelBuilderExtension
    {
        public static void SeedDepartments(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Üretim", Description = "Üretim Hattı" },
                new Department { Id = 2, Name = "Ar-Ge", Description = "Araştırma ve Geliştirme" },
                new Department { Id = 3, Name = "Kalite", Description = "Kalite Kontrol" },
                new Department { Id = 4, Name = "İnsan Kaynakları", Description = "Personel ve süreç yönetimi" },
                new Department { Id = 5, Name = "Bakım", Description = "Makine ve sistem bakımı" },
                new Department { Id = 6, Name = "Bilgi İşlem", Description = "IT Departmanı" },
                new Department { Id = 7, Name = "Satın Alma", Description = "Malzeme ve hizmet tedariki" },
                new Department { Id = 8, Name = "Finans", Description = "Finansal işlemler" },
                new Department { Id = 9, Name = "Satış", Description = "Müşteri ilişkileri" },
                new Department { Id = 10, Name = "Lojistik", Description = "Depolama ve taşıma" }
            );
        }

        public static void SeedEmployees(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FullName = "Ali Balun", Username = "admin_admin", PasswordHash = "adminpass1", Role = Role.Admin, DepartmentId = 1, IsSystemUser = true },
                new Employee { Id = 2, FullName = "Ayşe Yılmaz", Username = "user_user", PasswordHash = "userpass1", Role = Role.User, DepartmentId = 2, IsSystemUser = true, AnnualLeaveLimit = 15 },
                new Employee { Id = 3, FullName = "Mehmet Demir", Username = "mehmet.demir", PasswordHash = "hashedpw3", Role = Role.User, DepartmentId = 3, IsSystemUser = false, AnnualLeaveLimit = 18 },
                new Employee { Id = 4, FullName = "Zeynep Kaya", Username = "zeynep.kaya", PasswordHash = "hashedpw4", Role = Role.User, DepartmentId = 4, IsSystemUser = false, AnnualLeaveLimit = 14 },
                new Employee { Id = 5, FullName = "Emre Can", Username = "emre.can", PasswordHash = "hashedpw5", Role = Role.User, DepartmentId = 5, IsSystemUser = false, AnnualLeaveLimit = 20 },
                new Employee { Id = 6, FullName = "Burcu Aydın", Username = "burcu.aydin", PasswordHash = "hashedpw6", Role = Role.User, DepartmentId = 6, IsSystemUser = false },
                new Employee { Id = 7, FullName = "Deniz Yıldız", Username = "deniz.yildiz", PasswordHash = "hashedpw7", Role = Role.User, DepartmentId = 7, IsSystemUser = false, AnnualLeaveLimit = 22 },
                new Employee { Id = 8, FullName = "Kerem Öz", Username = "kerem.oz", PasswordHash = "hashedpw8", Role = Role.User, DepartmentId = 8, IsSystemUser = false },
                new Employee { Id = 9, FullName = "İlayda Çetin", Username = "ilayda.cetin", PasswordHash = "hashedpw9", Role = Role.User, DepartmentId = 9, IsSystemUser = false, AnnualLeaveLimit = 16 },
                new Employee { Id = 10, FullName = "Onur Güneş", Username = "onur.gunes", PasswordHash = "hashedpw10", Role = Role.User, DepartmentId = 10, IsSystemUser = false }
            );
        }

        public static void SeedLeaveTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveType>().HasData(
                new LeaveType { Id = 1, Name = "Yıllık İzin", Description = "Yıllık izin hakkı" },
                new LeaveType { Id = 2, Name = "Hastalık İzni", Description = "Sağlık nedeniyle izin" },
                new LeaveType { Id = 3, Name = "Doğum İzni", Description = "Doğum yapan çalışanlar için izin" },
                new LeaveType { Id = 4, Name = "Ücretsiz İzin", Description = "Maaşsız izin" },
                new LeaveType { Id = 5, Name = "Evlilik İzni", Description = "Evlilik nedeniyle verilen izin" },
                new LeaveType { Id = 6, Name = "Cenaze İzni", Description = "Yakın kaybı sonrası izin" },
                new LeaveType { Id = 7, Name = "Görev İzni", Description = "Görev nedeniyle verilen izin" },
                new LeaveType { Id = 8, Name = "Yarım Gün İzin", Description = "Yarım günlük izin" }
            );
        }

        public static void SeedLeaveSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveSettings>().HasData(
                new LeaveSettings { Id = 1, AnnualLeaveLimit = 20 }
            );
        }

        public static void SeedLeaves(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leave>().HasData(
                new Leave { Id = 1, StartDate = new DateTime(2025, 1, 10), EndDate = new DateTime(2025, 1, 13), EmployeeId = 2, LeaveTypeId = 1, CreatedByUserId = 1 },
                new Leave { Id = 2, StartDate = new DateTime(2025, 2, 5), EndDate = new DateTime(2025, 2, 7), EmployeeId = 3, LeaveTypeId = 2, CreatedByUserId = 1 },
                new Leave { Id = 3, StartDate = new DateTime(2025, 3, 15), EndDate = new DateTime(2025, 3, 16), EmployeeId = 4, LeaveTypeId = 4, CreatedByUserId = 1 },
                new Leave { Id = 4, StartDate = new DateTime(2025, 4, 20), EndDate = new DateTime(2025, 4, 22), EmployeeId = 5, LeaveTypeId = 5, CreatedByUserId = 1 },
                new Leave { Id = 5, StartDate = new DateTime(2025, 5, 10), EndDate = new DateTime(2025, 5, 12), EmployeeId = 6, LeaveTypeId = 6, CreatedByUserId = 1 },
                new Leave { Id = 6, StartDate = new DateTime(2025, 6, 5), EndDate = new DateTime(2025, 6, 8), EmployeeId = 7, LeaveTypeId = 1, CreatedByUserId = 1 },
                new Leave { Id = 7, StartDate = new DateTime(2025, 7, 1), EndDate = new DateTime(2025, 7, 2), EmployeeId = 8, LeaveTypeId = 7, CreatedByUserId = 1 },
                new Leave { Id = 8, StartDate = new DateTime(2025, 7, 20), EndDate = new DateTime(2025, 7, 20), EmployeeId = 9, LeaveTypeId = 8, CreatedByUserId = 1 },
                new Leave { Id = 9, StartDate = new DateTime(2025, 8, 5), EndDate = new DateTime(2025, 8, 7), EmployeeId = 10, LeaveTypeId = 3, CreatedByUserId = 1 },
                new Leave { Id = 10, StartDate = new DateTime(2025, 9, 10), EndDate = new DateTime(2025, 9, 12), EmployeeId = 2, LeaveTypeId = 4, CreatedByUserId = 1 },
                new Leave { Id = 11, StartDate = new DateTime(2025, 1, 25), EndDate = new DateTime(2025, 1, 27), EmployeeId = 3, LeaveTypeId = 1, CreatedByUserId = 1 },
                new Leave { Id = 12, StartDate = new DateTime(2025, 2, 10), EndDate = new DateTime(2025, 2, 12), EmployeeId = 4, LeaveTypeId = 5, CreatedByUserId = 1 },
                new Leave { Id = 13, StartDate = new DateTime(2025, 2, 20), EndDate = new DateTime(2025, 2, 20), EmployeeId = 5, LeaveTypeId = 8, CreatedByUserId = 1 },
                new Leave { Id = 14, StartDate = new DateTime(2025, 3, 5), EndDate = new DateTime(2025, 3, 8), EmployeeId = 6, LeaveTypeId = 2, CreatedByUserId = 1 },
                new Leave { Id = 15, StartDate = new DateTime(2025, 3, 15), EndDate = new DateTime(2025, 3, 17), EmployeeId = 7, LeaveTypeId = 4, CreatedByUserId = 1 },
                new Leave { Id = 16, StartDate = new DateTime(2025, 4, 1), EndDate = new DateTime(2025, 4, 3), EmployeeId = 8, LeaveTypeId = 1, CreatedByUserId = 1 },
                new Leave { Id = 17, StartDate = new DateTime(2025, 4, 15), EndDate = new DateTime(2025, 4, 18), EmployeeId = 9, LeaveTypeId = 6, CreatedByUserId = 1 },
                new Leave { Id = 18, StartDate = new DateTime(2025, 5, 5), EndDate = new DateTime(2025, 5, 6), EmployeeId = 10, LeaveTypeId = 7, CreatedByUserId = 1 },
                new Leave { Id = 19, StartDate = new DateTime(2025, 5, 15), EndDate = new DateTime(2025, 5, 19), EmployeeId = 1, LeaveTypeId = 3, CreatedByUserId = 1 },
                new Leave { Id = 20, StartDate = new DateTime(2025, 6, 10), EndDate = new DateTime(2025, 6, 12), EmployeeId = 2, LeaveTypeId = 4, CreatedByUserId = 1 },
                new Leave { Id = 21, StartDate = new DateTime(2025, 6, 20), EndDate = new DateTime(2025, 6, 21), EmployeeId = 3, LeaveTypeId = 8, CreatedByUserId = 1 },
                new Leave { Id = 22, StartDate = new DateTime(2025, 7, 10), EndDate = new DateTime(2025, 7, 12), EmployeeId = 4, LeaveTypeId = 5, CreatedByUserId = 1 },
                new Leave { Id = 23, StartDate = new DateTime(2025, 7, 20), EndDate = new DateTime(2025, 7, 22), EmployeeId = 5, LeaveTypeId = 1, CreatedByUserId = 1 },
                new Leave { Id = 24, StartDate = new DateTime(2025, 8, 1), EndDate = new DateTime(2025, 8, 3), EmployeeId = 6, LeaveTypeId = 2, CreatedByUserId = 1 },
                new Leave { Id = 25, StartDate = new DateTime(2025, 8, 15), EndDate = new DateTime(2025, 8, 17), EmployeeId = 7, LeaveTypeId = 6, CreatedByUserId = 1 },
                new Leave { Id = 26, StartDate = new DateTime(2025, 9, 5), EndDate = new DateTime(2025, 9, 6), EmployeeId = 8, LeaveTypeId = 7, CreatedByUserId = 1 },
                new Leave { Id = 27, StartDate = new DateTime(2025, 9, 15), EndDate = new DateTime(2025, 9, 20), EmployeeId = 9, LeaveTypeId = 3, CreatedByUserId = 1 },
                new Leave { Id = 28, StartDate = new DateTime(2025, 10, 1), EndDate = new DateTime(2025, 10, 3), EmployeeId = 10, LeaveTypeId = 4, CreatedByUserId = 1 },
                new Leave { Id = 29, StartDate = new DateTime(2025, 10, 10), EndDate = new DateTime(2025, 10, 12), EmployeeId = 1, LeaveTypeId = 5, CreatedByUserId = 1 },
                new Leave { Id = 30, StartDate = new DateTime(2025, 10, 20), EndDate = new DateTime(2025, 10, 22), EmployeeId = 2, LeaveTypeId = 1, CreatedByUserId = 1 }
            );
        }



        public static void ApplyAllSeeds(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDepartments();
            modelBuilder.SeedEmployees();
            modelBuilder.SeedLeaveTypes();
            modelBuilder.SeedLeaveSettings();
            modelBuilder.SeedLeaves();
        }
    }
}
