--1.
select distinct top 5 username from TBL_User

select top 5 * from TBL_User

--2.
select  top 2 userid as ����֤��, UserName as ����, sex as �Ա� into Tbl_SelectResult1 from TBL_User where UserName like '��%'
select * from Tbl_SelectResult1

--3.
select count(*) from TBL_BookInfo

--4.
select publisher as ������,min([PageCount]) as ҳ�� into TBL_SelectResult2 from TBL_BookInfo group by Publisher order by ҳ��
select * from Tbl_SelectResult2

--5.
select bookname as ����,(year(GETDATE())-year(publishdate)) as ���� from TBL_BookInfo 

--6.
select publisher as ������,count(*) as ���� into TBL_SelectResult3 from TBL_BookInfo group by Publisher having count(*)>=2
select * from Tbl_SelectResult3

--7
select sex,count(*) from tbl_user group by Sex

--8
select top 3 with ties publisher as ������,count(*) as ���� from TBL_BookInfo group by Publisher order by ����
