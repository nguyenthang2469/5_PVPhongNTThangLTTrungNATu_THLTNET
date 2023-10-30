use [master]
go

if exists (select name from sys.databases where name = N'quanlythuvien')
begin
    alter database quanlythuvien set single_user with rollback immediate
    drop database quanlythuvien
end

create database quanlythuvien
go

use quanlythuvien
go

-- Set quyen cho database
alter authorization on database::quanlythuvien to [sa]

-------PHAN TAO BANG----------------------------------
CREATE TABLE [dbo].[ChiTietPhieuMuon](
	[maphieumuon] [varchar](25) NOT NULL,
	[masach] [varchar](25) NOT NULL,
	[tinhtrang] [bit] NOT NULL,
	[ngaytrasach] [date] NOT NULL,
	[tienphat] [int] NOT NULL,
	[manhanviennhansachtra] [varchar](25) NULL,
 CONSTRAINT [PK_ChiTietPhieuMuon] PRIMARY KEY CLUSTERED 
(
	[maphieumuon] ASC,
	[masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
	[gioitinh] [bit] NOT NULL,
	[diachi] [nvarchar](100) NOT NULL,
	[lophoc] [nvarchar](50) NOT NULL,
	[ngaytaothe] [date] NOT NULL,
	[manhanvientaothe] [varchar](25) NOT NULL,
	[tendangnhap] [varchar](100) NOT NULL,
 CONSTRAINT [PK_DocGia] PRIMARY KEY CLUSTERED 
(
	[madocgia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
	[gioitinh] [bit] NOT NULL,
	[sodienthoai] [char](10) NOT NULL,
	[tendangnhap] [varchar](100) NOT NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DocGia] ([madocgia], [tendocgia], [ngaysinh], [gioitinh], [diachi], [lophoc], [ngaytaothe], [manhanvientaothe], [tendangnhap]) VALUES (N'DG001', N'Nguyễn Bình An', CAST(N'2004-03-06' AS Date), 0, N'Quốc Oai, Hà Nội', N'DHTI14A12HN', CAST(N'2019-08-10' AS Date), N'NV003', N'reader1')
GO
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'admin', N'admin', N'quanly')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'anhtu', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'huyendieu', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'nguyenthang', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'phamphong', N'admin', N'thuthu')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader1', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader2', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader3', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader4', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader5', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader6', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader7', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'reader8', N'123456', N'docgia')
INSERT [dbo].[NguoiDung] ([tendangnhap], [matkhau], [loainguoidung]) VALUES (N'thanhtrung', N'admin', N'thuthu')
GO
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV001', N'Nguyễn Thiện Thắng', CAST(N'2002-02-10' AS Date), 0, N'0987654321', N'nguyenthang')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV002', N'Nguyễn Anh Tú', CAST(N'2002-08-17' AS Date), 0, N'0584759386', N'anhtu')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV003', N'Phạm Văn Phong', CAST(N'2002-10-04' AS Date), 0, N'0318574668', N'phamphong')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV004', N'Nguyễn Thành Trung', CAST(N'2002-09-15' AS Date), 0, N'0258674957', N'thanhtrung')
INSERT [dbo].[NhanVien] ([manhanvien], [tennhanvien], [ngaysinh], [gioitinh], [sodienthoai], [tendangnhap]) VALUES (N'NV005', N'Trịnh Thị Huyền Diệu', CAST(N'2002-09-25' AS Date), 1, N'0522345678', N'huyendieu')
GO
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG001', N'Nguyễn Du')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG002', N'Nam Cao')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG003', N'Hồ Xuân Hương')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG004', N'Nguyễn Ngọc Ngạn')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG005', N'Nguyễn Nhật Ánh:')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG006', N'Ngô Tất Tố')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG007', N'Bùi Anh Tuấn')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG008', N'Thạch Lam')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG009', N'Vũ Trọng Phụng')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG010', N'Đoàn Giỏi')
INSERT [dbo].[TacGia] ([matacgia], [tentacgia]) VALUES (N'TG011', N'Thái Sơn')
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietPhieuMuon_NhanVien1] FOREIGN KEY([manhanviennhansachtra])
REFERENCES [dbo].[NhanVien] ([manhanvien])
GO
ALTER TABLE [dbo].[ChiTietPhieuMuon] CHECK CONSTRAINT [FK_ChiTietPhieuMuon_NhanVien1]
GO
ALTER TABLE [dbo].[DocGia]  WITH CHECK ADD  CONSTRAINT [FK_DocGia_NguoiDung] FOREIGN KEY([tendangnhap])
REFERENCES [dbo].[NguoiDung] ([tendangnhap])
GO
ALTER TABLE [dbo].[DocGia] CHECK CONSTRAINT [FK_DocGia_NguoiDung]
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
USE [master]
GO
ALTER DATABASE [quanlythuvien] SET  READ_WRITE 
GO
