--ҵ��Ա�����������Ĵ�����
CREATE TRIGGER Purchase_Insert
ON [dbo].[Tbl_Purchase]
FOR INSERT
AS
begin
	--�������ļ�¼�в�ѯ�� 1.ҵ��Ա�Ĺ��ţ�2.�ύʱ�䣬3.���״̬��4.��ⵥ�ţ�5.����
	declare @Employee nvarchar(50)
	declare @purchaseDate datetime
	declare @OnProcess int
	declare @Serialnumber nvarchar(13)
	declare @ID int

	declare @LogContent nvarchar(max)  --��־����
	--�������������ϵ�����
	select @Employee = clerk,@purchaseDate = purchaseDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted

	--��Inserted��ѯ��ֵ ������־���� ��ŵ�������
	set @LogContent = CONVERT(nvarchar,@purchaseDate,120)+'������:'+@Employee+'���ύ������룬��ˮ��:'+@Serialnumber

	--�����ϵ����ݲ���һ����־��¼
	insert Tbl_Log values(@ID,@LogContent,@purchaseDate,'ҵ��Ա��־')
end


--���ԣ����һ���������
insert Tbl_Purchase values(dbo.GetPurchaserSerialNo(),'',getdate(),2,'1001',null,null,null,null,0)

SELECT *  FROM [Tbl_Purchase]
select * from [dbo].[Tbl_Log]


--���´�����
alter TRIGGER Purchase_Update
ON [dbo].[Tbl_Purchase]
FOR update
AS
begin
	--�������ļ�¼�в�ѯ�� 1.ҵ��Ա�Ĺ��ţ�2.�ύʱ�䣬3.���״̬��4.��ⵥ�ţ�5.����
	declare @Employee nvarchar(50)
	declare @Date datetime
	declare @OnProcess int
	declare @Serialnumber nvarchar(13)
	declare @ID int
	declare @LogContent nvarchar(max)  --��־����

	--ҵ��Ա�޸�,ҵ��Ա�޸ı�Ȼ������ύʱ��[PurchaseDate]
	if(UPDATE([PurchaseDate]))
	begin
	   select @Employee = clerk,@Date = purchaseDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'������:'+@Employee+'���޸�������룬��ˮ��:'+@Serialnumber
	   insert Tbl_Log values(@ID,@LogContent,@Date,'ҵ��Ա��־')
	end

	--�����޸ġ���ˡ�����
	if(UPDATE([ExaminerDate]))
	begin
	   select @Employee = Examiner,@Date = ExaminerDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   if(@OnProcess=0)
	   begin
	   --�޸�
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'������:'+@Employee+'���޸�������룬��ˮ��:'+@Serialnumber
	   end
	   if(@OnProcess=1)
	   begin
	   --���
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'������:'+@Employee+'�����������룬��ˮ��:'+@Serialnumber+'��˳ɹ�'
	   end
	   if(@OnProcess=-1)
	   begin
	   --����
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'������:'+@Employee+'������������룬��ˮ��:'+@Serialnumber+'�����ɹ�'
	   end
	   insert Tbl_Log values(@ID,@LogContent,@Date,'������־')
	end
	--�ֹ����
	if(UPDATE([StockDate]))
	begin
	   select @Employee = Custodian,@Date = StockDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   if(@OnProcess=2)
	   begin
	     set @LogContent = CONVERT(nvarchar,@Date,120)+'������:'+@Employee+'����Ʒ��⣬��ˮ��:'+@Serialnumber+'���ɹ�'
		 insert Tbl_Log values(@ID,@LogContent,@Date,'�ֹ���־')
	   end
	end
end