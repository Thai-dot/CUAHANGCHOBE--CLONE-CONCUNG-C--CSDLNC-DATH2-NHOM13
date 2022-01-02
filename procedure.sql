-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

--------PROC CHO KHACHHANG

-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

go 
--Dăng ký tài khoản mới
create or alter proc DangKy_KhachHang @TenDangNhap nvarchar(30), @MatKhau nvarchar(30), @HoTen nvarchar(50), @GioiTinh nvarchar(3),@SDT nvarchar(10), @NgaySinh date, @DiaChi nvarchar(50),@EmailKH char(40)
as
	declare @MaKH int;
	select @MaKH = max(MaKH) from KhachHang 
	set @MaKH = @MaKH +1;
	DECLARE @ID int;
	select @ID = max(ID) from TAIKHOAN
	set @ID = @ID +1;

	insert into KhachHang values(@MaKH, @HoTen,@SDT,@NgaySinh,@DiaChi,@GioiTinh,@EmailKH)

	insert into TAIKHOAN VALUES(@ID,@TenDangNhap,@MatKhau,@MaKH)
go


go
--Thêm sản phẩm vào giỏ hàng
create or alter proc ThemMotSPGioHang_KhachHang @MaKH int, @MaSP int, @SoLuongSP int, @ThanhTienGH float
as
	declare @MaGioHang int;
	set @MagioHang = 1;
	if not exists (select MaGioHang from GioHang where @MaKH = MaKH)
	begin
		insert into GioHang values(@MaGioHang,@MaKh,getdate())
	end
	else
	begin
		update GioHang
		set NgayThem = getdate()
		where @MaKh = MaKh and @MaGioHang = MaGioHang
	end

	if not exists (select MaSp from GH_SP where @MaKH = MaKH and @MaGioHang = MaGioHang and @MaSP = MaSP)
	begin 
	insert into GH_SP values(@MaSP, @MaGioHang,@MaKH,@SoLuongSP,@ThanhTienGH)

	end
	else
	begin
		update GH_SP
		set SoLuongSP = SoLuONGSP+ @sOlUONGsp 
		where @MaKH = MaKH and @MaGioHang = MaGioHang and @MaSP = MaSP
		update GH_SP
		set ThanhTienGH = ThanhTienGH + @ThanhTienGH
		where @MaKH = MaKH and @MaGioHang = MaGioHang and @MaSP = MaSP
	end

go

go
--update số lượng sp trong giỏ hàng
CREATE or alter proc update_Soluong_GHSP @MaSP int, @MaKH int, @SoLuongSP int
as
	declare @ThanhTien float;
	declare @GiaBan float;
	select @GiaBan = GiaBan from SanPham where @MaSP = MaSP;

	if @SoLuongSP <0
	begin
		return
	end
	if @SoLuongSP = 0
	begin
		delete from GH_SP where MaSP = @MaSP and MaKH = @MaKH and MagioHang=1
		return;
	end
	update GH_SP
	set SoLuongSP = @SoLuongSP, ThanhTienGH = cast(@SoLuongSP as float) * @GiaBan
	where MaSP = @MaSP and MaKH = @MaKH and MagioHang=1


go

go 
--Xóa 1 sản phẩm ra khỏi giỏ hàng
create or alter proc delete_SP_GH @MaSP int, @MaKH int, @SoLuongSP int
as
	delete from GH_SP where MaSP = @MaSP and MaKH = @MaKH and MagioHang=1
go


create or alter proc them_hoadon_KH @PhiVanChuyen int, @PhiSanPham int, @TongTien float, @MaKH int, @MaCN int, @HinhThucThanhToan nvarchar(20),
		@DiaChiGiao nvarchar(30), @MoTa nvarchar(50)
as


	declare @MagioHang int;
	set @MaGioHang =1;

	declare @MaHD int;
	select @MaHD = Max(MaHoaDon) from HoaDon;
	set @MaHD = @MaHD +1;
	--Tạo hóa đơn mới
	insert into HoaDon(MaHoaDon,NgayLap,PhiVanChuyen,PhiSanPham,TongTien,MaKH,ChiNhanh,HinhThucThanhToan) 
	values(@MaHD,getdate(),@PhiVanChuyen,@PhiSanPham,@TongTien,@MaKH,@MaCN,@HinhThucThanhToan)

	declare @Count int;
	select @Count = Count(MaSP) from gh_sp where  MaKH = @MaKH and Magiohang = @Magiohang
	while(@Count >0) --Vòng lặp để nhập các sản phẩm vào ct_donhang
	begin
			set @Count = @Count -1
			declare @MaSP int;
			declare @GiaBan float;
			declare @SoLuongSP int;
			declare @ThanhTienGH float;

			select top 1 @MaSP =  MaSP from gh_sp where @MaKH = MaKh and @MagioHang = 1
			select @GiaBan = GiaBan from sanpham where MaSP = @MaSP
			select top 1 @SoLuongSP = SoLuongSP from gh_sp where @MaKH = MaKh and @MagioHang = 1
			select top 1 @ThanhTienGH = ThanhTienGH from gh_sp  where @MaKH = MaKh and @MagioHang = 1

			--Kiểm tra sp đó có tồn tại trong chi nhánh
			if not exists (select MaSP from ChiNhanh_SanPham where @MaSP = MaSP and MaCN = @MaCN)
			begin
				declare @string nvarchar(50);
				set @string = N'Không tồn tại mã sp ' +cast(@MaSP as char)+N' này'
				raiserror(@string,16,1);
				rollback;
			end

			--Kiểm tra số lượng tồn sp trong chi nhánh
			declare @SoLuongTon int;
			select @SoLuongTon = SoLuongTon from ChiNhanh_SanPham where @MaCN = MaCN and MaSP = @MaSP
			set @SoLuongTon = @SoLuongTon - @SoLuongSP
			if @SoLuongTon <= 0 
			begin
				raiserror(N'Không thể mua vì số lượng đã hết',16,1);
				rollback;
			end

			--Thêm vào ct_donhang
			insert into CT_HoaDON values(@MaHD, @MaSP, @GiaBan, @SoLuongSP,@ThanhTienGH);
			delete from gh_sp where @MaSP = MaSP and @MaKH = MaKh and @MagioHang = 1

	end

	--Tạo phiếu giao hàng mới:
	declare @MaGH int;
	select @MaGH = Max(MaGH) from PhieuGiaoHang
	set @MaGH = @MaGH + 1;
	insert into PhieuGiaoHang values(@MaGH,null,N'chưa giao',@DiaChiGiao,null,@MaHD,@MoTa)

	--Tạo lịch sử mua hàng
	insert into LichSu_MuaHang values(@MaKH,@MaHD,@TongTien,getdate(),N'chưa giao') 

go

go	
--Chỉnh sửa thông tin khách hàng (họ tên, giới tính, ngày sinh,...)
create or alter procedure ChinhSua_ThongTin_KH @MaKH int, @HoTenKH nvarchar(50), @SDTKH nvarchar(10), @NgaySinhKH date,
			@DiaChiKH nvarchar(120), @GioiTinh nvarchar(3)
as
	if @HoTenKH is not null or @HoTenKH != '' --Cập nhật hoten
	begin
		update KhachHang
		set HoTenKH = @HoTenKH
		where @MaKH = MaKH
	end

	if @SDTKH is not null or @SDTKH !='' or len(@SDTKH) =10 --Cập nhật SDTKH
	begin
		update KhachHang
		set SDTKH = @SDTKH
		where @MaKH = MaKH
	end

	if @NgaySINHKH is not null or @NgaySINHKH !=''  --Cập nhật NgaySINH
	begin
		update KhachHang
		set NgaySINHKH = @NgaySINHKH
		where @MaKH = MaKH
	end

	if @DiaChiKh is not null or @DiaChiKH !=''  --Cập nhật diachi
	begin
		update KhachHang
		set DiaChiKh = @DiaChiKh
		where @MaKH = MaKH
	end

	if @GioiTinh is not null or @GioiTinh !=''  --Cập nhật gioi tinh
	begin
		update KhachHang
		set GioiTinh = @GioiTinh
		where @MaKH = MaKH
	end

	

go

--Cập nhật mật khẩu mới
create or alter proc capnhat_matkhau @MaKH int, @MatKhau char(30)
as

if @MatKhau is not null or @MatKhau !='' or len(@MatKhau)<5  --Cập nhật mật khẩu
	begin
		update TaiKhoan
		set MatKhau = @MatKhau
		where @MaKH = MaKH
	end
go

go
--Thêm sản phẩm yêu thích
create or alter proc themyeuthich_kh @MaKH int, @MaSP int, @MaDT int, @TenCongTy nvarchar(50), @TenSP nvarchar(50), @GiaBan float
as

	insert into KHACHHANG_YEUTHICH values(@MaKH,@MaSP,getdate(), @MaDT,@TenCongTy,@TenSP,@GiaBan)


go

go
--Xóa sản phẩm yêu thích
create or alter proc xoaspyeuthich_kh @MaKH int, @MaSP int
as

	delete from khachhang_yeuthich where makh = @MaKH and masp = @MaSP


go

go
create or alter proc capnhattreem_kh @MaKH int, @STTtre int, @HoTenBe nvarchar(50), @GioiTinhBe nvarchar(3), @NgaySinhBe date
as
	if not exists (select * from TreEm where MaKH = @MaKh and @STTtre = STT_TE)
	begin
		select @STTtre = Max(STT_TE) from TreEm where @MaKH = MaKH
		if @Stttre is null or @Stttre=0
		begin
			set @stttre = 1
		end
		else
		begin
			set @stttre = @stttre +1;
		end
		insert into TREEM values(@MaKH,@stttre,@HoTenBe,@GioiTinhBe,@NgaySinhBe)
	end
	else
	begin
		update TreEm
		set HoTenBe = @HoTenBe, GoiTinhBe = @GioiTinhBe, NgaySinhBe = @NgaySinhBe
		where @MaKH = MaKH and STT_TE = @STTtre
	end
go







-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

--------PROC CHO NHAN VIEN BAN HANG

-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

go
--Xác nhận đơn hàng đó có vận chuyển hay không hoặc đã giao
create or alter proc xacnhan_donhang_nv @MaHD int, @MaKH int, @MaNS int, @TrangThaiDonHang nvarchar(20),@DonViVC nvarchar(50)
as

--Kiểm tra tình trạng
	if @TrangThaiDonHang not in (N'Chưa giao',N'Đang Giao',N'Đã giao')
	begin
		raiserror('Nhập sai dữ liệu tình trạng đơn hàng',16,1);
		rollback;
		return;
	end

	update HoaDon 
	set MaNS = @MaNS
	where @MaHD = MaHoaDon

	declare @MaDV int;
	select @MaDV = MaDV from DONVIVANCHUYEN where TenDV = @DonVIVC

	update PhieuGiaoHang
	set DonViVC = @MaDV
	where MaHD = @MaHD

	update LichSu_MuaHang
	set NgayCapNhat = getdate(), TinhTrangDonHang = @TrangThaiDonHang
	where MaKH = @MaKH and @MaHD = MaHD


go

go
--Xoa Đơn Hàng không hợp lệ
create or alter proc xoadonhang_nv @MaHD int, @MaKH int, @MaCN int
as
	declare @count int;
	select @count = Max(MaSP) from CT_HOADON where @MaHD = MaHoaDon

	delete from PhieuGiaoHang
	where @MaHD = MaHD
	while @count > 0
	begin
		set @count = @count -1;
		declare @SoLuongSP int;
		declare @MaSp int;
		select top 1 @MaSP = MaSP from CT_HOADON where @MaHD = MaHoaDon
		select top 1 @SoLuongSP = SoLuong from CT_HOADON where @MaHD = MaHoaDon and @MaSP = MaSP

		update ChiNhanh_SanPham
		set SoLuongTon = SoLuongTon + @SoLuongSP
		where @MaCN = MaCN and MaSp = @MaSP

		delete FROM CT_HoaDon
		WHERE @mAhd = MaHoaDon and MaSp = @MaSP

	end

	
	DELETE FROM hoadon
	WHERE @mAhd = MaHOADON and @MaKH = mAkh

	update LichSu_MuaHang
	set NgayCapNhat = getdate(), TinhTrangDonHang = N'hủy đơn hàng'
	where MaKH = @MaKH and @MaHD = MaHD
	
go


go
--Proc dổi mật khẩu nhân sự
create or alter proc doimatkhau_nvbh @MaNS int, @MatKhauMoi char(30)
as
		
		update TK_NhanSU
		set MatKhauNS = @MatKhauMoi
		where @MaNS = MaNS

go

go
--Điểm danh nhân sự
create or alter proc diemdanh_nhansu @MaNS int
as
	declare @month int;
	declare @day int;
	declare @year int;

	set @month = month(getdate())
	set @day = day(getdate())
	set @year = year(getdate());
	
	declare @hour int;
	set @hour = datepart(hour,getdate());

	if @hour >=8 --Trừ luong 500000 nếu đi trễ 1 ngày
	begin
		update NhanSU
		set LuongNS = LuongNS - 500000
		where MaNS = @MaNS
	end

	if not exists (select *from DiemDanhNhanSu where MaNS = @MaNS and month(ngaydiemdanh) = @month and day(ngaydiemdanh) = @day and year(ngaydiemdanh) = @year)
	begin
		insert into DiemDanhNhanSU values(@MaNS,getdate());
	end
	else
	begin
		raiserror('Đã điểm danh rồi',16,1);
		rollback;
		return;
	end
go


-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

--------PROC CHO NHAN VIEN Quản lý

-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

--Tạo mức giảm giảm mới
go
create or alter proc taomucgiamgia_nv @NgayBD date, @NgayKT date, @MucGiam float
as
	if @NgayBD > @NgayKT
	begin
		raiserror(N'Ngày bắt đầu không thể lớn hơn ngày kết thúc',16,1)
		rollback;
		return;
	end

	if @MucGiam < 0 or @MucGiam >100
	begin
		raiserror(N'Mức giảm giá chỉ từ 0 --> 10',16,1)
		rollback;
		return;
	end
	declare @MaGG int;
	select @Magg = Max(MaGG) from MucGiamGia
	set @MaGG = @MaGG +1;
	insert into MucGiamGia values(@MaGG,@NgayBD,@NgayKT,@MucGiam);


go

--ÁP dụng mức giảm giá cụ thể cho sản phẩm
go
create or alter proc apdungmucgiamgia_ns @MaGG int, @MaSP int
as

	declare @NgayKT date;
	select @NgayKT = TGKetThuc from MucGiamGia where @MaGG = MaGG
	if @NgayKT > getdate()
	begin
		raiserror(N'Ngày hết hạn đã qua',16,1)
		rollback;
		return;
	end
	update SanPham
	set MaGG = @MaGG
	where @MaSP = MaSP
go

--Xóa mức giảm giá

go
create or alter proc xoamucgiamgia_sp @MaGG int
as

	delete from Mucgiamgia where @MaGG = MaGG
go

go
--CapNhât lại mức giảm giá
go
create or alter proc capnhatmucgiamgia_nv @MaGG int, @MucGiamGia float
as
	if @MucGiamGia < 0 and @MucGiamGia > 100
	begin
		raiserror(N'Mức giảm giá không hợp lệ',16,1)
		rollback;
		return;
	end
	update MucGiamGia
	set MucGiam = @MucGiamGia
	where @MaGG = MaGG

go

--Cập Nhật Theo Loai sp mức giảm giá
go
create or alter proc capnhatloaisp_mucgiamgia_nv @MaGG int, @LoaiSP nvarchar(50)
as
	update SanPham
	set MAGG = @MaGG
	where LoaiSp = @LoaiSP
go

--Cập nhật lương cho nhân viên bán hàng
go
create or alter proc capnhatluong_bh @MaNS int, @Luong float
as
	if @Luong < 1000000 or @Luong > 100000000
	begin
		raiserror(N'Mức lương không hợp lệ',16,1)
		rollback;
		return;
	end
	update NhanSu
	set LuongNS = @Luong
	where MaNS = @MaNS
go

--Cập Nhật/Tạo hợp đồng
go
create or alter proc kykethopdong_ql @MaDT int, @MaNS int, @MaHD int, @NgayLap date, 
	@NgayKT date, @MST nvarchar(8), @TinhTrang nvarchar(20)
as
	
	if len(@MST)!=8
	begin
		raiserror(N'Mã số thuế phải là 8 chữ số',16,1)
		rollback;
		return;
	end
	if DATEDIFF(day,@NgayLap,@NgayKt) < 30
	begin
		raiserror(N'Hợp đồng phải ít nhất 1 tháng',16,1)
		rollback;
		return;
	end
	if not exists (select MaHD from HOPDONG where MaHD = @MaHD)
	begin
		select @MaHD = Max(MaHD) from HopDong
		set @MaHD = @MaHD +1
		insert into HOPDONG values(@MaHD,@NgayLap,@NgayKT,@MST,@TinhTrang,@MaDT,@MaNS);
	end
	else
	begin
		update HOPDONG
		set	NgayLapHD = @NgayLap,  NgayDenHan=@NgayKT, MaSothue=@MST, TinhTrangHopdONG = @TinhTrang
		where @MaHD = MaHD
	end
go

-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

--------PROC CHO ADMIN

-----------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------

go
--Thêm/Sửa sản phẩm
create or alter proc themsuasanpham_admin @MaSP int, @TenSp nvarchar(50), @GiaBan float, 
		@GiaMua float,@DoiTac int,@LoaiSP nvarchar(30),@MaGG int
as
	if not exists(select MaSP from SanPham where MaSP = @MaSP)
	begin
		select @MaSp = Max(MaSp) from SanPham
		set @MaSP = @MaSP + 1;
		insert into SanPham values(@MaSP,@TenSP,@GiaBan,@GiaMua,@DoiTac,@LoaiSP,@MaGG);
	end
	else
	begin
		update SanPham
		set	TenSP = @TenSP,GiaBan = @GiaBan,GiaMua = @GiaMua,DoiTac=@DoiTac,LoaiSP = @LoaiSP
		where MaSP = @MaSP
	end
go

go
--Xóa 1 sản phẩm
create or alter proc xoasanpham_admin @MaSP int
as
	delete from SanPham where @MaSP =MaSP
go

GO
--Sửa nhân viên (cả bán hàng và quản lý)
create or alter proc suanhanvien_admin @MaNS int, @HoTen nvarchar(50), @DiaChiNS nvarchar(10), @SDTNS char(10), 
	@LuongNS float, @ChiNhanhLamViec int, @LoaiNS nvarchar(20)
as
	IF NOT EXISTS (SELECT * FROM NhanSu WHERE @Mans = mans)
	BEGIN
		raiserror(N'Không tồn tại nhân sự',16,1)
		rollback;
		return;
	END
	if len(@SDTNS) !=10
	begin
		raiserror(N'SDT không 10 số',16,1)
		rollback;
		return;
	end
	update NhanSu
	set  HoTenNS = @HoTen , DiaChiNS = @DiaChiNS ,  SDTNS=@SDTNS, LuongNS=@LuongNS, ChiNhanhLamViec = @ChiNhanhLamViec, LoaiNS = @LoaiNS
	where @MaNS = MaNS
	
go

--Xóa nhân viên
create or alter proc xoanhanvien_admin @MaNS int
as
	if not exists(select * from NhanSu where @MaNS = MaNS)
	begin
		raiserror(N'Không tồn tại nhân sự',16,1)
		rollback;
		return;
	end
	delete from nhansu where @MaNS = MaNS
go

--Tạo nhân viên mới
go
create or alter proc taonhanvien_admin @HoTen nvarchar(50), @DiaChiNS nvarchar(10), @SDTNS char(10), 
	@LuongNS float, @ChiNhanhLamViec int, @LoaiNS nvarchar(20),@TenDN char(30),@MatKhau char(30)
as
	if len(@SDTNS) !=10
	begin
		raiserror(N'SDT không 10 số',16,1)
		rollback;
		return;
	end
	declare @MaNS int;
	select @MaNS = MAX(mAns) FROM NhanSU
	set @MaNS = @MaNS +1;
	declare @ID int;
	select @ID = Max(id) from tk_nhansu
	set @ID = @ID +1;


	insert into NhanSU values(@MaNS,@hOtEN,@dIAcHIns,@sdtns,@lUONGns,@cHInHANHlAMvIEC,@lOAIns)

	INSERT INTO TK_NHANSU VALUES(@ID,@TENDN,@MATKHAU,@MANS)

go

---
go
--Sửa đối tac
create or alter proc suadoitac_admin @MaDT int, @TenDT nvarchar, @DiaChiDT nvarchar(50),@SDT nvarchar(10),@Email_DT nvarchar(100)
as
	IF NOT EXISTS (SELECT * FROM DOITAC WHERE @MADT = MADT)
	BEGIN
		raiserror(N'Không tồn tại đối tác',16,1)
		rollback;
		return;
	END
	if len(@SDT) != 10
	begin
		raiserror(N'SDT không 10 số',16,1)
		rollback;
		return;
	end
	update DOITAC
	SET	TENDOITAC = @TENDT, DIACHIDT = @DIACHIDT, SDT_DT = @SDT, EMAIL_DT = @EMAIL_DT
	WHERE @mAdt = mAdt
go

go
--Xóa Đối Tác
create or alter proc xoadoitac_admin @MaDT int
as
	if not exists(select * from doitac where @MaDT = MaDT)
	begin
		raiserror(N'Không tồn tại đối tác',16,1)
		rollback;
		return;
	end
	delete from DoiTac where MaDT = @MaDT
go

--Tạo Đối Tác mới
create or alter proc taodoitac_admin  @TenDT nvarchar, @DiaChiDT nvarchar(50),@SDT nvarchar(10),@Email_DT nvarchar(100)
as
	declare @MaDT int;
	select @MaDt = Max(MaDT) from doitac
	set @MaDt = @MaDt +1;

	if len(@SDT) != 10
	begin
		raiserror(N'SDT không 10 số',16,1)
		rollback;
		return;
	end
	insert into DOITAC values(@MaDT,@TenDT,@DiaChiDT,@SDT,@Email_DT)
go

---Tạo Kho Mới
create or alter proc taokhomoi_admin @TenKho nvarchar(30), @DiaChiKho nvarchar(30), @SDTKho char(10)
as

	declare @MaKho int;
	select @MaKho = Max(MaKho) from Kho
	set @MaKho = @MaKho +1;

	insert into Kho values(@MaKho,@TenKho,@DiaChiKho,@SDTKho);

go

--Xóa Kho
go
create or alter proc xoakho_admin @MaKho int
as

	if not exists (Select * from Kho where @MaKho = MaKho)
	begin
	raiserror(N'Không tồn tại mã kho',16,1)
		rollback;
		return;
	end

	delete from Kho where @MaKho = MaKho

go
--Sửa Kho
create or alter proc suakho_admin @MaKho int, @TenKho nvarchar(30), @DiaChiKho nvarchar(30), @SDTKho char(10)
as

	if not exists (Select * from Kho where @MaKho = MaKho)
	begin
	raiserror(N'Không tồn tại mã kho',16,1)
		rollback;
		return;
	end

	update Kho
	set TenKho = @TenKho, DiaChiKho = @DiaChiKho, SDTKho = @SDTKho
	where @MaKho = MaKho

go

--Cung cấp sản phẩm từ đối tác sang kho
create or alter proc cungcapDoiTac_Kho_admin @MaKho int, @MaDT int, @MaSP int, @SoLuong int
as

	insert into Kho_DoiTac values(@MaKHO,@MaDt,getdate(),@MaSP,@SoLuong)

	if not exists (select * from Kho_SanPham where @MaKho = MaKHo and @MaSP = @MaSP)
	begin
		
		insert into Kho_SanpHAM VALUES(@mAkHO,@mAsp,@SOLUONG)
	end
	else
	begin
		update Kho_SanPham
		set SLSP = SLSP + @SoLuong
		where @Makho = MaKho and @MaSP = MaSP
	end

go

--Cung cấp sản phẩm cho chi nhánh
go
create or alter proc cungcapSanPham_ChiNhanh_admin @MaKho int, @MaCN int, @MaSP int, @SoLuong int
as
	if not exists (select * from Kho where @MaKHo = MaKho)
	begin
		raiserror(N'Không tồn tại mã kho',16,1)
		rollback;
		return;
	end	
	if not exists (select * from SanPham where @MaSP = MaSP)
	begin
		raiserror(N'Không tồn tại mã sản phẩm',16,1)
		rollback;
		return;
	end	
	if not exists (select * from Kho_SanPham where @MaSP = MaSP and MaKho = @MaKho)
	begin
		raiserror(N'Không tồn tại sản phẩm này trong kho',16,1)
		rollback;
		return;
	end

	update Kho_SanPham
	set	SLSP = SLSP - @SoLuong
	where @MaKho = MaKho and MaSP = @MaSP
	declare @checkSL int;
	select @CHECKsl = SLSP FROM KHO_SANPHAM where @MaKho = MaKHo and @MaSP = MaSP
	if @CheckSL < 0
	begin
		declare @string nvarchar(50);
				set @string = N'Thiếu số lượng để cung cấp: ' +cast(@checksl as char)
				raiserror(@string,16,1)
		rollback;
		return;
	end

		insert into Kho_cHInHANH VALUES(@MaKho,@MaCN,getdate(),@MaSP,@SoLuong)

		if not exists(select * from ChiNhanh_SanPham where @MaCN = MaCN and @MaSP = MaSP)
		begin
			insert into ChiNhanh_SanPham values(@MaCN,@MaSP,@SoLuong);
		end
		else
		begin
			update ChiNhanh_SanPham
			set SoLuongTon = SoLuongTon + @SoLuong
			where @MaCN = MaCN and @MaSP = MaSP
		end
		
go

---Them DVVC vào database
go
create or alter proc themdonvivc_admin @TenDV nvarchar(50), @EmailDV nvarchar(127), @SDT_DV nvarchar(10)
as
	declare @MaDV int;
	select @MaDV = Max(MaDV) from DONVIVANCHUYEN
	set @MaDV = @MaDV +1;
	insert into DonViVanChuyen values(@MaDV,@TenDV,@EmailDv,@sdt_dv)

go

--sỬA ĐƠN VỊ
go
create or alter proc suadonvivc_admin @MaDV int, @TenDV nvarchar(50), @EmailDV nvarchar(127), @SDT_DV nvarchar(10)
as
	if not exists(select * from DONVIVANCHUYEN where @MaDV = MaDV)
	begin
		raiserror(N'Không tồn tại mã đơn vị',16,1)
		rollback;
		return;
	end
	update DONVIVANCHUYEN
	set	TenDV = @TenDV, EmailDV = @EmailDV, SDT_DV = @SDT_DV
	where @MaDV = MaDV

go

--Xóa đơn vị
go
create or alter proc xoadonvi_admin @MaDV int
as
	delete from DONVIVANCHUYEN where @MaDV = MaDV
go