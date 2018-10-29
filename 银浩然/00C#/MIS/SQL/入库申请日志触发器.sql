create trigger Purchase_Insert
on [dbo].[Tbl_Purchase]
for insert
as
--业务员添加一条新入库申请时，创建对应的日志

go



create trigger Purchase_Update
on [dbo].[Tbl_Purchase]
for update
as
--业务员
--修改申请日志  [PurchaseDate]

--店长
--审核成功日志  [Examiner],[ExaminerDate],[OnProcess]=1

--保管员
--入库成功日志  [Custodian],[StockDate],[OnProcess]=2

go




