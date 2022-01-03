select * from sanpham
--Tìm các sản phẩm có loại là ‘Sữa’ và có số lượng bán được trong chi tiết đơn hàng là >45
go
create or alter proc TruyVan_Cau1 @LoaiSP nvarchar(30), @SoLuong int
as
begin
	if isnumeric(@LoaiSP) = 1
	begin
		raiserror(N'Loại sản phẩm nhập vào không hợp lệ',16,1) rollback;
	end
	if @SoLuong <0
	begin
		raiserror(N'Số lượng không thể âm',16,1) rollback;
	end
	if not exists (select * from SANPHAM where LoaiSP = @LoaiSP)
	begin 
		raiserror(N'Không có loại sản phẩm này trong cửa hàng',16,1) rollback;
	end
	select sp.MaSP, sp.TenSP
	from SanPham sp, CT_HOADON ct
	where LoaiSP = @LoaiSP and ct.MaSP = sp.MaSP and ct.SoLuong > @SoLuong
end

exec TruyVan_Cau1 N'Sữa',45

CREATE NONCLUSTERED INDEX Index_Cau1
ON [dbo].[CT_HOADON] ([MaSP],[SoLuong])


-- Thống kê số đơn hàng của ngày 30 tháng 5 năm 2021 có phí sản phẩm lơn hơn 2.000.000 đồng
go
create or alter proc TruyVan_Cau2 @NgayLap date, @PhiSP float
as
begin
	if isdate(cast(@NgayLap as nvarchar)) != 1
	begin 
		raiserror(N'Ngày lập nhập vào không hợp lệ',16,1) rollback;
	end
	if @PhiSP <0
	begin
		raiserror(N'Phí Sản Phẩm nhập vào không hợp lệ',16,1) rollback;
	end
	if not exists (select * from HoaDon where @NgayLap = NgayLap)
	begin
		raiserror(N'Ngày lập không tồn tại',16,1) rollback;
	end
	select MaHoaDon from hOAdON
	where NgayLap = @NgayLap and PhiSanPham > @PhiSP
	order by MaHoaDon
end

exec TruyVan_Cau2 '2021-05-30', 1000000

create nonclustered index Index_Cau2
on [dbo].[HOADON] ([NgayLap],[PhiSanPham])


select k.MaKho,cn.MaCN, cn.MaSp, k.SoLuongCC, cn.SoLuongTon 
from Kho_ChiNhanh k, ChiNhanh_SanPham cn
where k.MaChiNhanh = cn.MaCN and k.MaSP = cn.MaSP and month(NgayCC)=12

select * from ChiNhanh_SanPham

-- Thêm vào giỏ hàng sản phẩm Bỉm ABC có mã sản phẩm là 1055, có mã người mua là 100 với số lượng là 2
go
CREATE OR ALTER PROC TruyVan_Cau3 (
	@TenSP nvarchar(150), 
	@MaSP INT, 
	@MaKH INT, 
	@SoLuongSP INT)
AS 
BEGIN
	DECLARE @MaGioHang INT

	SET @MaGioHang = (SELECT MaGioHang FROM GIOHANG WHERE MaKH = @MaKH)

	IF(@SoLuongSP > (SELECT SoLuongCC FROM KHO_CHINHANH WHERE MaSP = @MASP))
	BEGIN
		PRINT('Oops, out of stock')
		RETURN
	END

	INSERT INTO GH_SP VALUES (@MaSP, @MaGioHang,@MaKH, @SoLuongSP,5000)

END
GO



USE [CUAHANGCHOBE]
GO
CREATE NONCLUSTERED INDEX INDEX_CAU3
ON [dbo].[GIOHANG] ([MaKH])

-- GO
-- DROP INDEX INDEX_CAU3 ON [dbo].[GIOHANG]

EXEC TruyVan_Cau3 'Bỉm ABC', 5000, 100000, 2


--Tìm kiếm sản phẩm Áo ABC trong chi tiết hóa đơn của khách hàng thanh toán bằng hình thức momo, có tổng tiền là hơn 1.000.000 đồng và thuộc chi nhánh có mã là 10.
CREATE OR ALTER PROC TruyVan_Cau4 (
	@TenSP nvarchar(150), 
	@HinhThucThanhToan nvarchar(20), 
	@TongTien float,
	@ChiNhanh int)
AS
BEGIN
	SELECT SP.*
	FROM SANPHAM SP, HOADON HD
	WHERE SP.TenSP = @TenSP
		AND HD.HinhThucThanhToan = @HinhThucThanhToan
		AND HD.TongTien > @TongTien
		AND HD.ChiNhanh  = @ChiNhanh
END
GO

-- INSERT INTO SANPHAM (MaSP, TenSP, GiaBan, GiaMua, DoiTac, LoaiSP, MaGG) VALUES (105700, N'Áo ABC', 100000, 20000, 1, N'Áo', 1)
-- INSERT INTO HOADON (MaHoaDon, NgayLap, PhiVanChuyen, PhiSanPham, TongTien, MaNS, MaKH, ChiNhanh, HinhThucThanhToan) VALUES (10560000, GETDATE(), 10000, 100000, 110000, 1, 100, 1, 'momo')

EXEC TruyVan_Cau4 'Áo ABC', 'momo', 1000000, 10


--Xem tình trạng các đơn hàng của khách hàng có mã ‘15235’ lập vào ngày ‘10/10/2021’  
--có hình thức thanh toán là “master card” và có mã đơn vị vận chuyển là 2.
CREATE OR ALTER PROC TRUYVAN_CAU5
	@MAKH CHAR(10),
	@NGAY DATETIME,
	@MADVVC CHAR(10)
AS
BEGIN
	SELECT TinhTrangDH
	FROM HOADON HD, PHIEUGIAOHANG PGH
	WHERE MAKH = @MAKH AND NgayLap = @NGAY AND HinhThucThanhToan = 'master card'
	AND PGH.MaHD = HD.MaHoaDon AND DonViVC = @MADVVC
END

EXEC TRUYVAN_CAU5 '15235', '2021-10-10', '2'

USE [CUAHANGCHOBE]
GO
CREATE NONCLUSTERED INDEX CAU5_1
ON [dbo].[PHIEUGIAOHANG] ([DonViVC])
INCLUDE ([TinhTrangDH],[MaHD])
GO

GO
CREATE NONCLUSTERED INDEX CAU5_2
ON [dbo].[HOADON] ([NgayLap],[MaKH],[HinhThucThanhToan])


GO
CREATE NONCLUSTERED INDEX CAU5_3
ON [dbo].[PHIEUGIAOHANG] ([DonViVC],[MaHD])
INCLUDE ([TinhTrangDH])




--Xem danh sách sản phẩm có sử dụng mức giảm giá có ngày bắt đầu là ‘24/12/2021’ 
--trong đơn hàng có tổng tiền lớn hơn 1.000.000 đồng của khách hàng có mã ‘30’.
GO
CREATE OR ALTER PROC TRUYVAN_CAU6
	@MAKH CHAR(10),
	@NGAY DATETIME
AS
BEGIN
	SELECT SP.MASP, TENSP
	FROM HOADON HD, CT_HOADON CT, SANPHAM SP, MucGiamGia GG
	WHERE HD.MAKH = @MAKH AND TongTien > '1000000'
	AND CT.MaHoaDon = HD.MaHoaDon
	AND CT.MaSP = SP.MaSP
	AND SP.MaGG = GG.MaGG AND GG.TGBatDau = @NGAY
END

EXEC TRUYVAN_CAU6 '30', '2021-12-24'



GO
CREATE NONCLUSTERED INDEX CAU6
ON [dbo].[HOADON] ([MaKH],[TongTien])

---Câu 7
--Tìm kiếm thông tin sản phẩm kèm theo tên đối tác của sản phẩm đó có mã chi nhánh là 5
go
create or alter proc TruyVan_Cau7 @MaCN int
as

Select sp.MaSP as Mã_SP,sp.TenSP as Tên_Sản_Phẩm,sp.GiaBan as Giá_Bán,sp.LoaiSP as Loại_Hàng,dt.TenDoiTac as Công_Ty 
from SanPham sp,DoiTac dt,ChiNhanh_SanPham cn
where sp.DoiTac = dt.MaDT and cn.MaCN = @MaCN and cn.MaSP = sp.MaSP
go

exec TruyVan_Cau7 5
GO
create NONCLUSTERED  INDEX CAU7
ON [dbo].[SanPham] ([MaSP],[TenSP])




