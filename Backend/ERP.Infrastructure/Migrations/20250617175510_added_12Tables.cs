using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class added_12Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHACHHANG",
                columns: table => new
                {
                    MaKH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhachHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    TichDiem = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHACHHANG", x => x.MaKH);
                });

            migrationBuilder.CreateTable(
                name: "KHOHANG",
                columns: table => new
                {
                    MaKho = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKho = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    NguoiQuanLy = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KHOHANG", x => x.MaKho);
                });

            migrationBuilder.CreateTable(
                name: "PHANLOAIMATHANG",
                columns: table => new
                {
                    MaMatHang = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMatHang = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TongChiPhi = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANLOAIMATHANG", x => x.MaMatHang);
                });

            migrationBuilder.CreateTable(
                name: "HOADON",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    LoaiHD = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime", nullable: false),
                    NguoiLap = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TongTien = table.Column<long>(type: "bigint", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HOADON", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HOADON_KHACHHANG_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KHACHHANG",
                        principalColumn: "MaKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHAPKHO",
                columns: table => new
                {
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNCC = table.Column<int>(type: "int", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "date", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHAPKHO", x => x.MaPhieuNhap);
                    table.ForeignKey(
                        name: "FK_NHAPKHO_KHOHANG_MaKho",
                        column: x => x.MaKho,
                        principalTable: "KHOHANG",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHAPKHO_NhaCungCap_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "XUATKHO",
                columns: table => new
                {
                    MaPhieuXuat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    NguoiXuat = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NgayXuat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LyDoXuat = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XUATKHO", x => x.MaPhieuXuat);
                    table.ForeignKey(
                        name: "FK_XUATKHO_KHOHANG_MaKho",
                        column: x => x.MaKho,
                        principalTable: "KHOHANG",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SANPHAM",
                columns: table => new
                {
                    MaSP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaNCC = table.Column<int>(type: "int", nullable: false),
                    MaMatHang = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<long>(type: "bigint", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SANPHAM", x => x.MaSP);
                    table.ForeignKey(
                        name: "FK_SANPHAM_NhaCungCap_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCungCap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SANPHAM_PHANLOAIMATHANG_MaMatHang",
                        column: x => x.MaMatHang,
                        principalTable: "PHANLOAIMATHANG",
                        principalColumn: "MaMatHang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETHOADON",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<long>(type: "bigint", nullable: false),
                    ChietKhau = table.Column<float>(type: "real", nullable: false, defaultValue: 0f),
                    VAT = table.Column<float>(type: "real", nullable: false, defaultValue: 0.1f),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETHOADON", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHITIETHOADON_HOADON_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HOADON",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETHOADON_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETNHAPKHO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuNhap = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETNHAPKHO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHITIETNHAPKHO_NHAPKHO_MaPhieuNhap",
                        column: x => x.MaPhieuNhap,
                        principalTable: "NHAPKHO",
                        principalColumn: "MaPhieuNhap",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETNHAPKHO_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHITIETXUATKHO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuXuat = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    SoLuongXuat = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHITIETXUATKHO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CHITIETXUATKHO_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CHITIETXUATKHO_XUATKHO_MaPhieuXuat",
                        column: x => x.MaPhieuXuat,
                        principalTable: "XUATKHO",
                        principalColumn: "MaPhieuXuat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TONKHO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSP = table.Column<int>(type: "int", nullable: false),
                    TenSP = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MaKho = table.Column<int>(type: "int", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false),
                    NgayCapNhat = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TONKHO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TONKHO_KHOHANG_MaKho",
                        column: x => x.MaKho,
                        principalTable: "KHOHANG",
                        principalColumn: "MaKho",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TONKHO_SANPHAM_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SANPHAM",
                        principalColumn: "MaSP",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_MaHD",
                table: "CHITIETHOADON",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETHOADON_MaSP",
                table: "CHITIETHOADON",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETNHAPKHO_MaPhieuNhap",
                table: "CHITIETNHAPKHO",
                column: "MaPhieuNhap");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETNHAPKHO_MaSP",
                table: "CHITIETNHAPKHO",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETXUATKHO_MaPhieuXuat",
                table: "CHITIETXUATKHO",
                column: "MaPhieuXuat");

            migrationBuilder.CreateIndex(
                name: "IX_CHITIETXUATKHO_MaSP",
                table: "CHITIETXUATKHO",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HOADON_MaKH",
                table: "HOADON",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPKHO_MaKho",
                table: "NHAPKHO",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPKHO_MaNCC",
                table: "NHAPKHO",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaMatHang",
                table: "SANPHAM",
                column: "MaMatHang");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaNCC",
                table: "SANPHAM",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_TONKHO_MaKho",
                table: "TONKHO",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_TONKHO_MaSP",
                table: "TONKHO",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_XUATKHO_MaKho",
                table: "XUATKHO",
                column: "MaKho");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHITIETHOADON");

            migrationBuilder.DropTable(
                name: "CHITIETNHAPKHO");

            migrationBuilder.DropTable(
                name: "CHITIETXUATKHO");

            migrationBuilder.DropTable(
                name: "TONKHO");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "NHAPKHO");

            migrationBuilder.DropTable(
                name: "XUATKHO");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "KHOHANG");

            migrationBuilder.DropTable(
                name: "PHANLOAIMATHANG");
        }
    }
}
