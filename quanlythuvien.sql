USE [master]
GO

IF EXISTS (SELECT NAME FROM sys.databases WHERE NAME = N'quanlythuvien')
BEGIN
    ALTER DATABASE quanlythuvien SET SINGLE_USER WITH ROLLBACK IMMEDIATE
    DROP DATABASE quanlythuvien
END

CREATE DATABASE quanlythuvien
GO

USE quanlythuvien
GO

-- Set quyen cho database
ALTER AUTHORIZATION ON DATABASE::quanlythuvien TO [sa]

-------PHAN TAO BANG----------------------------------
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[maphieumuon] [varchar](25) NOT NULL,
	[masach] [varchar](25) NOT NULL,
	[tinhtrang] [bit] NULL,
	[ngaytrasach] [date] NULL,
	[tienphat] [bigint] NOT NULL,
	[manhanviennhansachtra] [varchar](25) NULL,
 CONSTRAINT [PK_ChiTietPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[maphieumuon] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocGia](
	[madocgia] [varchar](25) NOT NULL,
	[tendocgia] [nvarchar](100) NOT NULL,
	[ngaysinh] [date] NOT NULL,
	[gioitinh] [nvarchar](10) NOT NULL,
	[diachi] [nvarchar](100) NOT NULL,
	[lophoc] [nvarchar](50) NOT NULL,
	[ngaytaothe] [date] NOT NULL,
	[manhanvientaothe] [varchar](25) NOT NULL,
	[tendangnhap] [varchar](100) NOT NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[madocgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[tendangnhap] [varchar](100) NOT NULL,
	[matkhau] [varchar](100) NOT NULL,
	[loainguoidung] [varchar](10) NOT NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[tendangnhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[manhanvien] [varchar](25) NOT NULL,
	[tennhanvien] [nvarchar](50) NOT NULL,
	[ngaysinh] [date] NOT NULL,
	[gioitinh] [nvarchar](10) NOT NULL,
	[sodienthoai] [char](10) NOT NULL,
	[tendangnhap] [varchar](100) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaXuatBan]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaXuatBan](
	[manhaxuatban] [varchar](25) NOT NULL,
	[tennhaxuatban] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[manhaxuatban] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[maphieumuon] [varchar](25) NOT NULL,
	[manhanvienlapphieu] [varchar](25) NOT NULL,
	[ngaylapphieu] [date] NOT NULL,
	[madocgia] [varchar](25) NOT NULL,
 CONSTRAINT [PK_PhieuMuon] PRIMARY KEY CLUSTERED 
(
	[maphieumuon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sach](
	[masach] [varchar](25) NOT NULL,
	[tensach] [nvarchar](100) NOT NULL,
	[loaisach] [nvarchar](100) NOT NULL,
	[matacgia] [varchar](25) NOT NULL,
	[manhaxuatban] [varchar](25) NOT NULL,
	[ngayxuatban] [date] NOT NULL,
	[soluong] [smallint] NOT NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TacGia]    Script Date: 10/28/2023 11:03:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TacGia](
	[matacgia] [varchar](25) NOT NULL,
	[tentacgia] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[matacgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
GO
INSERT [dbo].[ChiTietPhieuMuon] ([maphieumuon], [masach], [tinhtrang], [ngaytrasach], [tienphat], [manhanviennhansachtra]) VALUES (N'PM001', N'MS002', 0, CAST(N'2023-12-06' AS Date), 0, N'NV002')
INSERT [dbo].[ChiTietPhieuMuon] ([maphieumuon], [masach], [tinhtrang], [ngaytrasach], [tienphat], [manhanviennhansachtra]) VALUES (N'PM002', N'MS004', 0, CAST(N'2023-11-30' AS Date), 0, N'NV002')
INSERT [dbo].[ChiTietPhieuMuon] ([maphieumuon], [masach], [tinhtrang], [ngaytrasach], [tienphat], [manhanviennhansachtra]) VALUES (N'PM003', N'MS009', 1, NULL, 0, NULL)
GO
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG001', N'Nguyễn Bình An', CAST(N'2004-10-31' AS Date), N'Nam', N'Quốc Oai, Hà Nội', N'DHTI16A12HN', CAST(N'2020-08-10' AS Date), N'NV003', N'reader1')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG002', N'Nguyễn Thị Huyền', CAST(N'2002-09-03' AS Date), N'Nữ', N'Thiên Trường, Nam Định', N'DHKT14A1ND', CAST(N'2020-04-14' AS Date), N'NV005', N'reader2')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG003', N'Nguyễn Đình Vũ', CAST(N'2002-03-04' AS Date), N'Nam', N'Mê Linh,Vĩnh Phúc', N'DHTI14A12HN', CAST(N'2023-03-10' AS Date), N'NV003', N'reader3')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG004', N'Nguyễn Văn Sơn ', CAST(N'2002-01-31' AS Date), N'Nam', N'Quễ Võ, Bắc Ninh', N'DHTI14A12HN', CAST(N'2023-03-11' AS Date), N'NV003', N'reader4')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG005', N'Khuất Hoàng Sơn', CAST(N'2002-03-04' AS Date), N'Nam', N'Hà Nội', N'DHTI14A12HN', CAST(N'2023-03-01' AS Date), N'NV002', N'reader5')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG006', N'Phan Thanh Tâm', CAST(N'2002-03-02' AS Date), N'Nam', N'Hà Nội', N'DHTI14A12HN', CAST(N'2022-04-02' AS Date), N'NV002', N'reader6')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG007', N'Nguyễn Văn Nam', CAST(N'2002-07-01' AS Date), N'Nam', N'Bắc Ninh', N'DHTI14A12HN', CAST(N'2022-02-06' AS Date), N'NV002', N'reader7')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG008', N'Nguyễn Thị Thơm', CAST(N'2002-04-02' AS Date), N'Nữ', N'Hải Dương', N'DHTI14A12HN', CAST(N'2022-01-24' AS Date), N'NV004', N'reader8')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG009', N'Nguyễn Thị Thuyên', CAST(N'2002-05-08' AS Date), N'Nữ', N'Hà Nội', N'DHTI14A12HN', CAST(N'2022-04-03' AS Date), N'NV002', N'reader9')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG010', N'Nguyễn Minh Phương', CAST(N'2002-11-13' AS Date), N'Nam', N'Bắc Ninh', N'DHTI14A12HN', CAST(N'2022-05-03' AS Date), N'NV002', N'reader10')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG011', N'Trọng Nhất', CAST(N'2002-11-24' AS Date), N'Nam', N'Hải Dương', N'DHTI14A8HN', CAST(N'2022-04-07' AS Date), N'NV005', N'reader11')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG012', N'Nguyễn Văn Thành', CAST(N'2002-07-09' AS Date), N'Nam', N'Thái Bình', N'DHTP14A3HN', CAST(N'2022-05-03' AS Date), N'NV003', N'reader12')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG013', N'Phương Anh', CAST(N'2002-03-06' AS Date), N'Nữ', N'Thái Bình', N'DHTI14A12HN', CAST(N'2022-05-06' AS Date), N'NV002', N'reader13')
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG014', N'Nguyễn Mỹ Tâm', CAST(N'2002-04-05' AS Date), N'Nữ', N'Nha Trang ', N'DHTI14A1HN', CAST(N'2023-07-03' AS Date), N'NV002', N'reader14')
GO
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'admin', N'admin', N'quanly')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'anhtu', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'huyendieu', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'nguyenthang', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'phamphong', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader1', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader10', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader11', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader12', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader13', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader14', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader15', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader2', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader3', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader4', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader5', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader6', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader7', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader8', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader9', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'thanhtrung', N'admin', N'thuthu')
GO
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV001', N'Nguyễn Thiện Thắng', CAST(N'2002-03-10' AS Date), N'Nam', N'0745749454', N'nguyenthang')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV002', N'Nguyễn Anh Tú', CAST(N'2002-08-17' AS Date), N'Nam', N'0584759386', N'anhtu')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV003', N'Phạm Văn Phong', CAST(N'2002-10-04' AS Date), N'Nam', N'0318574668', N'phamphong')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV004', N'Nguyễn Thành Trung', CAST(N'2002-09-15' AS Date), N'Nam', N'0258674957', N'thanhtrung')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV005', N'Trịnh Thị Huyền Diệu', CAST(N'2002-09-25' AS Date), N'Nữ', N'0522345678', N'huyendieu')
GO
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB001', N'Kim Đồng')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB002', N'Elsevier')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB003', N'Pearson')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB004', N'Trẻ')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB005', N'Hội Nhà Văn')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB006', N'Chính Trị Quốc Gia Sự Thật')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB007', N'Phụ Nữ Việt Nam')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB008', N'Lao Động')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB009', N'Nhã Nam')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB010', N'Đinh Tị')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB011', N'Đông A')
INSERT [dbo].[NhaXuatBan] ([manhaxuatban], [tennhaxuatban]) VALUES (N'NXB012', N'Thanh Niên')
GO
INSERT [dbo].[PhieuMuon] ([maphieumuon], [manhanvienlapphieu], [ngaylapphieu], [madocgia]) VALUES (N'PM001', N'NV002', CAST(N'2023-12-01' AS Date), N'DG001')
INSERT [dbo].[PhieuMuon] ([maphieumuon], [manhanvienlapphieu], [ngaylapphieu], [madocgia]) VALUES (N'PM002', N'NV003', CAST(N'2023-11-27' AS Date), N'DG002')
INSERT [dbo].[PhieuMuon] ([maphieumuon], [manhanvienlapphieu], [ngaylapphieu], [madocgia]) VALUES (N'PM003', N'NV002', CAST(N'2023-11-27' AS Date), N'DG013')
GO
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS001', N'Dế Mèn Phiêu Lưu Kí', N'Truyện', N'TG012', N'NXB001', CAST(N'1941-04-02' AS Date), 5)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS002', N'Đất Rừng Phương Nam', N'Tiểu Thuyết', N'TG010', N'NXB001', CAST(N'2010-05-10' AS Date), 5)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS003', N'Góc sân và khoảng trời', N'Thơ', N'TG013', N'NXB001', CAST(N'2013-04-12' AS Date), 3)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS004', N'Vừa nhắm mắt vừa mở cửa sổ', N'Truyện Dài', N'TG014', N'NXB004', CAST(N'2002-05-13' AS Date), 1)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS005', N'Cho tôi xin một vé đi tuổi thơ', N'Truyện Thiếu Nhi', N'TG005', N'NXB004', CAST(N'2018-02-01' AS Date), 3)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS006', N'Tết ở làng địa ngục', N'Truyện Ma', N'TG015', N'NXB012', CAST(N'2022-05-07' AS Date), 3)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS007', N'Suối Cọp', N'Văn Xuôi', N'TG016', N'NXB005', CAST(N'2017-04-06' AS Date), 3)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS008', N'Tắt Đèn', N'Truyện ', N'TG017', N'NXB001', CAST(N'2015-05-03' AS Date), 1)
INSERT [dbo].[Sach] ([masach], [tensach], [loaisach], [matacgia], [manhaxuatban], [ngayxuatban], [soluong]) VALUES (N'MS009', N'Conan', N'Truyện Tranh', N'TG012', N'NXB001', CAST(N'2013-05-04' AS Date), 29)
GO
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG001', N'Nguyễn Du')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG002', N'Nam Cao')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG003', N'Hồ Xuân Hương')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG004', N'Nguyễn Ngọc Ngạn')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG005', N'Nguyễn Nhật Ánh')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG006', N'Ngô Tất Tố')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG007', N'Bùi Anh Tuấn')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG008', N'Thạch Lam')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG009', N'Vũ Trọng Phụng')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG010', N'Đoàn Giỏi')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG011', N'Thái Sơn')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG012', N'Tô Hoài')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG013', N'Trần Đăng Khoa')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG014', N'Nguyễn Ngọc Thuần')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG015', N'Thảo Trang')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG016', N'Hữu Ước')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'Tg017', N'Ngô Tất Tố')
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] ADD DEFAULT ((0)) FOR [tienphat], DEFAULT (('true')) FOR [tinhtrang]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuMuon_NhanVien1] FOREIGN KEY([manhanviennhansachtra])
REFERENCES [dbo].[NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK_ChiTietPhieuMuon_NhanVien1]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuMuon_PhieuMuon] FOREIGN KEY([maphieumuon])
REFERENCES [dbo].[PhieuMuon] ([maphieumuon])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK_ChiTietPhieuMuon_PhieuMuon]
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuMuon_Sach] FOREIGN KEY([masach])
REFERENCES [dbo].[Sach] ([masach])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK_ChiTietPhieuMuon_Sach]
GO
ALTER TABLE [dbo].[DocGia]  WITH CHECK ADD  CONSTRAINT [FK_DocGia_NhanVien] FOREIGN KEY([manhanvientaothe])
REFERENCES [dbo].[NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[DocGia] CHECK CONSTRAINT [FK_DocGia_NhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_NguoiDung] FOREIGN KEY([tendangnhap])
REFERENCES [dbo].[NguoiDung] ([tendangnhap])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_NguoiDung]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_DocGia] FOREIGN KEY([madocgia])
REFERENCES [dbo].[DocGia] ([madocgia])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_DocGia]
GO
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_NhanVien] FOREIGN KEY([manhanvienlapphieu])
REFERENCES [dbo].[NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_NhanVien]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([manhaxuatban])
REFERENCES [dbo].[NhaXuatBan] ([manhaxuatban])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TacGia] FOREIGN KEY([matacgia])
REFERENCES [dbo].[TacGia] ([matacgia])
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TacGia]
GO
/****** Object:  Trigger [dbo].[updateSoluongsach]    Script Date: 12/3/2023 4:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER after_insert_chitietmuon
ON ChiTietPhieuMuon
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;

    -- Trừ số lượng sách trong bảng sách đi 1
    UPDATE sach
    SET soluong = soluong - 1
    WHERE masach IN (SELECT masach FROM INSERTED);
END;
GO
-- Tạo trigger sau khi cập nhật dữ liệu trong bảng chi tiết mượn trả
CREATE TRIGGER after_update_chitietmuontra
ON ChiTietPhieuMuon
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tình trạng có thay đổi hay không
    IF UPDATE(tinhtrang)
    BEGIN
        -- Trừ hoặc cộng số lượng sách tùy thuộc vào tình trạng mới
        UPDATE sach
        SET soluong = 
            CASE 
                WHEN (INSERTED.tinhtrang = 1) THEN soluong - 1  -- Trừ số lượng sách nếu là mượn
                WHEN (INSERTED.tinhtrang = 0) THEN soluong + 1  -- Tăng số lượng sách nếu là trả sách
                ELSE soluong
            END
        FROM sach
        INNER JOIN INSERTED ON sach.masach = INSERTED.masach;
    END;
END;
GO
-- Tạo trigger sau khi xóa dữ liệu trong phiếu mượn
CREATE TRIGGER after_delete_chitietmuontra
ON ChiTietPhieuMuon
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tình trạng có thay đổi hay không
    UPDATE sach
    SET soluong = soluong + 1
    FROM sach
    INNER JOIN deleted ON sach.masach = deleted.masach
	WHERE deleted.tinhtrang = 1;
END;
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] ENABLE TRIGGER [after_insert_chitietmuon], [after_update_chitietmuontra], [after_delete_chitietmuontra]
GO
/****** Object:  Trigger [dbo].[updateTienphat]    Script Date: 12/3/2023 4:35:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER [dbo].[updateTienphat]
   ON  [dbo].[ChiTietPhieuMuon]
   AFTER INSERT,UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for trigger here
	UPDATE ctm
    SET ctm.tienphat = (DATEDIFF(DAY, pm.ngaylapphieu, ISNULL(i.ngaytrasach, GETDATE())) - 30) * 2000
    FROM ChiTietPhieuMuon ctm
    INNER JOIN Inserted i ON ctm.maphieumuon = i.maphieumuon AND ctm.masach = i.masach
    INNER JOIN PhieuMuon pm ON ctm.maphieumuon = pm.maphieumuon
    WHERE DATEDIFF(DAY, pm.ngaylapphieu, ISNULL(i.ngaytrasach, GETDATE())) > 30;

	UPDATE ctm
    SET ctm.tienphat = 0
    FROM ChiTietPhieuMuon ctm
    INNER JOIN Inserted i ON ctm.maphieumuon = i.maphieumuon AND ctm.masach = i.masach
    INNER JOIN PhieuMuon pm ON ctm.maphieumuon = pm.maphieumuon
    WHERE DATEDIFF(DAY, pm.ngaylapphieu, ISNULL(i.ngaytrasach, GETDATE())) <= 30;
END
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] ENABLE TRIGGER [updateTienphat]
GO
USE [master]
GO
ALTER DATABASE [quanlythuvien] SET  READ_WRITE 
GO
