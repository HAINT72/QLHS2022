--
-- show advanced options
EXEC sp_configure 'show advanced options', 1
GO
RECONFIGURE
GO
-- enable xp_cmdshell
EXEC sp_configure 'xp_cmdshell', 1
GO
RECONFIGURE
GO
-- hide advanced options
EXEC sp_configure 'show advanced options', 0
GO
RECONFIGURE
GO
-- 
DECLARE @sql varchar(5000) = ''
SET @sql = 'bcp "Select MSCV, SOCV, NGAYCV, NOIDUNG From [QLHS_HP].[dbo].tCongVan" queryout "D:\ExportData.xlsx" -w -T -S [192.168.1.222,1433] -U sa -P nth12345'

exec master..xp_cmdshell @sql


--export xlsx use ACE.OLEDB.12.0
INSERT INTO OPENROWSET('Microsoft.ACE.OLEDB.12.0', 'Excel 12.0;Database=D:\Solution\SQL\SQLExtra\ExportExcel\ExportExcelC2.xlsx;', 'SELECT * FROM [Sheet1$]')
SELECT * FROM [DESKTOP-U30OAKD].[ManagerStudent].[dbo].Student

SELECT @@SERVERNAME
USE QLHS_DN
