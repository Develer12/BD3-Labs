go 
use WHiring;
-- T1
go
CREATE TABLE HUser
(
	hid hierarchyid NOT NULL,
	userId int NOT NULL,
	userName nvarchar(50) NOT NULL,
	CONSTRAINT PK_HID PRIMARY KEY CLUSTERED ([hid] ASC)
);

go
insert into HUser(hid, userId,userName) values (hierarchyid::GetRoot(), 1, 'User1');


declare @id hierarchyid
select @id = max(hid) from HUser
where hid.GetAncestor(1) = hierarchyid::GetRoot()

select * from HUser;

-- T2
GO  
CREATE PROCEDURE SelectRoot(@level int)    
AS   
BEGIN  
   select hid.ToString(), * from HUser where hid.GetLevel() = @level;
END;
  
GO  
exec SelectRoot 1;

-- T3
GO  
CREATE PROCEDURE AddRoot(@UserId int,@UserName nvarchar(50))   
AS   
BEGIN  
declare @Id hierarchyid
declare @phId hierarchyid
select @phId = (SELECT hid FROM HUser WHERE UserId = @UserId);

select @Id = MAX(hid) from HUser where hid.GetAncestor(1) = @phId

insert into HUser values( @phId.GetDescendant(@id, null),@UserId,@UserName);
END;  

GO  
exec AddRoot 1, 'User12';
select * from HUser;


-- T4
go
CREATE PROCEDURE MoveRoot(@old int, @new int )
AS  
BEGIN  
DECLARE @nold hierarchyid, @nnew hierarchyid  
SELECT @nold = hid FROM HUser WHERE UserId = @old ;  
  
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE  
BEGIN TRANSACTION  
SELECT @nnew = hid FROM HUser WHERE UserId = @new ; 
  
SELECT @nnew = @nnew.GetDescendant(max(hid), NULL)   
FROM HUser WHERE hid.GetAncestor(1)=@nnew ; 
UPDATE HUser   
SET hid = hid.GetReparentedValue(@nold, @nnew)   
WHERE hid.IsDescendantOf(@nold) = 1 ;   
 commit;
  END ;  
  
go
exec MoveRoot 1,2
select hid.ToString(), hid.GetLevel(), * from HUser;