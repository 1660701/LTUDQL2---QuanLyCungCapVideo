USE [master]
GO
/****** Object:  Database [QuanLyCungCapVideo]    Script Date: 05/06/2019 5:36:19 CH ******/
CREATE DATABASE [QuanLyCungCapVideo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyCungCapVideo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\QuanLyCungCapVideo.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QuanLyCungCapVideo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQL2014\MSSQL\DATA\QuanLyCungCapVideo_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QuanLyCungCapVideo] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyCungCapVideo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyCungCapVideo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [QuanLyCungCapVideo] SET DELAYED_DURABILITY = DISABLED 
GO
USE [QuanLyCungCapVideo]
GO
/****** Object:  Table [dbo].[DICHVU]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DICHVU](
	[IDDV] [int] IDENTITY(1,1) NOT NULL,
	[TenDV] [nvarchar](50) NULL,
	[GiaTien] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[QUYEN]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUYEN](
	[IDQuyen] [int] IDENTITY(1,1) NOT NULL,
	[Quyen] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[IDTK] [int] IDENTITY(1,1) NOT NULL,
	[TenND] [nvarchar](50) NULL,
	[MatKhau] [varchar](50) NULL,
	[DienThoai] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THANHTOAN]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THANHTOAN](
	[IDThanhToan] [int] IDENTITY(1,1) NOT NULL,
	[IDTK] [int] NULL,
	[IDDV] [int] NULL,
	[HTTT] [nvarchar](50) NULL,
	[NgayTT] [datetime] NULL,
	[NgayKT] [datetime] NULL,
	[GiaTien] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDThanhToan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THELOAI]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THELOAI](
	[IDTL] [int] IDENTITY(1,1) NOT NULL,
	[TenTL] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VIDEO]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VIDEO](
	[IDVideo] [int] IDENTITY(1,1) NOT NULL,
	[TenVideo] [nvarchar](50) NULL,
	[IDTL] [int] NULL,
	[QuocGia] [nvarchar](50) NULL,
	[ThoiLuong] [varchar](30) NULL,
	[DaoDien] [nvarchar](50) NULL,
	[LuotXem] [int] NULL,
	[LinkVideo] [varchar](50) NOT NULL,
	[LinkPoster] [varchar](50) NULL,
 CONSTRAINT [VIDEO_pk] PRIMARY KEY CLUSTERED 
(
	[IDVideo] ASC,
	[LinkVideo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[YEUTHICH]    Script Date: 05/06/2019 5:36:20 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[YEUTHICH](
	[IDYT] [int] IDENTITY(1,1) NOT NULL,
	[IDTK] [int] NULL,
	[LinkVideo] [varchar](50) NULL,
	[LinkPoster] [varchar](50) NULL,
	[IDVideo] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDYT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[QUYEN] ON 

INSERT [dbo].[QUYEN] ([IDQuyen], [Quyen]) VALUES (1, N'admin')
INSERT [dbo].[QUYEN] ([IDQuyen], [Quyen]) VALUES (2, N'staff')
SET IDENTITY_INSERT [dbo].[QUYEN] OFF
SET IDENTITY_INSERT [dbo].[TAIKHOAN] ON 

INSERT [dbo].[TAIKHOAN] ([IDTK], [TenND], [MatKhau], [DienThoai], [Email], [IDQuyen]) VALUES (1, N'admin', N'admin', N'555151', N'a@gmail.com', 1)
INSERT [dbo].[TAIKHOAN] ([IDTK], [TenND], [MatKhau], [DienThoai], [Email], [IDQuyen]) VALUES (2, N'staff', N'staff', N'651654646', N'b@gmail.com', 2)
SET IDENTITY_INSERT [dbo].[TAIKHOAN] OFF
SET IDENTITY_INSERT [dbo].[THELOAI] ON 

INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (1, N'Tình C?m')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (2, N'Vi?n T??ng')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (3, N'Hành ??ng')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (4, N'Phiêu L?u')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (5, N'Ho?t Hình')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (6, N'Hài K?ch')
INSERT [dbo].[THELOAI] ([IDTL], [TenTL]) VALUES (7, N'Âm Nh?c')
SET IDENTITY_INSERT [dbo].[THELOAI] OFF
SET IDENTITY_INSERT [dbo].[VIDEO] ON 

INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (1, N'N?m B??c ?? Yêu', 1, N'M?', N'116 p', N'Justin Baldoni', 23, N'nambuocdeyeu.mp4', N'1.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (2, N'Chàng Ng? T?p Yêu', 1, N'Romania', N'109 p', N'Cristina Jacob', 21, N'changngotapyeu.mp4', N'2.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (3, N'Luôn Luôn Có Th?', 1, N'M?', N'101 p', N'Nahnatchka Khan', 22, N'luonluoncothe.mp4', N'3.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (4, N'Môi Hôn Ng?t Ngào', 1, N'Anh', N'108 p', N'Annabel Jankel', 35, N'moihocngotngao.mp4', N'4.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (5, N'M?i L?', 1, N'M?', N'117 p', N'Drake Doremus', 15, N'moila.mp4', N'5.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (6, N'Mong Em H?nh Phúc ', 1, N'?ài Loan', N'105 p', N'Gavin Lin', 24, N'mongemhanhphuc.mp4', N'6.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (7, N'Ng??i B?n Tuy?t V?i', 1, N'M?', N'92 p', N'Jennifer Kaytin Robinson', 15, N'nguoibantuyetvoi.mp4', N'7.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (8, N'H? Cu?i', 1, N'M?', N'109 p', N'William Bindley', 43, N'hacuoi.mp4', N'8.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (9, N'Bi?t ??i Siêu Anh Hùng 4: Tàn Cu?c', 2, N'M?', N'181 p', N'Joe Russo, Anthony Russo', 45, N'endgame.mp4', N'9.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (10, N'Qu? ??', 2, N'M?, Anh, Bulgaria', N'120 p', N'Neil Marshall', 23, N'quydo.mp4', N'10.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (11, N'T? Thiên ??i Thánh: H?a Di?n S?n', 2, N'Trung Qu?c', N'90 p', N'Zhenzhao Lin', 22, N'tethiendaithanh.mp4', N'11.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (12, N'Khu Ngh? D??ng Xác S?ng', 2, N'Anh, Tây Ban Nha, Belgium', N'93 p', N'Steve Barker,', 33, N'khunghiduongsacsong.mp4', N'12.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (13, N'?? Ch? M?i', 2, N'M?', N'109 p', N'Rupert Wyatt', 12, N'dechemoi.mp4', N'13.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (14, N'B? Ba Quái Nhân', 2, N'M?', N'128 p', N'M. Night Shyamalan,', 43, N'bobaquainhan.mp4', N'14.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (15, N'??i Úy MARVEL', 2, N'M?, Úc', N'123 P', N'Anna Boden, Ryan Fleck, ', 24, N'daiuy.mp4', N'15.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (16, N'Gi?i C?u Th? Gi?i', 2, N'M?', N'98 p', N'M?,', 34, N'giaicuuthegioi.mp4', N'16.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (17, N'Tù Nhân Báo Thù', 3, N'Anh', N'90 P', N'Jesse V. Johnson,', 12, N'tunhanbaothu.mp4', N'17.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (18, N'K? Phá H?y', 3, N'M?', N'121 p', N'Karyn Kusama,', 43, N'kephahuy.mp4', N'18.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (19, N'Bông H?ng Sát Th?', 3, N'Philippines', N'90 p', N'Pedring Lopez', 22, N'bonghongsatthu.mp4', N'19.jpg')
INSERT [dbo].[VIDEO] ([IDVideo], [TenVideo], [IDTL], [QuocGia], [ThoiLuong], [DaoDien], [LuotXem], [LinkVideo], [LinkPoster]) VALUES (20, N'B?u Tr?i Thép', 3, N'Úc, ??c, Finland', N'93 p', N'Timo Vuorensola,', 32, N'bautroithep.mp4', N'20.jpg')
SET IDENTITY_INSERT [dbo].[VIDEO] OFF
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TK_Q] FOREIGN KEY([IDQuyen])
REFERENCES [dbo].[QUYEN] ([IDQuyen])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TK_Q]
GO
ALTER TABLE [dbo].[THANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_TT_DV] FOREIGN KEY([IDDV])
REFERENCES [dbo].[DICHVU] ([IDDV])
GO
ALTER TABLE [dbo].[THANHTOAN] CHECK CONSTRAINT [FK_TT_DV]
GO
ALTER TABLE [dbo].[THANHTOAN]  WITH CHECK ADD  CONSTRAINT [FK_TT_TK] FOREIGN KEY([IDTK])
REFERENCES [dbo].[TAIKHOAN] ([IDTK])
GO
ALTER TABLE [dbo].[THANHTOAN] CHECK CONSTRAINT [FK_TT_TK]
GO
ALTER TABLE [dbo].[VIDEO]  WITH CHECK ADD  CONSTRAINT [FK_VD_TL] FOREIGN KEY([IDTL])
REFERENCES [dbo].[THELOAI] ([IDTL])
GO
ALTER TABLE [dbo].[VIDEO] CHECK CONSTRAINT [FK_VD_TL]
GO
ALTER TABLE [dbo].[YEUTHICH]  WITH CHECK ADD  CONSTRAINT [FK_YEUTHICH_VIDEO] FOREIGN KEY([IDVideo], [LinkVideo])
REFERENCES [dbo].[VIDEO] ([IDVideo], [LinkVideo])
GO
ALTER TABLE [dbo].[YEUTHICH] CHECK CONSTRAINT [FK_YEUTHICH_VIDEO]
GO
ALTER TABLE [dbo].[YEUTHICH]  WITH CHECK ADD  CONSTRAINT [FK_YT_TK] FOREIGN KEY([IDTK])
REFERENCES [dbo].[TAIKHOAN] ([IDTK])
GO
ALTER TABLE [dbo].[YEUTHICH] CHECK CONSTRAINT [FK_YT_TK]
GO
USE [master]
GO
ALTER DATABASE [QuanLyCungCapVideo] SET  READ_WRITE 
GO
