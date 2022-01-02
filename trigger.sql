

go
create or alter trigger TinhThanhTienCT_TongTienHD on CT_HOADON after insert,update
as 
begin
	declare @MaHD as int;
	declare @MaSP as int;
	declare @SL as int;
	declare @GiaBan as float;
	declare @ThanhTien as float;	
	declare @MucGiamGia as int;
	select @MucGiamGia = mgg.MucGiam from SanPham sp, MucGiamGia mgg where sp.MaGG = mgg.MaGG 
	select @GiaBan =  sp.GiaBan FROM SanPham sp, inserted I WHERE sp.MaSP = I.MaSP

	SELECT 
		@MaHD = I.MaHoaDon,
		@MaSP = I.MaSP,
		@SL = I.Soluong,
		@ThanhTien = I.Soluong * @GiaBan --Tính thành tiền = số lượng * đơn giá
	FROM inserted I;

	declare @ChiNhanh int;
	select @ChiNhanh = ChiNhanh from HOADON where @MAHD = MaHoaDon
	--Kiểm tra sản phẩm mua có trong chi nhánh hay là không
	if not exists (select MaSP from ChiNhanh_SanPham where @Chinhanh = MaCN and @MaSP = MaSP)
	begin 
		raiserror(N'Sản phẩm không tồn tại trong chi nhánh này',16,1) rollback;
	end

	---Kiểm tra số lượng sản phẩm trong chi nhánh
	
	declare @SoLuongTon int;

	select @SoluongTon = SoLuongTon from Chinhanh_Sanpham where @ChiNhanh = MaCN and @MaSP = MaSP
	
	if @SoluongTon - @SL <0
	begin
		raiserror(N'Không thể thanh toán vì số lượng sản phẩm trong chi nhánh đã hết',16,1); rollback

	end

	update Chinhanh_Sanpham --Cập nhật lại số lượng tồn
	set SoLuongTon = @SoLuongTon - @SL
	where @ChiNhanh = MaCN and @MaSP = MaSP


	if exists (select MaHoaDon, MaSP from CT_HOADON where MaHoaDon = @MaHD and MaSP = @MaSP)
	begin
		UPDATE CT_HOADON 
		SET ThanhTien = @ThanhTien, GiaBan = @GiaBan * (100-@MucGiamGia)/100 --Gán ThanhTien va DonGia vào bảng
		WHERE MaHoaDon = @MaHD and MaSP = @MaSP
	end
	else 
	begin
		set @GiaBan = @GiaBan * (100-@MucGiamGia)/100
		insert into CT_HOADON values (@MaHD, @MaSP,@GiaBan , @SL , @ThanhTien)
	end

	--Sau khi update CT_HoaDON xong sẽ update Phí sản phẩm, Phí vận chuyển trong bảng HOADON
	declare @PhiSanPham float;
	declare @PhiVanChuyen float;
	select @PhiSanPham = SUM(ct.ThanhTien) from CT_HOADON ct where ct.MaHoaDon = @MaHD
	set @PhiVanChuyen = 30000

	if @PhiSanPham >= 99000 and @PhiSanPham <299000
	begin
		set @PhiVanChuyen = 20000
	end

	if @PhiSanPham >= 299000 and @PhiSanPham <=599000
	begin
		set @PhiVanChuyen = 10000
	end
	if @PhiSanPham >= 599000
	begin
		set @PhiVanChuyen = 0
	end
	
	UPDATE HOADON --Ta update PhiSanPham = cách sum(ThanhTien) trong bảng ctdondathang
	SET PhiSanPham = @PhiSanPham --PhiSanPham = sum(ThanhTien) trong bang CTDONDATHANG
	WHERE MaHOADON = @MaHD

	UPDATE HOADON --Ta update PhiVanChuyen
	SET PhiVanChuyen = @PhiVanChuyen
	WHERE MaHOADON = @MaHD

	update HOADON
	set TongTien  = PhiSanPham + PhiVanChuyen, NgayLap = getdate() --TongTien = phí sản phẩm + phí vận chuyển
	where MAHOADON = @MaHD
	
end

go
create or alter trigger CapNhat_SLSP on Kho_ChiNhanh --Cập nhật số lượng sản phẩm tồn cho chi nhánh
after insert, update
as
begin
	declare @MaSP int;
	declare @MaCN int;
	declare @SoLuongCC int;
	declare @MaKho int;

	select
		@MaSP = I.MaSP,
		@MaCN = I.MaChiNhanh,
		@SoLuongCC = I.SoLuongCC,
		@MaKho = I.MaKho
		from inserted I

	declare @SoLuongTrongKho int;
	select @SoLuongTrongKho = SLSP from Kho_SanPham where @MaSP =MaSP and @MaKho = MaKho--Kiểm tra số lượng sản phẩm trong kho
	if @SoLuongTrongKho - @SoLuongCC <0
	begin
		raiserror(N'Số lượng cung cấp trong kho không đủ',16,1) rollback;
	end	
	if exists (select MaSP from ChiNhanh_SanPham where @MaCN = MACN) --Kiểm tra sản phẩm đó có tồn tại trong chi nhánh hay chưa
	--Nếu rồi thì cập nhật số lượng
	begin
		update ChiNhanh_SanPham
		set SoLuongTon = SoLuongTon + @SoLuongCC
		where @MaCN = MaCN and @MaSP = MaSP
	end
	else
	begin
		insert ChiNhanh_SanPham values(@MaCN,@MaSP, @SoLuongCC)
	end

end

go
create or alter trigger KT_MaSP_MaDT on KHO_DOITAC after insert, update --Kiểm tra mã sản phẩm mà đối tác cung cấp có đăng ký hay chưa
as
begin
	declare @MaKho int;
	declare @MaDT int;
	declare @MaSP int;
	declare @SoLuongCC int

	select 
		@MaKho = I.MaKHO,
		@MaDT = I.MaDT,
		@MaSP = I.MaSP,
		@SoLuongCC = I.SoLuongCC
		FROM inserted I
	
	if not exists (select MaSP from SANPHAM where @MaSP = MaSP and @MaDT =DoiTac)
	begin
		raiserror(N'Không thể cập nhật vì sản phẩm chưa đăng ký cho công ty',16,1) rollback
	end

	if not exists (select DoiTac from SANPHAM where @MaSP = MaSP and @MaDT =DoiTac)
	begin
		raiserror(N'Không thể cập nhật vì đối tác chưa đăng ký sản phẩm cho công ty',16,1) rollback
	end

	--Nếu đúng hết sẽ được đưa vào kho
	if exists (select MaKho, MaSP from Kho_SanPham where @MaKho = MaKho and @MaSP = MaSP)
	begin
		update Kho_SanPham
		set SLSP = SLSP + @SoLuongCC
		where @MaSP = MaSP and @MaKho = MaKho	
	end
	else
	begin
		insert into Kho_SanPham values(@MaKho,@MaSP,@SoLuongCC)
	end

end

go
create or alter trigger KT_HOPDONG on HOPDONG --Kiểm tra nhân sự có phải là nhân viên quản lý
after insert,update
as
begin
	declare @MaHD int;
	declare @NgayDenHan date;
	declare @MaNS int;

	select 
		@MaHD = I.MaHD,
		@NgayDenHan = I.NgayDenHan,
		@MaNS = I.MaNS
		from inserted I

	declare @NgayHomNay date;
	set @NgayHomNay = getdate()

	if @NgayHomNay > @NgayDenHan --Cập nhật lại tình trạng hợp đồng
	begin
		update HOPDONG
		set TinhTrangHopDong = N'Hết hạn'
		where @MaHD = MaHD
	end

	declare @LoaiNS nvarchar(30)
	select @LoaiNS = LoaiNS from NhanSU where @MaNS = MaNS
	if @LoaiNS != N'Quản Lý'
	begin
		raiserror(N'Nhân viên ký kết hợp đồng phải là quản lý',16,1) rollback;
	end

end

go
create trigger KT_NgayGiaoHang on PHIEUGIAOHANG after insert, update
as
begin
	declare @MaGH int;
	declare @MaHD int;
	declare @NgayGiao date;
	declare @NgayLap date;

	
	select 
		@MaGH = I.MaGH,
		@MaHD = I.MAHD,
		@NgayGiao = I.NgayGiao
	from
		inserted I 
	if not exists (select MaGH,MaHD from PHIEUGIAOHANG where MaGH = @MaGH and MaHD = @MaHD)
	begin
		raiserror(N'Nhập sai',16,1) ROLLBACK;
		return;
	end

	select @NgayLap = NgayLap from HOADON where MaHOADON = @MaHD
	print @NgayLap
	print @NgayGiao
	if @NgayLap > @NgayGiao
	begin
		RAISERROR(N'Ngày lập phải sau ngày giao',16,1); ROLLBACK;
	end

end








