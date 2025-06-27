using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BOPHAN",
                columns: table => new
                {
                    MaBoPhan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBoPhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BOPHAN", x => x.MaBoPhan);
                });

            migrationBuilder.CreateTable(
                name: "CHUCVU",
                columns: table => new
                {
                    MaChucVu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenChucVu = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHUCVU", x => x.MaChucVu);
                });

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
                name: "LOAICA",
                columns: table => new
                {
                    MaLoaiCa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaLamViec = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HeSoTangCa = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAICA", x => x.MaLoaiCa);
                });

            migrationBuilder.CreateTable(
                name: "LOAICONG",
                columns: table => new
                {
                    MaLoaiCong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiCong = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HeSo = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOAICONG", x => x.MaLoaiCong);
                });

            migrationBuilder.CreateTable(
                name: "NHACUNGCAP",
                columns: table => new
                {
                    MaNCC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(10)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    NguoiTiepNhan = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHACUNGCAP", x => x.MaNCC);
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
                name: "PHONGBAN",
                columns: table => new
                {
                    MaPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhongBan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHONGBAN", x => x.MaPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "PHUCAP",
                columns: table => new
                {
                    MaPC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenPhuCap = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHUCAP", x => x.MaPC);
                });

            migrationBuilder.CreateTable(
                name: "QUYEN",
                columns: table => new
                {
                    MaQuyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuyen = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUYEN", x => x.MaQuyen);
                });

            migrationBuilder.CreateTable(
                name: "TRINHDOHOCVAN",
                columns: table => new
                {
                    MaTDHV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrinhDoHocVan = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRINHDOHOCVAN", x => x.MaTDHV);
                });

            migrationBuilder.CreateTable(
                name: "VAITRO",
                columns: table => new
                {
                    MaVaiTro = table.Column<string>(type: "varchar(10)", nullable: false),
                    TenVaiTro = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAITRO", x => x.MaVaiTro);
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
                        name: "FK_NHAPKHO_NHACUNGCAP_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "MaNCC",
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
                        name: "FK_SANPHAM_NHACUNGCAP_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NHACUNGCAP",
                        principalColumn: "MaNCC",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SANPHAM_PHANLOAIMATHANG_MaMatHang",
                        column: x => x.MaMatHang,
                        principalTable: "PHANLOAIMATHANG",
                        principalColumn: "MaMatHang",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NHANSU",
                columns: table => new
                {
                    MaNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: false),
                    GioiTinh = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "varchar(15)", nullable: false),
                    CCCD = table.Column<string>(type: "varchar(12)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    MaPhongBan = table.Column<int>(type: "int", nullable: false),
                    MaBoPhan = table.Column<int>(type: "int", nullable: false),
                    MaChucVu = table.Column<int>(type: "int", nullable: false),
                    MaTDHV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NHANSU", x => x.MaNV);
                    table.ForeignKey(
                        name: "FK_NHANSU_BOPHAN_MaBoPhan",
                        column: x => x.MaBoPhan,
                        principalTable: "BOPHAN",
                        principalColumn: "MaBoPhan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHANSU_CHUCVU_MaChucVu",
                        column: x => x.MaChucVu,
                        principalTable: "CHUCVU",
                        principalColumn: "MaChucVu",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHANSU_PHONGBAN_MaPhongBan",
                        column: x => x.MaPhongBan,
                        principalTable: "PHONGBAN",
                        principalColumn: "MaPhongBan",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NHANSU_TRINHDOHOCVAN_MaTDHV",
                        column: x => x.MaTDHV,
                        principalTable: "TRINHDOHOCVAN",
                        principalColumn: "MaTDHV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NGUOIDUNG",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDangNhap = table.Column<string>(type: "varchar(50)", nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(50)", nullable: false),
                    MaVaiTro = table.Column<string>(type: "varchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NGUOIDUNG", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NGUOIDUNG_VAITRO_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VAITRO",
                        principalColumn: "MaVaiTro",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHANQUYEN",
                columns: table => new
                {
                    MaVaiTro = table.Column<string>(type: "varchar(10)", nullable: false),
                    MaQuyen = table.Column<int>(type: "int", nullable: false),
                    HanhDong = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHANQUYEN", x => new { x.MaVaiTro, x.MaQuyen });
                    table.ForeignKey(
                        name: "FK_PHANQUYEN_QUYEN_MaQuyen",
                        column: x => x.MaQuyen,
                        principalTable: "QUYEN",
                        principalColumn: "MaQuyen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHANQUYEN_VAITRO_MaVaiTro",
                        column: x => x.MaVaiTro,
                        principalTable: "VAITRO",
                        principalColumn: "MaVaiTro",
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

            migrationBuilder.CreateTable(
                name: "BAOHIEM",
                columns: table => new
                {
                    MaBH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    LoaiBH = table.Column<string>(type: "varchar(10)", nullable: false),
                    SoBH = table.Column<string>(type: "varchar(20)", nullable: false),
                    BenhVien = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "date", nullable: false),
                    TinhTrang = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAOHIEM", x => x.MaBH);
                    table.ForeignKey(
                        name: "FK_BAOHIEM_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHI",
                columns: table => new
                {
                    MaChi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    NgayChi = table.Column<DateTime>(type: "date", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NguoiChi = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHI", x => x.MaChi);
                    table.ForeignKey(
                        name: "FK_CHI_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LUONG",
                columns: table => new
                {
                    MaLuong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    LuongCoBan = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongTC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TongPC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThucLinh = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[LuongCoBan] + [TongTC] + [TongPC]", stored: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LUONG", x => x.MaLuong);
                    table.ForeignKey(
                        name: "FK_LUONG_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PHUCAPNV",
                columns: table => new
                {
                    MaPhuCapNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    MaPC = table.Column<int>(type: "int", nullable: false),
                    Thang = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<int>(type: "int", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PHUCAPNV", x => x.MaPhuCapNV);
                    table.ForeignKey(
                        name: "FK_PHUCAPNV_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PHUCAPNV_PHUCAP_MaPC",
                        column: x => x.MaPC,
                        principalTable: "PHUCAP",
                        principalColumn: "MaPC",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TANGCA",
                columns: table => new
                {
                    MaTangCa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "date", nullable: false),
                    SoGio = table.Column<int>(type: "int", nullable: false),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    MaLoaiCa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TANGCA", x => x.MaTangCa);
                    table.ForeignKey(
                        name: "FK_TANGCA_LOAICA_MaLoaiCa",
                        column: x => x.MaLoaiCa,
                        principalTable: "LOAICA",
                        principalColumn: "MaLoaiCa",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TANGCA_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "THU",
                columns: table => new
                {
                    MaThu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNV = table.Column<int>(type: "int", nullable: false),
                    NgayThu = table.Column<DateTime>(type: "date", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NguoiThu = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_THU", x => x.MaThu);
                    table.ForeignKey(
                        name: "FK_THU_NHANSU_MaNV",
                        column: x => x.MaNV,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TINHCONG",
                columns: table => new
                {
                    MaTinhCong = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngay = table.Column<DateTime>(type: "datetime", nullable: false),
                    GioVao = table.Column<TimeSpan>(type: "time", nullable: false),
                    GioRa = table.Column<TimeSpan>(type: "time", nullable: false),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    MaLoaiCong = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TINHCONG", x => x.MaTinhCong);
                    table.ForeignKey(
                        name: "FK_TINHCONG_LOAICONG_MaLoaiCong",
                        column: x => x.MaLoaiCong,
                        principalTable: "LOAICONG",
                        principalColumn: "MaLoaiCong",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TINHCONG_NHANSU_MaNhanVien",
                        column: x => x.MaNhanVien,
                        principalTable: "NHANSU",
                        principalColumn: "MaNV",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAOHIEM_MaNV",
                table: "BAOHIEM",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_CHI_MaNV",
                table: "CHI",
                column: "MaNV");

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
                name: "IX_LUONG_MaNV",
                table: "LUONG",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_MatKhau",
                table: "NGUOIDUNG",
                column: "MatKhau",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_MaVaiTro",
                table: "NGUOIDUNG",
                column: "MaVaiTro");

            migrationBuilder.CreateIndex(
                name: "IX_NGUOIDUNG_TenDangNhap",
                table: "NGUOIDUNG",
                column: "TenDangNhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NHANSU_MaBoPhan",
                table: "NHANSU",
                column: "MaBoPhan");

            migrationBuilder.CreateIndex(
                name: "IX_NHANSU_MaChucVu",
                table: "NHANSU",
                column: "MaChucVu");

            migrationBuilder.CreateIndex(
                name: "IX_NHANSU_MaPhongBan",
                table: "NHANSU",
                column: "MaPhongBan");

            migrationBuilder.CreateIndex(
                name: "IX_NHANSU_MaTDHV",
                table: "NHANSU",
                column: "MaTDHV");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPKHO_MaKho",
                table: "NHAPKHO",
                column: "MaKho");

            migrationBuilder.CreateIndex(
                name: "IX_NHAPKHO_MaNCC",
                table: "NHAPKHO",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_PHANQUYEN_MaQuyen",
                table: "PHANQUYEN",
                column: "MaQuyen");

            migrationBuilder.CreateIndex(
                name: "IX_PHUCAPNV_MaNV",
                table: "PHUCAPNV",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_PHUCAPNV_MaPC",
                table: "PHUCAPNV",
                column: "MaPC");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaMatHang",
                table: "SANPHAM",
                column: "MaMatHang");

            migrationBuilder.CreateIndex(
                name: "IX_SANPHAM_MaNCC",
                table: "SANPHAM",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_TANGCA_MaLoaiCa",
                table: "TANGCA",
                column: "MaLoaiCa");

            migrationBuilder.CreateIndex(
                name: "IX_TANGCA_MaNV",
                table: "TANGCA",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_THU_MaNV",
                table: "THU",
                column: "MaNV");

            migrationBuilder.CreateIndex(
                name: "IX_TINHCONG_MaLoaiCong",
                table: "TINHCONG",
                column: "MaLoaiCong");

            migrationBuilder.CreateIndex(
                name: "IX_TINHCONG_MaNhanVien",
                table: "TINHCONG",
                column: "MaNhanVien");

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
                name: "BAOHIEM");

            migrationBuilder.DropTable(
                name: "CHI");

            migrationBuilder.DropTable(
                name: "CHITIETHOADON");

            migrationBuilder.DropTable(
                name: "CHITIETNHAPKHO");

            migrationBuilder.DropTable(
                name: "CHITIETXUATKHO");

            migrationBuilder.DropTable(
                name: "LUONG");

            migrationBuilder.DropTable(
                name: "NGUOIDUNG");

            migrationBuilder.DropTable(
                name: "PHANQUYEN");

            migrationBuilder.DropTable(
                name: "PHUCAPNV");

            migrationBuilder.DropTable(
                name: "TANGCA");

            migrationBuilder.DropTable(
                name: "THU");

            migrationBuilder.DropTable(
                name: "TINHCONG");

            migrationBuilder.DropTable(
                name: "TONKHO");

            migrationBuilder.DropTable(
                name: "HOADON");

            migrationBuilder.DropTable(
                name: "NHAPKHO");

            migrationBuilder.DropTable(
                name: "XUATKHO");

            migrationBuilder.DropTable(
                name: "QUYEN");

            migrationBuilder.DropTable(
                name: "VAITRO");

            migrationBuilder.DropTable(
                name: "PHUCAP");

            migrationBuilder.DropTable(
                name: "LOAICA");

            migrationBuilder.DropTable(
                name: "LOAICONG");

            migrationBuilder.DropTable(
                name: "NHANSU");

            migrationBuilder.DropTable(
                name: "SANPHAM");

            migrationBuilder.DropTable(
                name: "KHACHHANG");

            migrationBuilder.DropTable(
                name: "KHOHANG");

            migrationBuilder.DropTable(
                name: "BOPHAN");

            migrationBuilder.DropTable(
                name: "CHUCVU");

            migrationBuilder.DropTable(
                name: "PHONGBAN");

            migrationBuilder.DropTable(
                name: "TRINHDOHOCVAN");

            migrationBuilder.DropTable(
                name: "NHACUNGCAP");

            migrationBuilder.DropTable(
                name: "PHANLOAIMATHANG");
        }
    }
}
