/*CREATE PROCEDURE spDisplayData
AS
BEGIN
		SELECT * FROM StudentInfor
END



CREATE PROCEDURE spUpdateInfor
(
	@StudentNumber INT,  @FirstName VARCHAR(20), @LastName VARCHAR(20), @Image IMAGE, @DateOfBirth VARCHAR(20), @Gender VARCHAR(20), @Phone VARCHAR(20),
	@Address VARCHAR(50), @Module VARCHAR(20)
)
AS
BEGIN
		UPDATE StudentInfor SET StudentNumber =@StudentNumber, FirstName = @FirstName, LastName = @LastName, Image =@Image, DateOfBirth =@DateOfBirth, 
		Gender =@Gender, Phone = @Phone, Address =@Address, Module =@Module
		WHERE StudentNumber =@StudentNumber
END

Delete student from the StudentInfor table
CREATE PROCEDURE spDeleteInfor
(
	@StudentNumber INT
)
AS
BEGIN
	DELETE FROM StudentInfor
	WHERE StudentNumber =@StudentNumber
END



EXECUTE spDisplayData

CREATE PROCEDURE spSearchInfor
(
	@StudentNumber INT
)
AS
BEGIN
	SELECT * FROM StudentInfor
	WHERE StudentNumber =@StudentNumber
END

select * from StudentInfor



CREATE PROCEDURE spDisplayModule

AS
BEGIN
		SELECT * FROM ModuleInfor
END

CREATE PROCEDURE spSearchModule
(
	@ModuleCode NVARCHAR(20)
)
AS
BEGIN
	SELECT * FROM ModuleInfor
	WHERE ModuleCode = @ModuleCode
END
*/

