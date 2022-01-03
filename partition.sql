--Horizontal partition 

select * from Sys.objects where Name = 'HoaDon'
select * from Sys.partitions where object_id = 1173579219

---Tạo ra các file group vào trong database đã tạo từ trước
GO
ALTER DATABASE [CUAHANGCHOBE] ADD FILEGROUP [Invoice2018]
GO
ALTER DATABASE [CUAHANGCHOBE] ADD FILEGROUP [Invoice2019]
GO
ALTER DATABASE [CUAHANGCHOBE] ADD FILEGROUP [Invoice2020]
GO
ALTER DATABASE [CUAHANGCHOBE] ADD FILEGROUP [Invoice2021]
GO

--Confirm filegroups
select name as [File Group Name]
from sys.filegroups
where type = 'FG'

--Confirm Datfiles
select name as [DB Filename],physical_name as [DB path]
from sys.database_files
where type_desc = 'Rows'
go

-- Tạo file lưu trữ data và tạo đường dẫn cho các partition, kích thước ban đầu là 8mb
GO
ALTER DATABASE [CUAHANGCHOBE] 
ADD FILE ( NAME = N'DBforInvoice2018', FILENAME = N'D:\SQL SERVER 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBforInvoice2018.ndf' , SIZE = 8192KB , FILEGROWTH = 65536KB ) 
TO FILEGROUP [Invoice2018]
GO
ALTER DATABASE [CUAHANGCHOBE] 
ADD FILE ( NAME = N'DBforInvoice2019', FILENAME = N'D:\SQL SERVER 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBforInvoice2019.ndf' , SIZE = 8192KB , FILEGROWTH = 65536KB ) 
TO FILEGROUP [Invoice2019]
GO
ALTER DATABASE [CUAHANGCHOBE] 
ADD FILE ( NAME = N'DBforInvoice2020', FILENAME = N'D:\SQL SERVER 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBforInvoice2020.ndf' , SIZE = 8192KB , FILEGROWTH = 65536KB ) 
TO FILEGROUP [Invoice2020]
GO
ALTER DATABASE [CUAHANGCHOBE] 
ADD FILE ( NAME = N'DBforInvoice2021', FILENAME = N'D:\SQL SERVER 2019\MSSQL15.SQLEXPRESS\MSSQL\DATA\DBforInvoice2021.ndf' , SIZE = 8192KB , FILEGROWTH = 65536KB ) 
TO FILEGROUP [Invoice2021]
GO


GO
CREATE PARTITION FUNCTION [InvoiceByYear_Partition_Function](date) 
AS RANGE RIGHT FOR VALUES (N'2019-01-01', N'2020-01-01', N'2021-01-01', N'2022-01-01')


BEGIN TRANSACTION
CREATE PARTITION SCHEME [InvoiceByYear_Partition_Schema] 
AS PARTITION [InvoiceByYear_Partition_Function]
TO ([Invoice2018], [Invoice2019], [Invoice2020], [Invoice2021], [PRIMARY])


ALTER TABLE [dbo].[CT_HOADON] DROP CONSTRAINT [FK_CTHD_HD]


ALTER TABLE [dbo].[PHIEUGIAOHANG] DROP CONSTRAINT [FK_PhieuGiaoHang_HoaDon]


ALTER TABLE [dbo].[HOADON] DROP CONSTRAINT [PK_HOADON] WITH ( ONLINE = OFF )


ALTER TABLE [dbo].[HOADON] ADD  CONSTRAINT [PK_HOADON] PRIMARY KEY NONCLUSTERED 
(
	[MaHoaDon] ASC
)


ALTER TABLE [dbo].[CT_HOADON]  WITH CHECK ADD  CONSTRAINT [FK_CTHD_HD] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
ON DELETE CASCADE
ALTER TABLE [dbo].[CT_HOADON] CHECK CONSTRAINT [FK_CTHD_HD]


ALTER TABLE [dbo].[PHIEUGIAOHANG]  WITH CHECK ADD  CONSTRAINT [FK_PhieuGiaoHang_HoaDon] FOREIGN KEY([MaHD])
REFERENCES [dbo].[HOADON] ([MaHoaDon])
ALTER TABLE [dbo].[PHIEUGIAOHANG] CHECK CONSTRAINT [FK_PhieuGiaoHang_HoaDon]


COMMIT TRANSACTION

create table Report_Invoice
(
	yearReport date primary key,
	TongTien float,
)
on [InvoiceByYear_Partition_Schema](yearReport)
go

INSERT INTO Report_Invoice (yearReport,TongTien)
SELECT '2019-01-01', 1000000000 UNION ALL
SELECT '2020-01-01', 2000000000 UNION ALL
SELECT '2021-01-01', 5000000000 UNION ALL
SELECT '2022-01-01', 1000000000


--Vertical Partition

--Problem 1:ban quản lý chỉ cần thông tin khách hàng như: HọTen, SDTKH, 
--các thuộc tính khác không yêu cầu truy xuất nhiều
create table KhachHang1
(
	MaKH int,
	HoTenKH nvarchar(50),
	SDTKH char(10),

	constraint PK_KhachHang1
	primary key(MaKH)
)

create table KhachHang2(
	MaKH int,
	NgaySinKH date,
	DiaChiKH nvarchar(50),

	constraint PK_KhachHang2
	primary key(MaKH)
)

alter table KhachHang2
add constraint FK_KH1_KH2
foreign key(MaKH)
references KhachHang1

--Problem 2: người dùng chỉ cần biết tên đơn vị vận chuyển 
--và số điện thoại của đơn vị vận chuyển:

create table DVVC1
(
	MaDV int,
	TenDV nvarchar(30),
	SDT_DV nvarchar(10),

	
	constraint PK_DVVC1
	primary key(MaDV)

)

create table DVVC2
(
	MaDV int,
	Email_DV nvarchar(50),
	DiaChi_DVV nvarchar(50),

	constraint PK_DVVC2
	primary key(MaDV)
)

alter table DVVC2
add constraint FK_DVVC2_DVVC1
foreign key(MaDV)
references DVVC1





