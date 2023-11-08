-- Kelios galb�t naudingos funkcijos

-- Paie�ka pagal vard�
CREATE FUNCTION dbo.GetContactsByFullName (@fullName NVARCHAR(255))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Contacts WHERE FullName = @fullName
);
GO

-- Paie�ka pagal tel. nr.
CREATE FUNCTION dbo.GetContactsByPhoneNumber (@phoneNumber NVARCHAR(20))
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Contacts WHERE PhoneNumber = @phoneNumber
);
GO

-- Paie�ka pagal gimimo dat�
CREATE FUNCTION dbo.GetContactsByBirthDate (@birthDate DATE)
RETURNS TABLE
AS
RETURN (
    SELECT * FROM Contacts WHERE BirthDate = @birthDate
);
GO

-- Kontakt� kiekis
CREATE FUNCTION dbo.CountContacts ()
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*) FROM Contacts;
    RETURN @count;
END;
GO

-- Kontaktai nuo iki tam tikro am�iaus
CREATE FUNCTION dbo.GetContactsByAgeRange (@minAge INT, @maxAge INT)
RETURNS TABLE
AS
RETURN (
    SELECT * 
    FROM Contacts 
    WHERE DATEDIFF(YEAR, BirthDate, GETDATE()) BETWEEN @minAge AND @maxAge
);

/*
SELECT * FROM dbo.GetContactsByFullName('Ponas Jonas');
SELECT * FROM dbo.GetContactsByPhoneNumber('112');
SELECT * FROM dbo.GetContactsByBirthDate('1990-01-05');
SELECT dbo.CountContacts() AS ContactCount;
SELECT * FROM dbo.GetContactsByAgeRange(25, 35);
*/