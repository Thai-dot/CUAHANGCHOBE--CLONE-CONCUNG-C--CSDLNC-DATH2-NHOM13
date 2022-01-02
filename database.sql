--drop database CUAHANGCHOBE
--CREATE DATABASE CUAHANGCHOBE
--use CUAHANGCHOBE EXEC sp_changedbowner 'sa'
--use CUAHANGCHOBE

create table KHACHHANG(
	MaKH int,
	HoTenKH nvarchar(50),
	SDTKH nvarchar(10),
	NgaySinhKH date,
	DiaChiKH nvarchar(50),
	EmailKH char(40)

	constraint PK_KH
	primary key (MAKH)

)


create table TREEM(
	MaKH int,
	STT_TE int,
	HoTenBe nvarchar(50),
	GoiTinhBe nvarchar(3),
	NgaySinhBe date,
	
	constraint PK_TE
	primary key (MAKH,STT_TE),

	CONSTRAINT CHK_GioiTinhBe CHECK (GoiTinhBe = N'Nam' or GoiTinhBe=N'Nữ')
)


create table TAIKHOAN(
	ID int,
	TenDangNhap char(30) not null unique,
	MatKhau char(30) not null,
	MaKH int

	constraint PK_TaiKhoan
	primary key (ID),
	
)

create table NHANSU(
	MaNS int,
	HoTenNS nvarchar(50),
	DiaChiNS nvarchar(120),
	SDTNS char(10),
	LuongNS float,
	ChiNhanhLamViec int,
	LoaiNS nvarchar(30)
	
	CONSTRAINT PK_NHANSU
	PRIMARY KEY (MaNS),


)


create table TK_NhanSu
(
	ID int,
	TenDangNhapNS char(30) not null unique,
	MatKhauNS char(30) not null,
	MaNS int,

	constraint PK_TaiKhoanBH
	primary key (ID),


)


create table CHINHANH(
	MaChiNhanh int,
	DiaChiCN nvarchar(120),
	SDT_CN nvarchar(10),
	

	CONSTRAINT PK_CHINHANH
	PRIMARY KEY (MaChiNhanh)
)

create table HOADON(
	MaHoaDon int,
	NgayLap date,
	PhiVanChuyen float,
	PhiSanPham float,
	TongTien float,
	MaNS int,
	MaKH int,
	ChiNhanh int,
	HinhThucThanhToan nvarchar(20)
	

	CONSTRAINT PK_HOADON
	PRIMARY KEY (MaHoaDon)
)


create table PHIEUGIAOHANG(
	MaGH int,
	NgayGiao date,
	TinhTrangDH nvarchar(20),
	DiaChiGiao nvarchar(120),
	DonViVC int,
	MaHD int,
	MoTa nvarchar(50),

	CONSTRAINT PK_PGH
	PRIMARY KEY (MaGH)
)


create table DONVIVANCHUYEN(
	MaDV int,
	TenDV nvarchar(50),
	EmailDV nvarchar(127),
	SDT_DV nvarchar(10)

	CONSTRAINT PK_DVVC
	PRIMARY KEY (MaDV)
)


create table CT_HOADON(
	MaHoaDon int,
	MaSP int,
	GiaBan float,
	SoLuong int,
	ThanhTien float,

	CONSTRAINT PK_CT_HOADON
	PRIMARY KEY (MaHoaDon,MaSP)

)

create table MucGiamGia
(
	MaGG int,
	TGBatDau date,
	TGKetThuc date,
	MucGiam float

	CONSTRAINT PK_MGG
	PRIMARY KEY (MaGG),
	Constraint CHK_MUCGIAM CHECK(MUCGIAM <= 100 and MucGiam >=0),
	Constraint CHK_BD_KT CHECK(TGBATDAU <= TGKETTHUC)
)

create table SANPHAM
(
	MaSP int,
	TenSP nvarchar(150),
	GiaBan float,
	GiaMua float,
	DoiTac int not null,
	LoaiSP nvarchar(30),
	MaGG int,

	CONSTRAINT PK_SP
	PRIMARY KEY (MaSP),

)

create table GIOHANG
(
	MaGioHang int,
	MaKH int,
	NgayThem date

	CONSTRAINT PK_GioHang
	PRIMARY KEY (MaGioHang,MaKh)
)


create table GH_SP
(
	MaSp int,
	MaGioHang int,
	MaKH int,
	SoLuongSP int,
	ThanhTienGH float,

	CONSTRAINT PK_GH_SP
	PRIMARY KEY (MaSp,MaGioHang,MaKH)
)




create table KHO
(
	MaKho int,
	TenKho nvarchar(30),
	DiaChiKho nvarchar(50),
	SDTKho char(10)

	CONSTRAINT PK_Kho
	PRIMARY KEY (MaKho)
)


create table KHO_CHINHANH
(
	MaKho int,
	MaChiNhanh int,
	NgayCC datetime,
	MaSP int,
	SoLuongCC int,

	CONSTRAINT PK_Kho_ChiNhanh
	PRIMARY KEY (MaKho,MaChiNhanh,NgayCC)
)



create table DOITAC
(
	MADT int,
	TenDoiTac nvarchar(50),
	DiaChiDT nvarchar(100),
	SDT_DT nvarchar(10),
	Email_DT nvarchar(100)

	CONSTRAINT PK_DOITAC
	PRIMARY KEY (MADT)
)

create table HOPDONG
(
	MaHD int,
	NgayLapHD date,
	NgayDenHan date,
	MaSothue nvarchar(10),
	TinhTrangHopDong nvarchar(20),
	MaDT int,
	MaNS int
	
	CONSTRAINT PK_HOPDONG
	PRIMARY KEY (MaHD)
)


create table KHO_DOITAC
(
	MaKho int,
	MADT int,
	NgayCungCap datetime,
	MaSP int,
	SoLuongCC int,

	CONSTRAINT PK_Kho_DoiTac
	PRIMARY KEY (MaKho,MaDT,NgayCungCap)
)

create table KHO_SanPham
(
	MaKho int,
	MaSP int,
	SLSP int

	CONSTRAINT PK_Kho_SanPham
	PRIMARY KEY (MaKho,MaSP)
)

create table ChiNhanh_SanPham(
	MaCN int,
	MaSP int,
	SoLuongTon int,
	CONSTRAINT PK_ChiNhanhSP
	PRIMARY KEY (MaCN,MaSP)
	
)


create table KHACHHANG_YEUTHICH(
	MaKH int,
	MaSP int,
	TenSP nvarchar(50),
	GiaBan float,
	NgayThemYeuThich date default getdate(),
	MaDT int,
	TenDoiTac nvarchar(50),

	constraint FK_KH_YT
	primary key (MaKH,MaSP)
)

create table DiemDanhNhanSu
(
	MaNS int,
	NgayDiemDanh datetime,

	constraint PK_DIemDanhNhanSu
	primary key (MaNS,NgayDiemDanh)
)


create table LichSu_MuaHang
(
	MaKH int,
	MaHD int,
	TongTien float,
	NgayCapNhat date,
	TinhTrangDonHang nvarchar(20)

	constraint PK_LSMH
	primary key (MaKH,MaHD)
)

alter table LichSu_MuaHang
add
	constraint FK_LSMH_KH
	foreign key (MaKH)
	references KhachHang,
	constraint FK_LSMH_HoaDon
	foreign key (MaHD)
	references HoaDon


alter table DiemDanhNhanSU
add
	constraint FK_DIEMDANH_NS
	foreign key (MaNS)
	references NhanSU
	ON DELETE CASCADE


alter table KHACHHANG_YEUTHICH
ADD	
	CONSTRAINT FK_KHYT_KH
	foreign key (MaKH)
	references KhachHang,
	constraint FK_KHYT_SP
	foreign key(MaSP)
	references SanPham,
	constraint FK_KHYT_DT
	foreign key (MaDT)
	references DoiTac



alter table TK_NhanSu
add
constraint FK_TKBH_NS
foreign key(MaNS)
references NhanSU



alter table HOADON
add
	constraint FK_HD_CN
	foreign key(ChiNhanh)
	references ChiNhanh

ALTER TABLE ChiNhanh_SanPham
ADD
	CONSTRAINT FK_CN_SP_CN
	foreign key (MaCN) 
	REFERENCES ChiNhanh,
	CONSTRAINT FK_CN_SP_SP
	foreign key (MaSP) 
	REFERENCES SANPHAM
	on delete cascade

ALTER TABLE KHO_SANPHAM
ADD
	CONSTRAINT FK_KHOSP_SP
	foreign key (MaSP) 
	REFERENCES SANPHAM,
	CONSTRAINT FK_KHOSP_KHO
	foreign key (MaKho) 
	REFERENCES KHO
	on delete cascade

alter table SanPham
add
CONSTRAINT FK_SanPham_DoiTac
	foreign key (DoiTac) 
	REFERENCES DoiTac
	

alter table GioHang
add
CONSTRAINT FK_GioHang_SP
	foreign key (MaKH) 
	REFERENCES KhachHang

ALTER TABLE HOPDONG
ADD 
	CONSTRAINT FK_HOPDONG_DOITAC
	FOREIGN KEY (MaDT)
	REFERENCES DOITAC
	ON DELETE SET NULL,
	CONSTRAINT FK_HOPDONG_NHANSU
	FOREIGN KEY (MaNS)
	REFERENCES NhanSu
	ON DELETE SET NULL



ALTER TABLE KHO_DOITAC
ADD 
	CONSTRAINT FK_KhoDT_MaKHO
	FOREIGN KEY (MaKho)
	REFERENCES KHO,
	CONSTRAINT FK_KhoDoiTac_DoiTac
	FOREIGN KEY (MaDT)
	REFERENCES DOITAC,
	CONSTRAINT FK_KhoDoiTac_SP
	FOREIGN KEY (MaSP)
	REFERENCES SanPham
	on delete cascade


ALTER TABLE KHO_CHINHANH
ADD 
	CONSTRAINT FK_KhoCHINHANH_MAKHO
	FOREIGN KEY (MaKho)
	REFERENCES KHO,
	CONSTRAINT FK_KhoCHINHANH_ChiNhanh
	FOREIGN KEY (MaChiNhanh)
	REFERENCES ChiNhanh,
	CONSTRAINT FK_KhoCHINHANH_SP
	FOREIGN KEY (MaSP)
	REFERENCES SanPham
	on delete cascade
	
ALTER TABLE PHIEUGIAOHANG
ADD CONSTRAINT FK_PhieuGiaoHang_HoaDon
FOREIGN KEY (MaHD)
REFERENCES HOADON

ALTER TABLE GH_SP
ADD CONSTRAINT FK_GHSP_SP
FOREIGN KEY (MaSP)
REFERENCES SanPham
on delete cascade

ALTER TABLE GH_SP
ADD CONSTRAINT FK_GHSP_GioHang
FOREIGN KEY (MaGioHang,MaKH)
REFERENCES GIOHANG



ALTER TABLE SANPHAM
ADD CONSTRAINT FK_SP_MGG
FOREIGN KEY (MaGG)
REFERENCES MucGiamGia

ALTER TABLE CT_HOADON
ADD CONSTRAINT FK_CTHD_HD
FOREIGN KEY (MaHoaDon)
REFERENCES HoaDon
ON DELETE CASCADE

ALTER TABLE CT_HOADON
add CONSTRAINT FK_CTHD_SP
FOREIGN KEY (MaSP)
REFERENCES SANpHAM
ON DELETE CASCADE

ALTER TABLE NHANSU
ADD CONSTRAINT FK_NS_CHINHANH
FOREIGN KEY (ChiNhanhLamViec)
REFERENCES CHINHANH


ALTER TABLE TREEM
ADD CONSTRAINT FK_TE_KH
FOREIGN KEY (MaKH)
REFERENCES KHACHHANG
ON DELETE CASCADE

AlTER TABLE TAIKHOAN
ADD CONSTRAINT FK_TK_KH
FOREIGN KEY (MAKH)
REFERENCES KHACHHANG
ON DELETE CASCADE;

ALTER TABLE HOADON
ADD CONSTRAINT FK_HD_NS
FOREIGN KEY (MaNS)
REFERENCES NhanSu
ON DELETE SET NULL

ALTER TABLE HOADON
ADD CONSTRAINT FK_HD_KH
FOREIGN KEY (MaKH)
REFERENCES KhachHang

ALTER TABLE PHIEUGIAOHANG
ADD CONSTRAINT FK_GH_DVVC
FOREIGN KEY (DonViVC)
REFERENCES DonViVanChuyen

