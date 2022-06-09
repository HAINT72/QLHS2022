--Trước khi chạy script này, phải thực hiện :
-- (1) Chạy script DataQlHS2021.sql
-- (2) import các bảng tblLoaiCV, tblCoQuanbanhanh, tblDuoiSoCV, tblCongVanDen, tblCongVanDi

USE QLHS_HP
GO
--Thêm cột MSLOAICVSAVE vào tLoaiCV
INSERT INTO dbo.tLoaiCV (LOAICV, MSLOAICVSAVE) SELECT LOAICONGVAN, MSLOAICV FROM dbo.tblLoaiCongVan 
GO
--Thêm cột MSCQSAVE vào tCoQuan
INSERT INTO dbo.tCoQuan (TenCQ, MSCQSAVE) SELECT TenCoQuan, MSCQ FROM dbo.tblCoQuanbanhanh 
GO
-- Thêm bảng tDuoiCV
INSERT INTO dbo.tDuoiCV (DuoiCV) SELECT TENDUOISOCV FROM dbo.tblDuoiSoCV
GO
-- Update tCongVanDen (MSLOAICV, MSCQ)
UPDATE tblCongVanDen SET MSLOAICV = t.MSLOAICV 
FROM tLoaiCV AS t 
WHERE t.MSLOAICVSAVE = tblCongVanDen.MSLOAICV
GO
UPDATE tblCongVanDen SET MSCQ = t.MSCQ 
FROM tCoQuan AS t 
WHERE t.MSCQSAVE = tblCongVanDen.MSCQ
GO
-- Update tCongVanDi (MSLOAICV, MSCQ)[Qlhs2011]
UPDATE tblCongVanDi SET MSLOAICV = t.MSLOAICV 
FROM tLoaiCV AS t 
WHERE t.MSLOAICVSAVE = tblCongVanDi.MSLOAICV
GO
UPDATE tblCongVanDi SET MSCQ = t.MSCQ 
FROM tCoQuan AS t 
WHERE t.MSCQSAVE = tblCongVanDi.MSCQ
GO
--Insert tblCongVanDen vào tCongVan
INSERT INTO dbo.tCongVan
(
    MSCV, SOCV, NGAYCV, NOIDUNG, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, MSCVCHA, FILEPDF, PHEDUYET
)
SELECT 'F' + cast(MSCV AS NVARCHAR), ISNULL(SOCV,''), ISNULL(NGAYCV, GETDATE()), TRICHYEU, 'haint', ISNULL(MSLOAICV,1), ISNULL(MSCQ,1), 1, '', TENFILESERVER, 1  FROM dbo.tblCongVanDen
GO
--Insert tblCongVanDi vào tCongVan
INSERT INTO dbo.tCongVan
(
    MSCV, SOCV, NGAYCV, NOIDUNG, MSNV, MSLOAICV, MSCQ, MSGIAIDOAN, MSCVCHA, FILEPDF, PHEDUYET
)
SELECT 'T' + cast(MSCV AS NVARCHAR), CAST(ISNULL(SOCV,'') AS NVARCHAR) + '/' + dcv.TENDUOISOCV, ISNULL(NGAYCV, GETDATE()), TRICHYEU, 'haint', ISNULL(MSLOAICV,1), ISNULL(MSCQ,1), 9, '', FILEPDFSERVER, 1  
FROM dbo.tblCongVanDi AS cv, tblDuoiSoCV AS dcv
WHERE cv.MSDUOISOCV = dcv.MSDUOISOCV
GO
--Update cột Noidung_unsign
UPDATE tCongVan SET NOIDUNG_UNSIGN = dbo.fConvertToUnsign(NOIDUNG)
update tCongVan SET PHEDUYET=1
GO

--Xoá các bảng tạm
DROP TABLE tblCongVanDi
go
DROP TABLE tblCongVanDen
go
DROP TABLE tblDuoiSoCV
go
DROP TABLE tblCoquanbanhanh
GO
DROP TABLE tblLoaiCongvan
GO

--Xoá các cột tạm
ALTER TABLE dbo.tLoaiCV DROP COLUMN MSLOAICVSAVE
GO
ALTER TABLE dbo.tCoQuan DROP COLUMN MSCQSAVE
go
 
 -- 26/10/2021
 --SELECT @@VERSION
 --SELECT GETDATE()
 --USE QLHS_HP

 --UPDATE dbo.tCongVan SET MSCVCHA = 'F      2942' WHERE MSCV !='F      2942'
 --SELECT * FROM dbo.tCongVan
  
 --SELECT LAST_VALUE()

 --SELECT * FROM dbo.tCongVan WHERE MSCVCHA =''
 --SELECT ROW_NUMBER() OVER (ORDER BY (SELECT 1)) FROM dbo.tCongVan
 --SELECT * FROM dbo.tCongVan WHERE NOIDUNG='' OR noidung IS NULL 

 --SELECT * FROM dbo.tNhanVien
 --DATE: 07/10/2021



