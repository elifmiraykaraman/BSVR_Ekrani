-- Customers tablosuna Email kolonu ekler.
-- Bu scripti bir kez SQL Server'da çalıştırın.
IF NOT EXISTS (
    SELECT 1 FROM sys.columns
    WHERE object_id = OBJECT_ID('Customers') AND name = 'Email'
)
BEGIN
    ALTER TABLE Customers ADD Email NVARCHAR(254) NULL;
    PRINT 'Email kolonu eklendi.';
END
ELSE
BEGIN
    PRINT 'Email kolonu zaten mevcut.';
END
