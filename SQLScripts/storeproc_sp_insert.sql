Create Procedure sp_insert(
@Name varchar(150),
@ICNo varchar(50),
@OldICNo varchar(50),
@ContactNo varchar(20),
@NoPlate varchar(20),
@PassNo nchar(10),
@HouseNo nchar(4),
@PurposeVisit varchar(250),
@DateTimeIn datetime,
@DateTimeOut datetime = null,
@CreateDate datetime,
@CreatedBy varchar(50)
)
AS
insert into VisitorInfo values (@Name,@ICNo,@OldICNo,@ContactNo,@NoPlate,@PassNo,@HouseNo,@PurposeVisit,@DateTimeIn,@DateTimeOut,@CreateDate,@CreatedBy)
Return

