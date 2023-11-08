CREATE PROCEDURE [dbo].[InsertContact]
    @FullName NVARCHAR(255),
    @PhoneNumber NVARCHAR(20),
    @BirthDate DATE,
    @ContactID INT OUTPUT
AS
BEGIN
    INSERT INTO Contacts (Fullname, PhoneNumber, BirthDate)
    VALUES (@FullName, @PhoneNumber, @BirthDate);
    SET @ContactID = SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE [dbo].[GetContacts]
AS
BEGIN
    SELECT * FROM Contacts;
END
GO

CREATE PROCEDURE [dbo].[EditContact]
    @ContactID INT,
    @FullName NVARCHAR(255),
    @PhoneNumber NVARCHAR(20),
    @BirthDate DATE
AS
BEGIN
    UPDATE Contacts
    SET FullName = @FullName,
        PhoneNumber = @PhoneNumber,
        BirthDate = @BirthDate
    WHERE ContactID = @ContactID;
END
GO

CREATE PROCEDURE [dbo].[DeleteContact]
    @ContactID INT
AS
BEGIN
    DELETE FROM Contacts WHERE ContactID = @ContactID
END