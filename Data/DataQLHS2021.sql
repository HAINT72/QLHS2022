﻿--Tạo DATABASE và USE Database
--Trước khi chạy script này, phải thực hiện :
-- (1) Đổi tên Database
-- (2) Kiểm tra các dữ liệu đưa vào trước

CREATE DATABASE QLHS_HP_BDH
GO
USE QLHS_HP_BDH
GO
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
go
--Tạo Procudure
CREATE PROC USP_Login @stMSNV NVARCHAR(12) = NULL, @stPassWord NVARCHAR(MAX) = NULL
AS
BEGIN
	IF ((@stMSNV IS NOT NULL) AND  (@stPassWord IS NOT NULL))
		SELECT MSNV FROM dbo.tNhanVien WHERE MSNV=@stMSNV AND PASSWORD=@stPassWord AND HIEULUC=1
END
GO
CREATE PROC USP_CapnhatMatkhau @stMSNV NVARCHAR(12), @stPassWord NVARCHAR(MAX)
AS
BEGIN
	IF ((@stMSNV IS NOT NULL) AND  (@stPassWord IS NOT NULL))
		UPDATE dbo.tNhanVien SET PASSWORD=@stPassWord WHERE MSNV=@stMSNV
END
GO

CREATE PROC USP_CopyFileBySQL @stFileSource NVARCHAR(MAX), @stFileDest NVARCHAR(MAX)
AS
BEGIN
	-- Bật chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'show advanced options', 1
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'xp_cmdshell', 1
	RECONFIGURE WITH OVERRIDE
	--Copy file
	DECLARE @cmd NVARCHAR(4000)
	SET @cmd = N'copy ' + N'"'+ @stFileSource + N'" "' +  @stFileDest + N'"'
	EXEC xp_cmdshell @cmd, no_output
	-- Tắt chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'xp_cmdshell', 0
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'show advanced options', 0
	RECONFIGURE WITH OVERRIDE
END
GO

CREATE PROC USP_RenameFileBySQL @stPathFileFull NVARCHAR(MAX), @stFileName NVARCHAR(MAX)
AS
BEGIN
	-- Bật chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'show advanced options', 1
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'xp_cmdshell', 1
	RECONFIGURE WITH OVERRIDE
	--Rename file
	DECLARE @cmd NVARCHAR(4000)
	SET @cmd = N'rename ' + N'"'+ @stPathFileFull + N'" "' +  @stFileName + N'"'
	EXEC xp_cmdshell @cmd, no_output
	-- Tắt chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'xp_cmdshell', 0
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'show advanced options', 0
	RECONFIGURE WITH OVERRIDE
END
GO

CREATE PROC USP_DeleteFileBySQL @stPathFileFull NVARCHAR(MAX)
AS
BEGIN
	-- Bật chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'show advanced options', 1
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'xp_cmdshell', 1
	RECONFIGURE WITH OVERRIDE
	--Delete file
	DECLARE @cmd NVARCHAR(4000)
	SET @cmd = N'del /F ' + N'"'+ @stPathFileFull + N'"'
	EXEC xp_cmdshell @cmd, no_output
	-- Tắt chế độ sử dụng lệnh xp_cmdshell
	EXEC master.dbo.sp_configure 'xp_cmdshell', 0
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'show advanced options', 0
	RECONFIGURE WITH OVERRIDE
END
GO

alter PROC USP_ExportData
-- Xuất dữ liệu ra file
-- Ví dụ: exec USP_ExportData 'select * from [qlhs_hp].dbo.tCongVan', 'd:\t1.xls', 'sa', 'nth12345'
	@stQueryWithDatabaseName NVARCHAR(MAX), 
	@stPathFileName NVARCHAR(MAX),
	@stUserName NVARCHAR(MAX),
	@stPassword NVARCHAR(MAX)
AS
BEGIN
	-- show advanced options
	EXEC master.dbo.sp_configure 'show advanced options', 1
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'xp_cmdshell', 1
	RECONFIGURE WITH OVERRIDE

	--Export Data
	DECLARE @sql nvarchar(4000)	
	SET @sql = 'bcp "' + @stQueryWithDatabaseName + '" queryout "' + @stPathFileName + '" -w -S "' + @@SERVERNAME + '" -U ' + @stUserName + ' -P ' + @stPassword
	exec master..xp_cmdshell @sql

	-- hide xp_cmdshell
	EXEC master.dbo.sp_configure 'xp_cmdshell', 0
	RECONFIGURE WITH OVERRIDE
	EXEC master.dbo.sp_configure 'show advanced options', 0
	RECONFIGURE WITH OVERRIDE
END
GO

ALTER PROC USP_ThemCongvan 
	@stFirstMSCV NVARCHAR(1) ='F',
	@stSOCV NVARCHAR(50) = '',
	@stNOIDUNG NVARCHAR(MAX) = '',
	@dNGAYCV DATE = NULL,
	@stMSNV NVARCHAR(12)= '',
	@iMSLOAICV INT =1,
	@iMSCQ INT =1,
	@iMSGIAIDOAN INT = 1,
	@stMSCVCHA NVARCHAR(20) = '',
	@stPATHSERVER NVARCHAR(MAX) = '',
	@stFILEPDF NVARCHAR(MAX) = '',
	@stFileOFFICE NVARCHAR(MAX) = '',
	@stFileRAR NVARCHAR(MAX) = ''	
AS
BEGIN	
	DECLARE @stMSCV NVARCHAR(20)	
	SET @stMSCV = dbo.fTaoMSCV(@stFirstMSCV, @dNGAYCV)
	DECLARE @stFILE_DEST NVARCHAR(MAX)

	--IF (@stFILEPDF <> '')
	--BEGIN
		DECLARE @stFILEPDF_ON_DATA NVARCHAR(20)		
		SET @stFILEPDF_ON_DATA = LTRIM(@stMSCV) + dbo.fGetExtFileName(@stFILEPDF)

		SET @stFILE_DEST = @stPATHSERVER + N'\' + @stFILEPDF_ON_DATA

		EXEC USP_CopyFileBySQL @stFILEPDF, @stFILE_DEST
		--SET @stFILEPDF = @stMSCV + @stExtFILEPDF
	--END
	 
	IF (@stFILEOFFICE <>'')
	BEGIN
		DECLARE @stExtFILEOFFICE NVARCHAR(20)
		SET @stExtFILEOFFICE = dbo.fGetExtFileName(@stFILEOFFICE)
		SET @stFILEOFFICE = @stMSCV + @stExtFILEOFFICE
	END
	
	IF (@stFILERAR <>'')
	BEGIN
		DECLARE @stExtFILERAR NVARCHAR(20)	
		SET @stExtFILERAR = dbo.fGetExtFileName(@stFILERAR)
		SET @stFILERAR = @stMSCV + @stExtFILERAR
	END

	IF (@dNGAYCV IS NULL)
		SET @dNGAYCV = GETDATE()
			
	INSERT INTO  dbo.tCongVan
	(	
		MSCV, SOCV, NOIDUNG, NOIDUNG_Unsign, NGAYCV, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, MSCVCHA, FILEPDF, FILEOFFICE, FILERAR
	)
	VALUES
	( 
		@stMSCV, @stSOCV, @stNOIDUNG, dbo.fConvertToUnsign(@stNOIDUNG), @dNGAYCV, @stMSNV, @iMSLOAICV, @iMSCQ, @iMSGIAIDOAN, @stMSCVCHA, @stFILEPDF_ON_DATA , @stFILEOFFICE, @stFILERAR
	)

	SELECT @stMSCV
END
GO

CREATE PROC USP_ThemCongvanMSCV 
--Dùng khi bổ sung công văn đã có file PDF trên Server
	@stMSCV NVARCHAR(20),
	@stFILEPDF NVARCHAR(MAX)	
AS
BEGIN
	IF ((LEFT(@stMSCV,2)='F.') OR (LEFT(@stMSCV,2)='T.'))
	BEGIN
		IF NOT EXISTS(SELECT MSCV FROM dbo.tCongVan WHERE trim(MSCV) = trim(@stMSCV))
		BEGIN
			INSERT INTO  dbo.tCongVan
			(	
				MSCV, SOCV, NGAYCV, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, MSCVCHA, FILEPDF, PHEDUYET
			)
			VALUES
			( 
				@stMSCV, 'SOCV', GETDATE(),'thoilt', 2, 28, 8, 'F1231', @stFILEPDF, 1
			)
		END
	END
	SELECT @stMSCV
END
GO

alter PROC USP_SuaCongvan 
	@stMSCV NVARCHAR(20) ='',
	@stSOCV NVARCHAR(50) = '',
	@stNOIDUNG NVARCHAR(MAX) = '',
	@dNGAYCV DATE = GETDATE,	
	@iMSLOAICV INT =1,
	@iMSCQ INT =1,
	@iMSGIAIDOAN INT = 1,
	@stMSCVCHA NVARCHAR(20) = '',
	@stFILEPDF NVARCHAR(MAX) = '',
	@stFILEOFFICE NVARCHAR(MAX) = '',
	@stFILERAR NVARCHAR(MAX) = ''	
AS
BEGIN				
	UPDATE dbo.tCongVan	SET	SOCV = @stSOCV,
							NOIDUNG = @stNOIDUNG,
							NOIDUNG_Unsign = dbo.fConvertToUnsign(@stNOIDUNG),							
							MSLOAICV = @iMSLOAICV, 
							MSCQ = @iMSCQ, 
							MSGIAIDOAN = @iMSGIAIDOAN, 
							MSCVCHA = @stMSCVCHA							
					  WHERE	MSCV = @stMSCV
	
	--Khai báo biến lưu lại MSCV
	DECLARE @stMSCV_Update NVARCHAR(20)
	
	--Kiểm tra user có sửa NGAYCV
	IF NOT EXISTS(SELECT MSCV FROM dbo.tCongVan WHERE MSCV=@stMSCV AND NGAYCV=@dNGAYCV) 
		SET @stMSCV_Update = dbo.fTaoMSCV(LEFT(@stMSCV,1),@dNGAYCV)
	ELSE
		SET @stMSCV_Update =@stMSCV
	
	--Tạo tên file đính kèm
	IF (@stFILEPDF !='') 
		SET @stFILEPDF = @stMSCV_Update + dbo.fGetExtFileName(@stFILEPDF)
	IF (@stFILEOFFICE !='') 
		SET @stFILEOFFICE = @stMSCV_Update + dbo.fGetExtFileName(@stFILEOFFICE)	
	IF (@stFILERAR!='')  
		SET @stFILERAR = @stMSCV_Update + dbo.fGetExtFileName(@stFILERAR)

	UPDATE dbo.tCongVan	SET	MSCV = @stMSCV_Update,
							NGAYCV = @dNGAYCV, 
							FILEPDF = @stFILEPDF, 
							FILEOFFICE = @stFILEOFFICE, 
							FILERAR = @stFILERAR
					  WHERE	MSCV = @stMSCV	
END
GO
CREATE PROC USP_TimkiemCongvan --Tìm công văn và trả về MSCV, SOCV, NOIDUNG để đưa vào dtgvCongvan 	
	@stNOIDUNG NVARCHAR(MAX) = NULL,
	@iMSLOAICV INT = NULL, 
	@iMSCQ INT = NULL,
	@iMSGIAIDOAN INT =NULL,	
	@dNGAYCVTU DATE = NULL,	
	@dNGAYCVDEN DATE = NULL,
	@bTimkhongdau BIT = 0 
AS
BEGIN
	
	SET @stNOIDUNG = IIF(@stNOIDUNG IS NULL,'%', '%' + @stNOIDUNG + '%')

	SET @iMSLOAICV = IIF(@iMSLOAICV IS NULL, 0, @iMSLOAICV)

	SET @iMSCQ = IIF(@iMSCQ IS NULL, 0, @iMSCQ)

	SET @iMSGIAIDOAN = IIF(@iMSGIAIDOAN IS NULL, 0, @iMSGIAIDOAN)
		 
	IF @dNGAYCVTU IS NULL
		SELECT @dNGAYCVTU = MIN(NGAYCV) FROM dbo.tCongVan

	IF @dNGAYCVDEN IS NULL
		SELECT @dNGAYCVDEN = MAX(NGAYCV) FROM dbo.tCongVan

	IF (@bTimkhongdau = 0)	
		SELECT *	FROM	dbo.tCongVan
					WHERE	(NOIDUNG LIKE @stNOIDUNG) AND 
							((@iMSLOAICV=0) OR (MSLOAICV = @iMSLOAICV)) AND 
							((@iMSCQ =0) OR (MSCQ = @iMSCQ)) AND 
							((@iMSGIAIDOAN =0) OR (MSGIAIDOAN = @iMSGIAIDOAN)) AND 
							(NGAYCV BETWEEN @dNGAYCVTU AND @dNGAYCVDEN) AND 
							(PHEDUYET = 1 OR MSCV LIKE 'F%')
	ELSE
		SELECT *	FROM	dbo.tCongVan
					WHERE	(NOIDUNG_Unsign LIKE @stNOIDUNG) AND 
							((@iMSLOAICV=0) OR (MSLOAICV = @iMSLOAICV)) AND 
							((@iMSCQ =0) OR (MSCQ = @iMSCQ)) AND 
							((@iMSGIAIDOAN =0) OR (MSGIAIDOAN = @iMSGIAIDOAN)) AND 
							(NGAYCV BETWEEN @dNGAYCVTU AND @dNGAYCVDEN) AND
							(PHEDUYET =1 OR MSCV LIKE 'F%')
END
GO
CREATE PROC USP_CapnhatLoaiCV
	@iID INT,
	@stNOIDUNG NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT MSLOAICV FROM dbo.tLoaiCV WHERE MSLOAICV = @iID)
		UPDATE dbo.tLoaiCV SET LOAICV = @stNOIDUNG  WHERE MSLOAICV = @iID
	ELSE
		INSERT INTO dbo.tLoaiCV (LOAICV) VALUES (@stNOIDUNG)
END
GO
CREATE PROC USP_CapnhatDuoiCV
	@iID INT,
	@stNOIDUNG NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT MSDUOICV FROM dbo.tDuoiCV WHERE MSDUOICV = @iID)	
		UPDATE dbo.tDuoiCV SET DUOICV = @stNOIDUNG  WHERE MSDUOICV = @iID
	ELSE
		INSERT INTO dbo.tDuoiCV (DUOICV) VALUES (@stNOIDUNG)
END
GO
CREATE PROC USP_CapnhatCoQuan
	@iID INT,
	@stNOIDUNG NVARCHAR(50)
AS
BEGIN
	IF EXISTS(SELECT MSCQ FROM dbo.tCoQuan WHERE MSCQ = @iID)
		UPDATE dbo.tCoQuan SET TENCQ = @stNOIDUNG  WHERE MSCQ = @iID
	ELSE
		INSERT INTO dbo.tCoQuan (TENCQ) VALUES (@stNOIDUNG)
END
GO

CREATE PROC USP_CapnhatGiaiDoan
	@iID INT,
	@stNOIDUNG NVARCHAR(50),
	@stMSCVGOC NVARCHAR(20)=NULL
AS
BEGIN
	IF @stMSCVGOC IS NULL
		BEGIN
			IF EXISTS(SELECT MSGIAIDOAN FROM dbo.tGiaiDoan WHERE MSGIAIDOAN = @iID)
				UPDATE dbo.tGiaiDoan SET GIAIDOAN = @stNOIDUNG  WHERE MSGIAIDOAN = @iID
			ELSE
				INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (@stNOIDUNG)
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT MSGIAIDOAN FROM dbo.tGiaiDoan WHERE MSGIAIDOAN = @iID)
				UPDATE dbo.tGiaiDoan SET GIAIDOAN = @stNOIDUNG, MSCVGOC = @stMSCVGOC WHERE MSGIAIDOAN = @iID
			ELSE
				INSERT INTO dbo.tGiaiDoan (GIAIDOAN, MSCVGOC) VALUES (@stNOIDUNG, @stMSCVGOC)
		END
END
GO

CREATE PROC USP_CapnhatNhanVien
	 @stMSNV NVARCHAR(12), 
	 @stHOTEN NVARCHAR(50), 
	 @stQUYENTRUYCAP NVARCHAR(2),
	 @stEMAIL NVARCHAR(50), 
	 @bHIEULUC bit  
AS
BEGIN
	IF EXISTS(SELECT MSNV FROM dbo.tNhanVien WHERE MSNV = @stMSNV)
		UPDATE dbo.tNhanVien SET HOTEN = @stHOTEN, QUYENTRUYCAP = @stQUYENTRUYCAP, EMAIL = @stEMAIL, HIEULUC = @bHIEULUC WHERE MSNV = @stMSNV
	ELSE
	BEGIN
		IF EXISTS(SELECT MSNV FROM dbo.tNhanVien WHERE MSNV = 'USER')
			DELETE FROM dbo.tNhanVien WHERE MSNV = 'USER'
		INSERT INTO dbo.tNhanVien (MSNV, HOTEN, PASSWORD, QUYENTRUYCAP, EMAIL, HIEULUC) VALUES (@stMSNV, @stHOTEN,'2003011414115776479911161271372042013444', @stQUYENTRUYCAP, @stEMAIL, @bHIEULUC)
	END
END
GO
CREATE PROC USP_ThemNhanVien
	 @stMSNV NVARCHAR(12),
	 @stHOTEN NVARCHAR(50)
AS
BEGIN
	IF NOT EXISTS(SELECT MSNV FROM dbo.tNhanVien WHERE MSNV = @stMSNV)
		INSERT INTO dbo.tNhanVien (MSNV, HOTEN, QUYENTRUYCAP, EMAIL, PASSWORD, HIEULUC) VALUES (@stMSNV, @stHOTEN, 'NV', '', '2003011414115776479911161271372042013444',1)
END
GO
CREATE PROC USP_CapnhatThongSo
@stMSTS NVARCHAR(12), 
@stNOIDUNG NVARCHAR(MAX), 
@stSTR_DATA NVARCHAR(MAX), 
@stSTR_PATH NVARCHAR(MAX), 
@bHIEULUC bit 
AS
BEGIN
	IF EXISTS(SELECT MSTS FROM dbo.tThongSo WHERE MSTS = @stMSTS)
		UPDATE dbo.tThongSo SET NOIDUNG = @stNOIDUNG, STR_DATA = @stSTR_DATA, STR_PATH = @stSTR_PATH, HIEULUC = @bHIEULUC WHERE MSTS = @stMSTS
	ELSE
		INSERT INTO dbo.tThongSo (MSTS, NOIDUNG, STR_DATA, STR_PATH, HIEULUC) VALUES (@stMSTS, @stNOIDUNG, @stSTR_DATA, @stSTR_PATH, @bHIEULUC)
END
GO

CREATE PROC USP_CapnhatGiaoViec
@stMSCV NVARCHAR(20),
@stMSNV NVARCHAR(12),
@stCHIDAO NVARCHAR(MAX) = '',
@bTHONGBAO bit
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.tGiaoViec WHERE MSCVGIAOVIEC = @stMSCV AND MSNVGIAOVIEC = @stMSNV) --Đã tồn tại
		UPDATE dbo.tGiaoViec SET CHIDAO = @stCHIDAO WHERE  MSCVGIAOVIEC = @stMSCV AND MSNVGIAOVIEC = @stMSNV	
	ELSE
		INSERT INTO dbo.tGiaoViec (MSCVGIAOVIEC, MSNVGIAOVIEC, CHIDAO, NGAYGIO, THONGBAO) VALUES (@stMSCV, @stMSNV, @stCHIDAO, GETDATE(), @bTHONGBAO )
END
GO

CREATE PROC USP_SoCV
@dNGAYCVTU DATE,	
@dNGAYCVDEN DATE,
@stLOAICV NVARCHAR(1)
AS
BEGIN
	SELECT	cv.MSCV, cv.SOCV, cv.NGAYCV, cv.NOIDUNG, lcv.LOAICV, cq.TENCQ 
	FROM	dbo.tLoaiCV lcv, dbo.tCoQuan cq, dbo.tCongVan cv 
	WHERE	lcv.MSLOAICV = cv.MSLOAICV AND cq.MSCQ = cv.MSCQ AND
			(cv.NGAYCV BETWEEN @dNGAYCVTU AND @dNGAYCVDEN) AND
			LEFT(cv.MSCV,1) = @stLOAICV
	ORDER BY NGAYCV ASC
END
GO

CREATE PROC USP_CapNhatCayCV
@stMSCV_SOURCE NVARCHAR(20) = NULL,
@stMSCV_DEST NVARCHAR(20) = NULL
AS
BEGIN
	IF (@stMSCV_SOURCE IS NULL AND @stMSCV_DEST IS NULL ) --RESET CAYCV
		BEGIN
			UPDATE tCongVan SET MSCVCHA='' --Reset tCongVan
			UPDATE tCongVan SET MSCVCHA = gd.MSCVGOC FROM tGiaiDoan gd WHERE tCongVan.MSGIAIDOAN = gd.MSGIAIDOAN
			UPDATE tCongVan SET MSCVCHA ='' WHERE MSCV IN (SELECT MSCVGOC FROM tGiaiDoan)
		END
	ELSE												-- THAY THE MSCVCHA
		BEGIN
			UPDATE tCongVan SET MSCVCHA = @stMSCV_DEST WHERE MSCVCHA = @stMSCV_SOURCE
			UPDATE tCongVan SET MSCVCHA = '' WHERE MSCV = @stMSCV_DEST			
		END
END
GO

-- Tạo View
CREATE VIEW UVW_GiaoViec
AS SELECT	cv.MSCV, CV.SOCV, CV.NGAYCV, CV.NOIDUNG, gv.CHIDAO, gv.NGAYGIO, CV.PHEDUYET, 
			CV.NOIDUNG_Unsign, CV.FILEPDF, CV.FILEOFFICE,CV.FILERAR, gv.MSNVGIAOVIEC, GV.THONGBAO
	FROM	dbo.tGiaoViec gv, dbo.tCongVan cv 
	WHERE	CV.MSCV = GV.MSCVGIAOVIEC AND CV.PHEDUYET=0
GO

CREATE VIEW UVW_CongVan
AS SELECT	cv.*, lcv.LOAICV, cq.TENCQ, gd.GIAIDOAN
	FROM	dbo.tLoaiCV lcv, dbo.tCoQuan cq, dbo.tGiaiDoan gd, dbo.tCongVan cv 
	WHERE	lcv.MSLOAICV = cv.MSLOAICV AND cq.MSCQ = cv.MSCQ AND gd.MSGIAIDOAN = cv.MSGIAIDOAN
GO

--Tạo Functions
alter FUNCTION dbo.fTaoMSCV(@stFirstMSCV NVARCHAR(1), @dNGAYCV DATE) RETURNS NVARCHAR(20) AS
-- Tạo MSCV với định dạng F.yyyymmdd.xxx hoặc T.yyyymmdd.xxx trong đó:
-- stFirstMSCV (F: Công văn đến, T: Công văn đi); dNGAYCV (yyyymmdd)
BEGIN
	DECLARE @stMSCV NVARCHAR(20)	
	DECLARE @stNGAYCV NVARCHAR(8)
	DECLARE @i INT
	
	SET @i=1	
	SET @stNGAYCV = REPLACE(CAST(@dNGAYCV AS NVARCHAR),'-','')
	--SET @stNGAYCV = CAST(YEAR(@dNGAYCV) AS NVARCHAR) +  CAST(MONTH(@dNGAYCV) AS NVARCHAR) + CAST(DAY(@dNGAYCV) AS NVARCHAR)
	SET @stMSCV = @stFirstMSCV + '.' + @stNGAYCV + '.' + CAST(@i AS NVARCHAR)
	
	WHILE (EXISTS(SELECT MSCV FROM dbo.tCongVan WHERE MSCV = @stMSCV))
	BEGIN
		SET @i = @i+1	
		SET @stMSCV =@stFirstMSCV + '.' + @stNGAYCV + '.' + CAST(@i AS NVARCHAR)					
    END
	RETURN @stMSCV
END
GO

CREATE FUNCTION dbo.fConvertToUnsign (@strInput NVARCHAR(4000)) RETURNS NVARCHAR(4000) AS 
BEGIN 
	
	IF @strInput IS NULL RETURN @strInput 
	
	IF @strInput = '' RETURN @strInput 
	
	DECLARE @RT NVARCHAR(4000) 
	
	DECLARE @SIGN_CHARS NCHAR(136) 
	
	DECLARE @UNSIGN_CHARS NCHAR (136) 
	
	SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) 
	
	SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' 
	
	DECLARE @COUNTER int 
	
	DECLARE @COUNTER1 int 
	
	SET @COUNTER = 1 
	WHILE (@COUNTER <=LEN(@strInput)) 
	BEGIN 
		SET @COUNTER1 = 1 
		
		WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) 
		BEGIN 
			IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) 
			BEGIN 
			IF @COUNTER=1 
				SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) 
			ELSE 
				SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) 
			BREAK 
			END 
			SET @COUNTER1 = @COUNTER1 +1 
		END 
		
		SET @COUNTER = @COUNTER +1 
	END

	RETURN @strInput
END
GO
CREATE FUNCTION dbo.fGetExtFileName(@stFileName NVARCHAR(MAX)) RETURNS NVARCHAR(20) AS 
BEGIN
	SET @stFileName = REVERSE(@stFileName)
	DECLARE @i INT
	SET @i = CHARINDEX('.', @stFileName,  1)
	RETURN REVERSE(LEFT(@stFileName,@i))	  
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

--DATE: 07/10/2021

--IF @iMSLOAICV IS NULL
	--	SET @iMSLOAICV = 0	

	--IF @iMSCQ IS NULL
	--	SET @iMSCQ = 0
	
	--IF @iMSGIAIDOAN IS NULL
	--	SET @iMSGIAIDOAN = 0

--CREATE PROC USP_XoaCongvan 
--	@stMSCV NVARCHAR(20) =''
--AS
--BEGIN
--	IF ((SELECT MSCVGIAOVIEC FROM dbo.tGiaoViec WHERE MSCVGIAOVIEC = @stMSCV)>0)
--		DELETE FROM dbo.tGiaoViec WHERE MSCVGIAOVIEC = @stMSCV
--	DELETE FROM dbo.tCongVan WHERE MSCV = @stMSCV
--END
--GO

--alter PROC USP_TaotSoCVDen --tSoCV phải có dữ liệu mới nhất
--AS
--BEGIN
--	IF (EXISTS(select * from INFORMATION_SCHEMA.TABLES where table_name='tSoCVDen'))
--		DROP TABLE tSoCVDen
--	SELECT * INTO tSoCVDen FROM UVW_SoCVDen
--END
--go

--alter PROC USP_TaotSoCVDi --tSoCV phải có dữ liệu mới nhất
--AS
--BEGIN
--	IF (EXISTS(select * from INFORMATION_SCHEMA.TABLES where table_name='tSoCVDi'))
--		DROP TABLE tSoCVDi
--	SELECT * INTO tSoCVDi FROM UVW_SoCVDi
--END
--GO

--alter PROC USP_TaotSoCV -- Input: UVW_SoCV; Output: tSoCVDi và tSoCVDen
--AS
--BEGIN
--	IF (EXISTS(select * from INFORMATION_SCHEMA.TABLES where table_name='tSoCV'))
--		DROP TABLE tSoCV
--	SELECT * INTO tSoCV FROM dbo.tSoCVDen 
--	INSERT INTO tSoCV SELECT * FROM dbo.tSoCVDi
--END
--GO

---- Tạo View
--CREATE VIEW UVW_SoCV
--AS SELECT *, MSCV AS [COL0], SOCV AS [COL1], dbo.fConvertToUnsign(NOIDUNG) AS [COL2] FROM tCongVan WHERE PHEDUYET =1 OR LEFT(MSCV,1)='F'
--GO
--CREATE VIEW UVW_SoCVDen
--AS SELECT *, MSCV AS [COL0], SOCV AS [COL1], dbo.fConvertToUnsign(NOIDUNG) AS [COL2] FROM tCongVan WHERE LEFT(MSCV,1)='F'
--GO
--CREATE VIEW UVW_SoCVDi
--AS SELECT *, MSCV AS [COL0], SOCV AS [COL1], dbo.fConvertToUnsign(NOIDUNG) AS [COL2] FROM tCongVan WHERE PHEDUYET =1 AND LEFT(MSCV,1)='T'
--GO

-- Tạo Function