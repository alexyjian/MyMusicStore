create trigger Purchase_Insert
on [dbo].[Tbl_Purchase]
for insert
as
--ҵ��Ա���һ�����������ʱ��������Ӧ����־

go



create trigger Purchase_Update
on [dbo].[Tbl_Purchase]
for update
as
--ҵ��Ա
--�޸�������־  [PurchaseDate]

--�곤
--��˳ɹ���־  [Examiner],[ExaminerDate],[OnProcess]=1

--����Ա
--���ɹ���־  [Custodian],[StockDate],[OnProcess]=2

go




