--1.
select distinct top 5 username from TBL_User

select top 5 * from TBL_User

--2.
select  top 2 userid as 借书证号, UserName as 姓名, sex as 性别 into Tbl_SelectResult1 from TBL_User where UserName like '黄%'
select * from Tbl_SelectResult1

--3.
select count(*) from TBL_BookInfo

--4.
select publisher as 出版社,min([PageCount]) as 页数 into TBL_SelectResult2 from TBL_BookInfo group by Publisher order by 页数
select * from Tbl_SelectResult2

--5.
select bookname as 书名,(year(GETDATE())-year(publishdate)) as 年限 from TBL_BookInfo 

--6.
select publisher as 出版社,count(*) as 册数 into TBL_SelectResult3 from TBL_BookInfo group by Publisher having count(*)>=2
select * from Tbl_SelectResult3

--7
select sex,count(*) from tbl_user group by Sex

--8
select top 3 with ties publisher as 出版社,count(*) as 总数 from TBL_BookInfo group by Publisher order by 总数
