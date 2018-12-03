--新增员工的触发器
CREATE TRIGGER Employee_Insert
   ON [dbo].[Tbl_Employee]
   for insert
AS 
BEGIN
	declare @Employeename nvarchar(50)
	declare @ID int
	select @ID=employeeid,@employeename=employeename from inserted
	set @Employeename ='新增员工,'+ @Employeename
	insert Tbl_Log values(@ID,@Employeename,GETDATE(),'')
END
GO
--删除员工的触发器
create trigger Employee_Delete
on [dbo].[Tbl_Employee]
for delete
as
    declare @Employeename nvarchar(50)
	declare @ID int
	select @ID=employeeid,@employeename=employeename from deleted
	set @Employeename ='删除员工,'+ @Employeename
	insert Tbl_Log values(@ID,@Employeename,GETDATE(),'')
	go

--更新触发器，如果密码修改，保留日志
alter trigger Emlpoyee_Update
on [dbo].[Tbl_Employee]
for update
as
declare @Employeename nvarchar(50)
   declare @ID int
   declare @Content nvarchar(200)
   select @ID=employeeid,@employeename=employeename from inserted  --从修改后查询出这两个字段

if(UPDATE([PassWord]))
begin   
   set @Content ='密码修改,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([BaseFunction]))
begin
   set @Content ='基础数据维护权限修改,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([PurchaseFunction]))
begin
   set @Content ='入库管理维护权限修改,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([EmployeeFunction]))
begin
   set @Content ='员工管理权限修改,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end
