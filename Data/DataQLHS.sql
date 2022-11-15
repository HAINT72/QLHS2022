/*--------------------------------------------
           Tạo DATABASE và TABLE
--Trước khi chạy script này, phải thực hiện:
-- (1) Đổi tên Database
-- (2) Kiểm tra các dữ liệu đưa vào trước
----------------------------------------------*/

/* 
CREATE DATABASE [ (1)... tên data]
GO
USE [(1) ... tên data]
GO
*/

-- Tạo Table
CREATE TABLE dbo.tNhanVien
(
	MSNV NVARCHAR(12) PRIMARY KEY,
	HOTEN NVARCHAR(50) NOT NULL DEFAULT N'new user',	
	QUYENTRUYCAP NVARCHAR(2) NOT NULL DEFAULT 'NV',
	EMAIL NVARCHAR(50) NULL,
	PASSWORD NVARCHAR(MAX) NOT NULL DEFAULT '2003011414115776479911161271372042013444',
	HIEULUC BIT DEFAULT 1
)
GO

CREATE TABLE dbo.tLoaiCV
(
	MSLOAICV INT PRIMARY KEY IDENTITY(1,1),
	LOAICV NVARCHAR(max) NOT NULL DEFAULT N'Chưa xác định',
	MSLOAICVSAVE INT NULL
)
GO

CREATE TABLE dbo.tGiaiDoan
(
	MSGIAIDOAN INT PRIMARY KEY IDENTITY(1,1),
	GIAIDOAN NVARCHAR(max) NOT NULL DEFAULT N'Chưa xác định',
	MSCVGOC NVARCHAR(20) NULL
)
GO

CREATE TABLE dbo.tCoQuan
(
	MSCQ INT PRIMARY KEY IDENTITY(1,1),
	TENCQ NVARCHAR(MAX) NOT NULL DEFAULT N'Chưa xác định',
	MSCQSAVE INT NULL
)
GO

CREATE TABLE dbo.tDuoiCV
(
	MSDUOICV INT PRIMARY KEY IDENTITY(1,1),
	DUOICV NVARCHAR(MAX) NOT NULL DEFAULT N'CV ĐI'
)
GO

CREATE TABLE dbo.tCongVan
(
	MSCV NVARCHAR(20) PRIMARY KEY,
	SOCV NVARCHAR(255) NOT NULL,
	NGAYCV DATE NOT NULL DEFAULT GETDATE(),
	NOIDUNG NVARCHAR(MAX) NULL,
	NOIDUNG_Unsign NVARCHAR(MAX) NULL,
	MSNV NVARCHAR(12) NOT NULL DEFAULT 'haint',
	MSLOAICV INT NOT NULL DEFAULT 1,
	MSCQ INT NOT NULL DEFAULT 1,
	MSGIAIDOAN INT NOT NULL DEFAULT 1,
	MSCVCHA NVARCHAR(20) NULL,
	FILEPDF NVARCHAR(20) NULL,
	FILEOFFICE NVARCHAR(20) NULL,
	FILERAR NVARCHAR(20) NULL,
	PHEDUYET BIT DEFAULT 0,	
	FOREIGN KEY (MSNV) REFERENCES dbo.tNhanVien(MSNV) ON DELETE CASCADE,
	FOREIGN KEY (MSLOAICV) REFERENCES dbo.tLoaiCV(MSLOAICV) ON DELETE CASCADE,
	FOREIGN KEY (MSCQ) REFERENCES dbo.tCoQuan(MSCQ) ON DELETE CASCADE,
	FOREIGN KEY (MSGIAIDOAN) REFERENCES dbo.tGiaiDoan(MSGIAIDOAN) ON DELETE CASCADE
)
GO
CREATE INDEX indexNgayCV ON dbo.tCongVan(NGAYCV)
GO

CREATE TABLE dbo.tGiaoViec
(
	MSCVGIAOVIEC NVARCHAR(20),
	MSNVGIAOVIEC NVARCHAR(12),
	CHIDAO NVARCHAR(MAX) NULL,
	NGAYGIO DATETIME,
	THONGBAO BIT DEFAULT 1,
	CONSTRAINT PK_tGiaoViec PRIMARY KEY(MSCVGIAOVIEC,MSNVGIAOVIEC),
	FOREIGN KEY (MSNVGIAOVIEC) REFERENCES dbo.tNhanVien(MSNV),
	FOREIGN KEY (MSCVGIAOVIEC) REFERENCES dbo.tCongVan(MSCV) ON DELETE CASCADE
)
GO

CREATE TABLE dbo.tDangNhap
(
	MSNVLOGIN NVARCHAR(12),
	NGAYGIOVAO DATETIME NOT NULL DEFAULT GETDATE(),
	NGAYGIORA DATETIME NULL	
)
GO

CREATE TABLE dbo.tThongSo
(
	MSTS NVARCHAR(12) PRIMARY KEY,
	NOIDUNG NVARCHAR(MAX) NULL,
	STR_DATA NVARCHAR(MAX) NOT NULL,
	STR_PATH NVARCHAR(MAX) NOT NULL,
	HIEULUC BIT DEFAULT 0
)
GO

--Tạo Trigger
CREATE TRIGGER dbo.trgNhanVienDelete ON dbo.tNhanVien FOR DELETE 
AS
BEGIN
	DELETE FROM dbo.tGiaoViec WHERE MSNVGIAOVIEC IN (SELECT MSNV FROM Deleted)
END
GO

-- Insert tNhanVien
INSERT INTO dbo.tNhanVien (MSNV, HOTEN, QUYENTRUYCAP, EMAIL, PASSWORD, HIEULUC)
VALUES (N'haint', N'Ngô Thanh Hải', N'AD', N'ngothanhhai1972@gmail.com', N'2003011414115776479911161271372042013444', 1)
GO

-- Insert tGiaiDoan
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Lập, thẩm định BCNCTKT, quyết định chủ trương đầu tư')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Lập, thẩm định BCNCKT, phê duyệt dự án')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Lựa chọn nhà đầu tư')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Thành lập doanh nghiệp dự án PPP và ký kết hợp đồng dự án PPP')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Chuẩn bị mặt bằng xây dựng (Thực hiện hợp đồng PPP)')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Lập, thẩm định, phê duyệt thiết kế sau TKCS (Thực hiện hợp đồng PPP)')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Lựa chọn nhà thầu thực hiện dự án PPP (Thực hiện hợp đồng PPP)')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Quản lý, giám sát chất lượng công trình (Thực hiện hợp đồng PPP)') 
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Quyết toán vốn đầu tư công trình (Thực hiện hợp đồng PPP)') 
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Xác nhận hoàn thành công trình (Thực hiện hợp đồng PPP)') 
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Quản lý, vận hành, kinh doanh công trình (Thực hiện hợp đồng PPP)')
INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (N'Chuyển giao công trình, thanh lý hợp đồng (Thực hiện hợp đồng PPP)')
GO

--Insert tThongSo
INSERT INTO dbo.tThongSo (MSTS, STR_DATA, STR_PATH, HIEULUC, NOIDUNG)
VALUES (N'QLHS_HP', N'Data Source=192.168.1.222,1433;Initial Catalog=QLHS_HP;Persist Security Info=True;User ID=BOT.HP;Password=hp12345', N'\\192.168.1.222\QLHS\PDF FILE\BOT.HP', 1, N'Dự án PPP ven biển Hải Phòng - Thời gian từ 2018-2022')

INSERT INTO dbo.tThongSo (MSTS, STR_DATA, STR_PATH, HIEULUC, NOIDUNG)
VALUES (N'QLHS_HP_BDH', N'Data Source=192.168.1.222,1433;Initial Catalog=QLHS_HP_BDH;Persist Security Info=True;User ID=BOT.HP.BDH;Password=hpbdh12345', N'\\192.168.1.222\QLHS\PDF FILE\BOT.HP-BDH', 1, N'Dự án PPP ven biển Hải Phòng (Nhà thầu) - Thời gian từ 2018-2022')

INSERT INTO dbo.tThongSo (MSTS, STR_DATA, STR_PATH, HIEULUC, NOIDUNG)
VALUES (N'QLHS_DN', N'Data Source=192.168.1.222,1433;Initial Catalog=QLHS_DN;Persist Security Info=True;User ID=BOT.DN;Password=dn12345', N'\\192.168.1.222\QLHS\PDF FILE\BOT.DN', 1, N'Dự án BOT cầu Đồng Nai mới và tuyến hai đầu cầu - Thời gian từ 2008-2018')

INSERT INTO dbo.tThongSo (MSTS, STR_DATA, STR_PATH, HIEULUC, NOIDUNG)
VALUES (N'QLHS_AH', N'Data Source=192.168.1.222,1433;Initial Catalog=QLHS_AH;Persist Security Info=True;User ID=BOT.AH;Password=ah12345', N'\\192.168.1.222\QLHS\PDF FILE\ANHAO', 1, N'Dự án BOT  cầu Đồng Nai mới và tuyến hai đầu cầu (cầu An Hảo) - Thời gian từ 2016-2018')

GO
--Insert tCoQuan
INSERT INTO dbo.tCoQuan (TENCQ) VALUES (N'_CHƯA XÁC ĐỊNH') -- TENCQ - nvarchar(50)
GO

--Insert tDuoiCV
INSERT INTO dbo.tDuoiCV (DUOICV) VALUES (N'_CV ĐẾN') -- DUOICV - nvarchar(max)
GO

INSERT INTO dbo.tDuoiCV (DUOICV) VALUES (N'_CHƯA XÁC ĐỊNH') -- DUOICV - nvarchar(max)
GO

--Insert tLoaiCV
INSERT INTO dbo.tLoaiCV (LOAICV) VALUES (N'_CHƯA XÁC ĐỊNH') -- LOAICV - nvarchar(50)
GO