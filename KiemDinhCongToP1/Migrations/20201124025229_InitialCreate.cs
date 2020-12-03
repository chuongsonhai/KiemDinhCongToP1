using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KiemDinhCongToP1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DM_Chis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_Chi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai_Chi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Chis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DM_DayChis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_DayChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai_DayChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_DayChis", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DM_Tems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma_Tem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai_Tem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DM_Tems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TaiKhoans",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDayDu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenDangNhap = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKDV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CMIS_User_ID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaQuanLy = table.Column<int>(type: "int", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaiKhoans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SLT_Chis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Chi_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongChi = table.Column<int>(type: "int", nullable: true),
                    SoLuongChi_Huy = table.Column<int>(type: "int", nullable: true),
                    SoLuongChi_Ton = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLT_Chis", x => x.id);
                    table.ForeignKey(
                        name: "FK_SLT_Chis_DM_Chis_Chi_ID",
                        column: x => x.Chi_ID,
                        principalTable: "DM_Chis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLT_DayChis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Daychi_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongDayChi = table.Column<int>(type: "int", nullable: true),
                    SoLuongDayChi_Huy = table.Column<int>(type: "int", nullable: true),
                    SoLuongDayChi_Ton = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLT_DayChis", x => x.id);
                    table.ForeignKey(
                        name: "FK_SLT_DayChis_DM_DayChis_Daychi_ID",
                        column: x => x.Daychi_ID,
                        principalTable: "DM_DayChis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLT_Tems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Tem_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongTem = table.Column<int>(type: "int", nullable: true),
                    SoLuongTem_Huy = table.Column<int>(type: "int", nullable: true),
                    SoLuongTem_Ton = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLT_Tems", x => x.id);
                    table.ForeignKey(
                        name: "FK_SLT_Tems_DM_Tems_Tem_ID",
                        column: x => x.Tem_ID,
                        principalTable: "DM_Tems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DangKy_TemChis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_NguoiDKy = table.Column<long>(type: "bigint", nullable: true),
                    nam = table.Column<int>(type: "int", nullable: true),
                    Ten_DKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong_Dky = table.Column<int>(type: "int", nullable: true),
                    Id_NguoiDuyet = table.Column<long>(type: "bigint", nullable: true),
                    TrangThaiDuyet = table.Column<int>(type: "int", nullable: true),
                    CapDuyet = table.Column<int>(type: "int", nullable: true),
                    ThoiGianDuyet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKy_TemChis", x => x.id);
                    table.ForeignKey(
                        name: "FK_DangKy_TemChis_TaiKhoans_Id_NguoiDuyet",
                        column: x => x.Id_NguoiDuyet,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KDV_Chis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Su_Dung = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    Chi_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongChi = table.Column<int>(type: "int", nullable: true),
                    SoLuongChi_Huy = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDV_Chis", x => x.id);
                    table.ForeignKey(
                        name: "FK_KDV_Chis_DM_Chis_Chi_ID",
                        column: x => x.Chi_ID,
                        principalTable: "DM_Chis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KDV_Chis_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KDV_DayChis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Su_Dung = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Daychi_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongDayChi = table.Column<int>(type: "int", nullable: true),
                    SoLuongDayChi_Huy = table.Column<int>(type: "int", nullable: true),
                    LoaiDayChi_Huy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong_Huy = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDV_DayChis", x => x.id);
                    table.ForeignKey(
                        name: "FK_KDV_DayChis_DM_DayChis_Daychi_ID",
                        column: x => x.Daychi_ID,
                        principalTable: "DM_DayChis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KDV_DayChis_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KDV_Tems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Su_Dung = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    Tem_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuongTem = table.Column<int>(type: "int", nullable: true),
                    SoLuongTem_Huy = table.Column<int>(type: "int", nullable: true),
                    Seri_Dau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seri_Cuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLuong_Huy = table.Column<int>(type: "int", nullable: true),
                    Seri_Tem_Huy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KDV_Tems", x => x.id);
                    table.ForeignKey(
                        name: "FK_KDV_Tems_DM_Tems_Tem_ID",
                        column: x => x.Tem_ID,
                        principalTable: "DM_Tems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KDV_Tems_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NQL_Chis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    Chi_ID = table.Column<long>(type: "bigint", nullable: true),
                    NQL_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NQL_Chis", x => x.id);
                    table.ForeignKey(
                        name: "FK_NQL_Chis_DM_Chis_Chi_ID",
                        column: x => x.Chi_ID,
                        principalTable: "DM_Chis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NQL_Chis_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NQL_DayChis",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    Daychi_ID = table.Column<long>(type: "bigint", nullable: true),
                    NQL_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NQL_DayChis", x => x.id);
                    table.ForeignKey(
                        name: "FK_NQL_DayChis_DM_DayChis_Daychi_ID",
                        column: x => x.Daychi_ID,
                        principalTable: "DM_DayChis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NQL_DayChis_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NQL_Tems",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay_Cap_Phat = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    Tem_ID = table.Column<long>(type: "bigint", nullable: true),
                    NQL_ID = table.Column<long>(type: "bigint", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    Seri_Dau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seri_Cuoi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NguoiCapNhat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TGian_CapNhat = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NQL_Tems", x => x.id);
                    table.ForeignKey(
                        name: "FK_NQL_Tems_DM_Tems_Tem_ID",
                        column: x => x.Tem_ID,
                        principalTable: "DM_Tems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NQL_Tems_TaiKhoans_KDV_ID",
                        column: x => x.KDV_ID,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QL_CaiDat_CTDienTus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DienLuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaCongTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngay_Cai = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    KDV_ID = table.Column<long>(type: "bigint", nullable: true),
                    NguoiCai = table.Column<long>(type: "bigint", nullable: true),
                    TaiKhoansid = table.Column<long>(type: "bigint", nullable: true),
                    SoTem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaKim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoLanCai = table.Column<int>(type: "int", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QL_CaiDat_CTDienTus", x => x.id);
                    table.ForeignKey(
                        name: "FK_QL_CaiDat_CTDienTus_TaiKhoans_NguoiCai",
                        column: x => x.NguoiCai,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QL_CaiDat_CTDienTus_TaiKhoans_TaiKhoansid",
                        column: x => x.TaiKhoansid,
                        principalTable: "TaiKhoans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKy_TemChis_Id_NguoiDuyet",
                table: "DangKy_TemChis",
                column: "Id_NguoiDuyet");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_Chis_Chi_ID",
                table: "KDV_Chis",
                column: "Chi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_Chis_KDV_ID",
                table: "KDV_Chis",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_DayChis_Daychi_ID",
                table: "KDV_DayChis",
                column: "Daychi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_DayChis_KDV_ID",
                table: "KDV_DayChis",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_Tems_KDV_ID",
                table: "KDV_Tems",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_KDV_Tems_Tem_ID",
                table: "KDV_Tems",
                column: "Tem_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_Chis_Chi_ID",
                table: "NQL_Chis",
                column: "Chi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_Chis_KDV_ID",
                table: "NQL_Chis",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_DayChis_Daychi_ID",
                table: "NQL_DayChis",
                column: "Daychi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_DayChis_KDV_ID",
                table: "NQL_DayChis",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_Tems_KDV_ID",
                table: "NQL_Tems",
                column: "KDV_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NQL_Tems_Tem_ID",
                table: "NQL_Tems",
                column: "Tem_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QL_CaiDat_CTDienTus_NguoiCai",
                table: "QL_CaiDat_CTDienTus",
                column: "NguoiCai");

            migrationBuilder.CreateIndex(
                name: "IX_QL_CaiDat_CTDienTus_TaiKhoansid",
                table: "QL_CaiDat_CTDienTus",
                column: "TaiKhoansid");

            migrationBuilder.CreateIndex(
                name: "IX_SLT_Chis_Chi_ID",
                table: "SLT_Chis",
                column: "Chi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLT_DayChis_Daychi_ID",
                table: "SLT_DayChis",
                column: "Daychi_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SLT_Tems_Tem_ID",
                table: "SLT_Tems",
                column: "Tem_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKy_TemChis");

            migrationBuilder.DropTable(
                name: "KDV_Chis");

            migrationBuilder.DropTable(
                name: "KDV_DayChis");

            migrationBuilder.DropTable(
                name: "KDV_Tems");

            migrationBuilder.DropTable(
                name: "NQL_Chis");

            migrationBuilder.DropTable(
                name: "NQL_DayChis");

            migrationBuilder.DropTable(
                name: "NQL_Tems");

            migrationBuilder.DropTable(
                name: "QL_CaiDat_CTDienTus");

            migrationBuilder.DropTable(
                name: "SLT_Chis");

            migrationBuilder.DropTable(
                name: "SLT_DayChis");

            migrationBuilder.DropTable(
                name: "SLT_Tems");

            migrationBuilder.DropTable(
                name: "TaiKhoans");

            migrationBuilder.DropTable(
                name: "DM_Chis");

            migrationBuilder.DropTable(
                name: "DM_DayChis");

            migrationBuilder.DropTable(
                name: "DM_Tems");
        }
    }
}
