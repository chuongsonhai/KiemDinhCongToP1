using EntityFramework.Tem_Chi;
using Microsoft.EntityFrameworkCore;
using System;

namespace EntityFramework
{
    public class DBconnect : DbContext
    {
        public DbSet<DM_Chi> DM_Chis { get; set; }
        public DbSet<DM_DayChi> DM_DayChis { get; set; }
        public DbSet<DM_Tem> DM_Tems { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<KDV_Chi> KDV_Chis { get; set; }
        public DbSet<KDV_DayChi> KDV_DayChis { get; set; }
        public DbSet<KDV_Tem> KDV_Tems { get; set; }
        public DbSet<NQL_Chi> NQL_Chis { get; set; }
        public DbSet<NQL_DayChi> NQL_DayChis { get; set; }
        public DbSet<NQL_Tem> NQL_Tems { get; set; }
        public DbSet<SLT_Chi> SLT_Chis { get; set; }
        public DbSet<SLT_DayChi> SLT_DayChis { get; set; }
        public DbSet<SLT_Tem> SLT_Tems { get; set; }
        public DbSet<QL_CaiDat_CTDienTu> QL_CaiDat_CTDienTus { get; set; }
        public DbSet<DangKy_TemChi> DangKy_TemChis { get; set; }
        public DBconnect(DbContextOptions<DBconnect> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<KDV_Chi>(e =>
            {
                e.HasOne(p => p.DM_Chi)
                    .WithMany(p => p.KDV_Chis)
                    .HasForeignKey(p => p.Chi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                     .WithMany(p => p.KDV_Chis)
                      .HasForeignKey(p => p.KDV_ID)
                      .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<KDV_DayChi>(e =>
            {
                e.HasOne(p => p.DM_DayChi)
                    .WithMany(p => p.KDV_DayChis)
                    .HasForeignKey(p => p.Daychi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                       .WithMany(p => p.KDV_DayChis)
                     .HasForeignKey(p => p.KDV_ID)
                      .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<KDV_Tem>(e =>
            {
                e.HasOne(p => p.DM_Tem)
                    .WithMany(p => p.KDV_Tems)
                    .HasForeignKey(p => p.Tem_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                     .WithMany(p => p.KDV_Tems)
                     .HasForeignKey(p => p.KDV_ID)
                     .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<NQL_Tem>(e =>
            {
                e.HasOne(p => p.DM_Tem)
                    .WithMany(p => p.NQL_Tems)
                    .HasForeignKey(p => p.Tem_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                     .WithMany(p => p.NQL_Tems)
                     .HasForeignKey(p => p.KDV_ID)
                     .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<NQL_DayChi>(e =>
            {
                e.HasOne(p => p.DM_DayChi)
                    .WithMany(p => p.NQL_DayChis)
                    .HasForeignKey(p => p.Daychi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                     .WithMany(p => p.NQL_DayChis)
                     .HasForeignKey(p => p.KDV_ID)
                     .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<NQL_Chi>(e =>
            {
                e.HasOne(p => p.DM_Chi)
                    .WithMany(p => p.NQL_Chis)
                    .HasForeignKey(p => p.Chi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                     .WithMany(p => p.NQL_Chis)
                     .HasForeignKey(p => p.KDV_ID)
                     .OnDelete(DeleteBehavior.Restrict);

            });
            modelBuilder.Entity<SLT_Chi>(e =>
            {
                e.HasOne(p => p.DM_Chi)
                    .WithMany(p => p.SLT_Chis)
                    .HasForeignKey(p => p.Chi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<SLT_DayChi>(e =>
            {
                e.HasOne(p => p.DM_DayChi)
                    .WithMany(p => p.SLT_DayChis)
                    .HasForeignKey(p => p.Daychi_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<SLT_Tem>(e =>
            {
                e.HasOne(p => p.DM_Tem)
                    .WithMany(p => p.SLT_Tems)
                    .HasForeignKey(p => p.Tem_ID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<QL_CaiDat_CTDienTu>(e =>
            {
                e.HasOne(p => p.TaiKhoan)
                    .WithMany(p => p.QL_CaiDat_CTDienTus)
                    .HasForeignKey(p => p.KDV_ID)
                    .HasForeignKey(p => p.NguoiCai)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<DangKy_TemChi>(e =>
            {
                e.HasOne(p => p.TaiKhoan)
                    .WithMany(p => p.DangKy_TemChis)
                    .HasForeignKey(p => p.id_NguoiDKy)
                    .OnDelete(DeleteBehavior.Restrict);
                e.HasOne(p => p.TaiKhoan)
                      .WithMany(p => p.DangKy_TemChis)
                     .HasForeignKey(p => p.Id_NguoiDuyet)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }

}
