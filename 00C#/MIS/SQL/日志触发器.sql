--业务员新增入库申请的触发器
CREATE TRIGGER Purchase_Insert
ON [dbo].[Tbl_Purchase]
FOR INSERT
AS
begin
	--从新增的记录中查询出 1.业务员的工号，2.提交时间，3.入库状态，4.入库单号，5.主键
	declare @Employee nvarchar(50)
	declare @purchaseDate datetime
	declare @OnProcess int
	declare @Serialnumber nvarchar(13)
	declare @ID int

	declare @LogContent nvarchar(max)  --日志内容
	--定义变量存放以上的内容
	select @Employee = clerk,@purchaseDate = purchaseDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted

	--从Inserted查询出值 生成日志内容 存放到变量中
	set @LogContent = CONVERT(nvarchar,@purchaseDate,120)+'，工号:'+@Employee+'，提交入库申请，流水号:'+@Serialnumber

	--将以上的内容插入一条日志记录
	insert Tbl_Log values(@ID,@LogContent,@purchaseDate,'业务员日志')
end


--测试，添加一条入库申请
insert Tbl_Purchase values(dbo.GetPurchaserSerialNo(),'',getdate(),2,'1001',null,null,null,null,0)

SELECT *  FROM [Tbl_Purchase]
select * from [dbo].[Tbl_Log]


--更新触发器
alter TRIGGER Purchase_Update
ON [dbo].[Tbl_Purchase]
FOR update
AS
begin
	--从新增的记录中查询出 1.业务员的工号，2.提交时间，3.入库状态，4.入库单号，5.主键
	declare @Employee nvarchar(50)
	declare @Date datetime
	declare @OnProcess int
	declare @Serialnumber nvarchar(13)
	declare @ID int
	declare @LogContent nvarchar(max)  --日志内容

	--业务员修改,业务员修改必然会更新提交时间[PurchaseDate]
	if(UPDATE([PurchaseDate]))
	begin
	   select @Employee = clerk,@Date = purchaseDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'，工号:'+@Employee+'，修改入库申请，流水号:'+@Serialnumber
	   insert Tbl_Log values(@ID,@LogContent,@Date,'业务员日志')
	end

	--主管修改、审核、撤销
	if(UPDATE([ExaminerDate]))
	begin
	   select @Employee = Examiner,@Date = ExaminerDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   if(@OnProcess=0)
	   begin
	   --修改
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'，工号:'+@Employee+'，修改入库申请，流水号:'+@Serialnumber
	   end
	   if(@OnProcess=1)
	   begin
	   --审核
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'，工号:'+@Employee+'，审核入库申请，流水号:'+@Serialnumber+'审核成功'
	   end
	   if(@OnProcess=-1)
	   begin
	   --撤销
	   set @LogContent = CONVERT(nvarchar,@Date,120)+'，工号:'+@Employee+'，撤销入库申请，流水号:'+@Serialnumber+'撤销成功'
	   end
	   insert Tbl_Log values(@ID,@LogContent,@Date,'主管日志')
	end
	--仓管入库
	if(UPDATE([StockDate]))
	begin
	   select @Employee = Custodian,@Date = StockDate,@OnProcess=OnProcess,@Serialnumber=Serialnumber,@ID=PurchaseID from inserted
	   if(@OnProcess=2)
	   begin
	     set @LogContent = CONVERT(nvarchar,@Date,120)+'，工号:'+@Employee+'，商品入库，流水号:'+@Serialnumber+'入库成功'
		 insert Tbl_Log values(@ID,@LogContent,@Date,'仓管日志')
	   end
	end
end