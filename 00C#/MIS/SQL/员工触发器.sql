--����Ա���Ĵ�����
CREATE TRIGGER Employee_Insert
   ON [dbo].[Tbl_Employee]
   for insert
AS 
BEGIN
	declare @Employeename nvarchar(50)
	declare @ID int
	select @ID=employeeid,@employeename=employeename from inserted
	set @Employeename ='����Ա��,'+ @Employeename
	insert Tbl_Log values(@ID,@Employeename,GETDATE(),'')
END
GO
--ɾ��Ա���Ĵ�����
create trigger Employee_Delete
on [dbo].[Tbl_Employee]
for delete
as
    declare @Employeename nvarchar(50)
	declare @ID int
	select @ID=employeeid,@employeename=employeename from deleted
	set @Employeename ='ɾ��Ա��,'+ @Employeename
	insert Tbl_Log values(@ID,@Employeename,GETDATE(),'')
	go

--���´���������������޸ģ�������־
alter trigger Emlpoyee_Update
on [dbo].[Tbl_Employee]
for update
as
declare @Employeename nvarchar(50)
   declare @ID int
   declare @Content nvarchar(200)
   select @ID=employeeid,@employeename=employeename from inserted  --���޸ĺ��ѯ���������ֶ�

if(UPDATE([PassWord]))
begin   
   set @Content ='�����޸�,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([BaseFunction]))
begin
   set @Content ='��������ά��Ȩ���޸�,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([PurchaseFunction]))
begin
   set @Content ='������ά��Ȩ���޸�,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end

if(UPDATE([EmployeeFunction]))
begin
   set @Content ='Ա������Ȩ���޸�,'+ @Employeename
   insert Tbl_Log values(@ID,@Content,GETDATE(),'')
end
