create database QuanLyCungCapVideo
go
use QuanLyCungCapVideo
go 
create table TAIKHOAN
(
	IDTK varchar(10) primary key,
	TenND varchar(50) NULL,
	MatKhau varchar(50) NULL,
	DienThoai varchar(50) NULL,
	Email varchar(50) NULL,
	IDQuyen int,

)
create table QUYEN
(
	IDQuyen int primary key,
	Quyen varchar(50),
)
create table DICHVU
(
	IDDV varchar(10) primary key,
	TenDV varchar(50),
	GiaTien varchar(50),
)
create table VIDEO
(
	IDVideo varchar(10) ,
	TenVideo  varchar(50),
	IDTL varchar(10),
	QuocGia varchar(50),
	ThoiLuong Varchar(30),
	DaoDien varchar(50),
	LuotXem int,
	LinkVideo varchar(50),
	LinkPoster varchar(50),
	CONSTRAINT VIDEO_pk PRIMARY KEY (IDVideo,LinkVideo)
)
create table THELOAI
(
	IDTL varchar(10) primary key,
	TenTL varchar(50),
)
create table THANHTOAN
(
	IDTK varchar(10),
	IDDV varchar(10),
	HTTT varchar(50),
	NgayTT datetime,
	NgayKT datetime,
	GiaTien decimal,
)
create table YEUTHICH
(
	IDTK varchar(10),
	LinkVideo varchar(50),
	LinkPoster  varchar(50),
	IDVideo varchar(10) ,
	CONSTRAINT YEUTHICH_pk PRIMARY KEY (IDVideo,LinkVideo)

)
alter table THANHTOAN
add constraint FK_TT_TK foreign key (IDTK) references TAIKHOAN(IDTK)
alter table THANHTOAN
add constraint FK_TT_DV foreign key (IDDV) references DICHVU(IDDV)
alter table YEUTHICH
add constraint FK_YT_TK foreign key (IDTK) references TAIKHOAN(IDTK)

alter table YEUTHICH
add constraint FK_YT_VD foreign key (LinkVideo,IDVideo) references VIDEO(LinkVideo,IDVideo)


alter table VIDEO
add constraint FK_VD_TL foreign key (IDTL) references THELOAI(IDTL)
alter table TAIKHOAN
add constraint FK_TK_Q foreign key (IDQuyen) references Quyen(IDQuyen)