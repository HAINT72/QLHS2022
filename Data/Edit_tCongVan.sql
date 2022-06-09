use QLHS_HP
update tCongVan set MSCVCHA =''
update tCongVan set MSGIAIDOAN = 2 where noidung like N'%BCNCKT%'
update tCongVan set MSGIAIDOAN = 6 where noidung like N'%TKBVTC%'
update tCongVan set MSGIAIDOAN = 5 where noidung like N'%GPMB%'  
update tCongVan set MSGIAIDOAN = 6 where noidung like N'%đề cương và dự toán%'
update tCongVan set MSGIAIDOAN = 3 where noidung like N'%gia hạn thời gian có%'
update tCongVan set MSGIAIDOAN = 4 where noidung like N'%gia hạn thời gian cung cấp%'
update tCongVan set MSGIAIDOAN = 7 where noidung like N'%lựa chọn nhà thầu%'
update tCongVan set MSGIAIDOAN = 3 where noidung like N'%HSMT%'
update tCongVan set MSGIAIDOAN = 4 where NOIDUNG_Unsign like N'%hop dong du an%'
UPDATE tCongVan set MSGIAIDOAN = 4 where NOIDUNG_Unsign like N'%dai dien%'
UPDATE tCongVan set MSGIAIDOAN = 2 where MSGIAIDOAN = 1 and (NGAYCV BETWEEN convert(datetime,'21/10/2016',103) AND convert(datetime,'28/10/2016',103))
UPDATE tCongVan set MSGIAIDOAN = 2 where NOIDUNG_Unsign like N'%nha may dong tau%'
UPDATE tCongVan set MSGIAIDOAN = 3 where MSGIAIDOAN = 1 and NOIDUNG_Unsign like N'%so tuyen%'
UPDATE tCongVan set MSGIAIDOAN = 3 where NOIDUNG_Unsign like N'%HSMST%'
UPDATE tCongVan set MSGIAIDOAN = 5 where NOIDUNG_Unsign like N'%thu hoi dat%'
update tCongVan set MSGIAIDOAN = 8 WHERE NOIDUNG_Unsign like N'%goi thau%' and MSGIAIDOAN=4
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%bo nhiem%'
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%quy che%' and MSGIAIDOAN=4
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%gop von%' and MSGIAIDOAN=4
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%cham dut hop dong lao dong%'
update tCongVan set MSGIAIDOAN = 5 WHERE NOIDUNG_Unsign like N'%thu hoi dat%'
update tCongVan set MSGIAIDOAN = 7 WHERE NOIDUNG_Unsign like N'%phe duyet ho so yeu cau%' and MSGIAIDOAN=8
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%nang bac luong%'
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%nhan su%' and MSGIAIDOAN=4
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%COVID%' and MSGIAIDOAN=8
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%lao dong%' and MSGIAIDOAN=8
update tCongVan set MSGIAIDOAN = 2 WHERE NOIDUNG_Unsign like N'%bao cao nghien cuu kha thi%' and MSGIAIDOAN=8
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%ung ho%' and MSGIAIDOAN=8
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%dang ky%' and MSGIAIDOAN = 4
update tCongVan set MSGIAIDOAN = 13 WHERE NOIDUNG_Unsign like N'%30/4%'
update tCongVan set MSGIAIDOAN = 8 WHERE NOIDUNG_Unsign like N'%bao cao%' and MSGIAIDOAN=4
UPDATE tCongVan set MSGIAIDOAN = 2 where MSGIAIDOAN = 6 and (NGAYCV <= convert(datetime,'21/10/2016',103))
UPDATE tCongVan set MSGIAIDOAN = 2 where MSGIAIDOAN = 7 and (NGAYCV <= convert(datetime,'01/11/2016',103))

update tCongVan set noidung = REPLACE(noidung, N' phê duyệt',N'Phê duyệt') where noidung like N' phê duyệt%'
update tCongVan set noidung = REPLACE(noidung, N'sữa',N'sửa')
update tCongVan set noidung = NOIDUNG_Unsign where noidung='TKBVTC'
update tCongVan set noidung = NOIDUNG_Unsign where noidung='GPMB'
update tCongVan set noidung = REPLACE(noidung, N'Quyết định về việc',N'')
update tCongVan set noidung = REPLACE(noidung, N'Quyết định',N'') WHERE MSLOAICV=4
update tCongVan set noidung = REPLACE(noidung, N'Thông báo về việc',N'') WHERE MSLOAICV=6
update tCongVan set noidung = UPPER(left(noidung,1)) + SUBSTRING(noidung,2, len(noidung)-1)

UPDATE tCongVan SET NOIDUNG_UNSIGN = dbo.fConvertToUnsign(NOIDUNG)

-- Update cây công văn
use QLHS_HP
UPDATE tCongVan SET MSCVCHA='' --Reset tCongVan
UPDATE tCongVan SET MSCVCHA = gd.MSCVGOC FROM tGiaiDoan gd WHERE tCongVan.MSGIAIDOAN = gd.MSGIAIDOAN
UPDATE tCongVan SET MSCVCHA ='' WHERE MSCV IN (SELECT MSCVGOC FROM tGiaiDoan)


SELECT * FROM TCONGVAN ORDER BY MSGIAIDOAN

select * from tGiaiDoan


update tCongVan set MSCVCHA = N'F1279' WHERE MSGIAIDOAN = 1
update tCongVan set MSCVCHA = N'F1218' WHERE MSGIAIDOAN = 2
update tCongVan set MSCVCHA = N'F41' WHERE MSGIAIDOAN = 3
update tCongVan set MSCVCHA = N'F49' WHERE MSGIAIDOAN = 4
update tCongVan set MSCVCHA = N'F1231' WHERE MSGIAIDOAN > 4

update tCongVan set MSCVCHA = N'' WHERE MSCV = N'F1279'
update tCongVan set MSCVCHA = N'' WHERE MSCV = N'F1218'
update tCongVan set MSCVCHA = N'' WHERE MSCV = N'F41'
update tCongVan set MSCVCHA = N'' WHERE MSCV = N'F49'
update tCongVan set MSCVCHA = N'' WHERE MSCV = N'F1231'


