﻿﻿/*--------------------------------------------------------------
Tạo PROC, FUNC cho Data:
-- Trước khi chạy script này, phải thực hiện:
-- (1) Tạo Data, Table (File Data.sql)
-- (2) Chạy các PROC, FUNC trong Utilities.sql (Thư mục SHARE)
---------------------------------------------------------------*/

USE QLHS_HP
GO

--Tạo Procudure
CREATE PROC USP_Login @iMSNV INT, @stPassWord NVARCHAR(MAX)
AS
BEGIN
	IF ((@iMSNV IS NOT NULL) AND  (@stPassWord IS NOT NULL))
		SELECT MSNV FROM dbo.tNhanVien WHERE MSNV=@iMSNV AND MATKHAU=@stPassWord AND HIEULUC=1
END
GO

CREATE PROC USP_CapnhatMatkhau @iMSNV INT, @stPassWord NVARCHAR(MAX)
AS
BEGIN
	IF ((@iMSNV IS NOT NULL) AND  (@stPassWord IS NOT NULL))
		UPDATE dbo.tNhanVien SET MATKHAU=@stPassWord WHERE MSNV=@iMSNV
END
GO

CREATE PROC USP_CopyFileToServer @stMSCV INT, @stMSTS NVARCHAR(MAX), @stFILE NVARCHAR(MAX)
AS
BEGIN
	DECLARE @stPATHSERVER NVARCHAR(MAX)
	SELECT @stPATHSERVER = STR_PATH FROM tThongSo WHERE MSTS = @stMSTS -- Lấy đường dẫn file trên SERVER

	DECLARE @stFILE_DEST NVARCHAR(MAX)	-- Đường dẫn file đích trên SERVER 
	SET @stFILE_DEST = @stPATHSERVER + N'\' + RTRIM(@stMSCV) + dbo.fGetExtFileName(@stFILE) -- File đích (bao gồm cả đường dẫn)

	EXEC USP_CopyFileBySQL @stFILE, @stFILE_DEST
END
GO

CREATE PROC USP_ThemCongvan	
	@stSOCV			NVARCHAR(MAX) = '',
	@bCVDEN			BIT =1 ,
	@stNOIDUNG		NVARCHAR(MAX) = '',
	@dNGAYCV		DATE = NULL,
	@iMSNV			INT = 1,
	@iMSLOAICV		INT =1,
	@iMSCQ			INT =1,
	@iMSGIAIDOAN	INT = 1,
	@iMSCVCHA		BIGINT = NULL,
	@stMSTS			NVARCHAR(MAX) = '', -- Xác định đường dẫn file trên SERVER
	@stFILEPDF		NVARCHAR(MAX) = '',
	@stFileOFFICE	NVARCHAR(MAX) = '',
	@stFileRAR		NVARCHAR(MAX) = ''	
AS
BEGIN	
	
	IF (@dNGAYCV IS NULL)
		SET @dNGAYCV = GETDATE()
			
	INSERT INTO  dbo.tCongVan
	(	
		SOCV, CVDEN, NOIDUNG, NOIDUNG_Unsign, NGAYCV, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, MSCVCHA
	)
	VALUES
	( 
		@stSOCV, @bCVDEN, @stNOIDUNG, dbo.fConvertToUnsign(@stNOIDUNG), @dNGAYCV, @iMSNV, @iMSLOAICV, @iMSCQ, @iMSGIAIDOAN, @iMSCVCHA
	)

	DECLARE @iMSCV BIGINT
	SET @iMSCV = SCOPE_IDENTITY() -- Lấy ID của REC mới INSERT
	
	DECLARE @stMSCV NVARCHAR(MAX)	
	SELECT @stMSCV = CONVERT(nvarchar, @iMSCV )

	IF (CHARINDEX('\', @stFILEPDF)>0) 
	BEGIN
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILEPDF
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILEPDF) WHERE MSCV = @iMSCV
	END

	IF (CHARINDEX('\', @stFILEOFFICE)>0) 
	BEGIN		
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILEOFFICE
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILEOFFICE) WHERE MSCV = @iMSCV
	END

	IF (CHARINDEX('\', @stFILERAR)>0) 
	BEGIN		
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILERAR
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILERAR) WHERE MSCV = @iMSCV
	END
	
	SELECT @iMSCV 
END
GO

CREATE PROC USP_ThemCongvanMSCV --Dùng khi bổ sung công văn đã có file PDF trên Server	
	@iMSCV		BIGINT,
	@stFILEPDF	NVARCHAR(MAX)	
AS
BEGIN	
	IF NOT EXISTS(SELECT MSCV FROM dbo.tCongVan WHERE MSCV = @iMSCV)  --Kiểm tra MSCV đã có chưa
	BEGIN
		BEGIN
			INSERT INTO  dbo.tCongVan
			(	
				SOCV, CVDEN, NGAYCV, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, FILEPDF, PHEDUYET
			)
			VALUES
			( 
				'SOCV', 1, GETDATE(),'thoilt', 1, 1, 1, @stFILEPDF, 1
			)
		END
	END
	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROC USP_SuaCongvan 
	@iMSCV			BIGINT,
	@stSOCV			NVARCHAR(MAX) = '',
	@bCVDEN			BIT =1 ,
	@stNOIDUNG		NVARCHAR(MAX) = '',
	@dNGAYCV		DATE = GETDATE,	
	@iMSLOAICV		INT =1,
	@iMSCQ			INT =1,
	@iMSGIAIDOAN	INT = 1,
	@iMSCVCHA		BIGINT,
	@stMSTS			NVARCHAR(MAX),
	@stFILEPDF		NVARCHAR(MAX) = '',
	@stFILEOFFICE	NVARCHAR(MAX) = '',
	@stFILERAR		NVARCHAR(MAX) = ''	
AS
BEGIN				
	UPDATE dbo.tCongVan	SET	SOCV			= @stSOCV,
							CVDEN			= @bCVDEN,
							NGAYCV			= @dNGAYCV,
							NOIDUNG			= @stNOIDUNG,
							NOIDUNG_Unsign	= dbo.fConvertToUnsign(@stNOIDUNG),							
							MSLOAICV		= @iMSLOAICV, 
							MSCQ			= @iMSCQ, 
							MSGIAIDOAN		= @iMSGIAIDOAN, 
							MSCVCHA			= @iMSCVCHA							
					  WHERE	MSCV			= @iMSCV
	
	DECLARE @stMSCV NVARCHAR(MAX)	
	SELECT @stMSCV = CONVERT(nvarchar, @iMSCV )

	IF (CHARINDEX('\', @stFILEPDF)>0)
	BEGIN
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILEPDF
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILEPDF) WHERE MSCV = @iMSCV
	END

	IF (CHARINDEX('\', @stFILEOFFICE)>0) 
	BEGIN		
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILEOFFICE
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILEOFFICE) WHERE MSCV = @iMSCV
	END

	IF (CHARINDEX('\', @stFILERAR)>0) 
	BEGIN		
		EXEC USP_CopyFileToServer @stMSCV, @stMSTS, @stFILERAR
		UPDATE tCongVan SET FILEPDF = @stMSCV + dbo.fGetExtFileName(@stFILERAR) WHERE MSCV = @iMSCV
	END
	
	SELECT @iMSCV 

END
GO

CREATE PROC USP_TimkiemCongvan --Tìm công văn và trả về MSCV, SOCV, NOIDUNG để đưa vào dtgvCongvan 	
	@stNOIDUNG		NVARCHAR(MAX) = NULL,
	@iMSLOAICV		INT = NULL, 
	@iMSCQ			INT = NULL,
	@iMSGIAIDOAN	INT =NULL,	
	@dNGAYCVTU		DATE = NULL,	
	@dNGAYCVDEN		DATE = NULL,
	@bTimkhongdau	BIT = 0 
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
							(PHEDUYET = 1 OR CVDEN = 0) --> Tìm công văn đi đã phê duyệt và toàn bộ công văn đến
	ELSE
		SELECT *	FROM	dbo.tCongVan
					WHERE	(NOIDUNG_Unsign LIKE @stNOIDUNG) AND 
							((@iMSLOAICV=0) OR (MSLOAICV = @iMSLOAICV)) AND 
							((@iMSCQ =0) OR (MSCQ = @iMSCQ)) AND 
							((@iMSGIAIDOAN =0) OR (MSGIAIDOAN = @iMSGIAIDOAN)) AND 
							(NGAYCV BETWEEN @dNGAYCVTU AND @dNGAYCVDEN) AND
							(PHEDUYET =1 OR CVDEN=0)
END
GO

CREATE PROC USP_CapnhatLoaiCV
	@iID		INT,
	@stNOIDUNG	NVARCHAR(MAX)
AS
BEGIN
	IF EXISTS(SELECT MSLOAICV FROM dbo.tLoaiCV WHERE MSLOAICV = @iID)
		UPDATE dbo.tLoaiCV SET LOAICV = @stNOIDUNG  WHERE MSLOAICV = @iID
	ELSE
		INSERT INTO dbo.tLoaiCV (LOAICV) VALUES (@stNOIDUNG)
END
GO

CREATE PROC USP_CapnhatDuoiCV
	@iID		INT,
	@stNOIDUNG	NVARCHAR(MAX)
AS
BEGIN
	IF EXISTS(SELECT MSDUOICV FROM dbo.tDuoiCV WHERE MSDUOICV = @iID)	
		UPDATE dbo.tDuoiCV SET DUOICV = @stNOIDUNG  WHERE MSDUOICV = @iID
	ELSE
		INSERT INTO dbo.tDuoiCV (DUOICV) VALUES (@stNOIDUNG)
END
GO

CREATE PROC USP_CapnhatCoQuan
	@iID		INT,
	@stNOIDUNG	NVARCHAR(MAX)
AS
BEGIN
	IF EXISTS(SELECT MSCQ FROM dbo.tCoQuan WHERE MSCQ = @iID)
		UPDATE dbo.tCoQuan SET TENCQ = @stNOIDUNG  WHERE MSCQ = @iID
	ELSE
		INSERT INTO dbo.tCoQuan (TENCQ) VALUES (@stNOIDUNG)
END
GO

CREATE PROC USP_CapnhatGiaiDoan
	@iID		INT,
	@stNOIDUNG	NVARCHAR(MAX),
	@iMSCVGOC	BIGINT
AS
BEGIN
	IF ((@iMSCVGOC IS NULL) OR (@iMSCVGOC =0))
		BEGIN
			IF EXISTS(SELECT MSGIAIDOAN FROM dbo.tGiaiDoan WHERE MSGIAIDOAN = @iID)
				UPDATE dbo.tGiaiDoan SET GIAIDOAN = @stNOIDUNG  WHERE MSGIAIDOAN = @iID
			ELSE
				INSERT INTO dbo.tGiaiDoan (GIAIDOAN) VALUES (@stNOIDUNG)
		END
	ELSE
		BEGIN
			IF EXISTS(SELECT MSGIAIDOAN FROM dbo.tGiaiDoan WHERE MSGIAIDOAN = @iID)
				UPDATE dbo.tGiaiDoan SET GIAIDOAN = @stNOIDUNG, MSCVGOC = @iMSCVGOC WHERE MSGIAIDOAN = @iID
			ELSE
				INSERT INTO dbo.tGiaiDoan (GIAIDOAN, MSCVGOC) VALUES (@stNOIDUNG, @iMSCVGOC)
		END
END
GO

CREATE PROC USP_CapnhatNhanVien
	 @iMSNV			INT, 
	 @stUSERNAME	NVARCHAR(20),
	 @stHOTEN		NVARCHAR(MAX), 
	 @stQUYENTC		NVARCHAR(2),
	 @stEMAIL		NVARCHAR(MAX), 
	 @bHIEULUC		BIT  
AS
BEGIN
	IF EXISTS(SELECT MSNV FROM dbo.tNhanVien WHERE MSNV = @iMSNV)
		UPDATE dbo.tNhanVien SET USERNAME = @stUSERNAME, HOTEN = @stHOTEN, QUYENTC = @stQUYENTC, EMAIL = @stEMAIL, HIEULUC = @bHIEULUC WHERE MSNV = @iMSNV
	ELSE	
		INSERT INTO dbo.tNhanVien (USERNAME, HOTEN, MATKHAU, QUYENTC, EMAIL, HIEULUC) VALUES (@stUSERNAME, @stHOTEN,'2003011414115776479911161271372042013444', @stQUYENTC, @stEMAIL, @bHIEULUC)
END
GO

CREATE PROC USP_ThemNhanVien
	 @stUSERNAME	NVARCHAR(20),
	 @stHOTEN		NVARCHAR(MAX)
AS
BEGIN
	IF NOT EXISTS(SELECT USERNAME FROM dbo.tNhanVien WHERE USERNAME = @stUSERNAME)
		INSERT INTO dbo.tNhanVien (USERNAME, HOTEN, QUYENTC, EMAIL, MATKHAU, HIEULUC) VALUES (@stUSERNAME, @stHOTEN, 'NV', '', '2003011414115776479911161271372042013444',1)
END
GO

CREATE PROC USP_CapnhatThongSo
@stMSTS		NVARCHAR(20), 
@stNOIDUNG	NVARCHAR(MAX), 
@stSTR_DATA NVARCHAR(MAX), 
@stSTR_PATH NVARCHAR(MAX), 
@bHIEULUC	BIT
AS
BEGIN
	IF EXISTS(SELECT MSTS FROM dbo.tThongSo WHERE MSTS = @stMSTS)
		UPDATE dbo.tThongSo SET NOIDUNG = @stNOIDUNG, STR_DATA = @stSTR_DATA, STR_PATH = @stSTR_PATH, HIEULUC = @bHIEULUC WHERE MSTS = @stMSTS
	ELSE
		INSERT INTO dbo.tThongSo (MSTS, NOIDUNG, STR_DATA, STR_PATH, HIEULUC) VALUES (@stMSTS, @stNOIDUNG, @stSTR_DATA, @stSTR_PATH, @bHIEULUC)
END
GO

CREATE PROC USP_CapnhatGiaoViec
@iMSCV		BIGINT,
@iMSNV		INT,
@stCHIDAO	NVARCHAR(MAX) = '',
@bTHONGBAO	bit
AS
BEGIN
	IF EXISTS(SELECT * FROM dbo.tGiaoViec WHERE MSCVGIAOVIEC = @iMSCV AND MSNVGIAOVIEC = @iMSNV) --Đã tồn tại
		UPDATE dbo.tGiaoViec SET CHIDAO = @stCHIDAO WHERE  MSCVGIAOVIEC = @iMSCV AND MSNVGIAOVIEC = @iMSNV	
	ELSE
		INSERT INTO dbo.tGiaoViec (MSCVGIAOVIEC, MSNVGIAOVIEC, CHIDAO, NGAYGIO, THONGBAO) VALUES (@iMSCV, @iMSNV, @stCHIDAO, GETDATE(), @bTHONGBAO)
END
GO

CREATE PROC USP_SoCV  -- Tạo sổ công văn
@dNGAYCVTU	DATE,	
@dNGAYCVDEN DATE,
@bCVDEN		BIT
AS
BEGIN
	SELECT	cv.MSCV, cv.SOCV, cv.NGAYCV, cv.NOIDUNG, lcv.LOAICV, cq.TENCQ 
	FROM	dbo.tLoaiCV lcv, dbo.tCoQuan cq, dbo.tCongVan cv 
	WHERE	lcv.MSLOAICV = cv.MSLOAICV AND cq.MSCQ = cv.MSCQ AND
			(cv.NGAYCV BETWEEN @dNGAYCVTU AND @dNGAYCVDEN) AND
			(cv.CVDEN = @bCVDEN)
	ORDER BY NGAYCV ASC
END
GO

CREATE PROC USP_CapNhatCayCV
@iMSCV_SOURCE	BIGINT = NULL,
@iMSCV_DEST		BIGINT = NULL
AS
BEGIN
	IF (@iMSCV_SOURCE IS NULL AND @iMSCV_DEST IS NULL ) --RESET CAYCV
		BEGIN
			UPDATE tCongVan SET MSCVCHA = NULL --Reset tCongVan
			UPDATE tCongVan SET MSCVCHA = gd.MSCVGOC FROM tGiaiDoan gd WHERE tCongVan.MSGIAIDOAN = gd.MSGIAIDOAN
			UPDATE tCongVan SET MSCVCHA = NULL WHERE MSCV IN (SELECT MSCVGOC FROM tGiaiDoan)
		END
	ELSE										-- THAY THE MSCVCHA
		BEGIN
			UPDATE tCongVan SET MSCVCHA = @iMSCV_DEST WHERE MSCVCHA = @iMSCV_SOURCE
			UPDATE tCongVan SET MSCVCHA = NULL WHERE MSCV = @iMSCV_DEST			
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
