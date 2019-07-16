use master
go
create database MYAdminManager
on
(
name='MYAdminManager',filename='D:\MyDB\MYAdminManager.mdf',size=5MB
)
go
use MYAdminManager
go
-----�û�-------
create table AdminUser
(
UserID int primary key identity(1,1),
UserName nvarchar(20),
UserPhone nvarchar(11),
UserPwd nvarchar(20)
)
go
insert into AdminUser values('����','15139959700','123456')
insert into AdminUser values('����','13783184129','123456')
insert into AdminUser values('����','15138750150','123456')
select * from AdminUser where UserPhone='15139959700' and UserPwd='123456'
-------�������---------
create table GoodsType
(
TypeID int primary key identity(1,1),
TypeName nvarchar(20),
)
go
insert into GoodsType values('���û�ױƷ')
insert into GoodsType values('���û�ױƷ')
insert into GoodsType values('���ݻ�ױƷ')
insert into GoodsType values('���⹦�ܻ�ױƷ')
select * from GoodsType
update GoodsType set TypeName='���û�ױƷ' where TypeID=2
-----��Ӧ��-------
create table Buyer
(
BuyID int primary key identity(1,1),
BuyerName nvarchar(20),
HZTime date
)
go
insert into Buyer values('ŷ��','1998-12-30')
insert into Buyer values('������','2002-09-06')
insert into Buyer values('������','2010-05-24')
select * from Buyer order by HZTime desc
-------��ŵص�---------
create table CFplace
(
CFID int primary key identity(1,1),
CFPlaces nvarchar(50)
)
go
insert into CFplace values('����')
insert into CFplace values('ƽ��ɽ')
insert into CFplace values('�Ϻ�')
update CFplace set CFPlaces='����' where CFID=1
------����--------
create table department
(
DepartID int primary key identity(1,1),
Departments nvarchar(50)
)

--------����-----------
create table Goods
(
GoodsID int primary key identity(1,1),
TypeID int foreign key references GoodsType(TypeID),
CFID int foreign key references CFplace(CFID),
GoodsName nvarchar(50),
img text
)
insert into Goods values(1,1,'��˪','1.jpg')
insert into Goods values(1,1,'ԡ��','2.jpg')
insert into Goods values(2,1,'�㲨','3.jpg')
insert into Goods values(2,2,'Ħ˿','4.jpg')
insert into Goods values(3,2,'��ױˮ','5.jpg')
insert into Goods values(3,2,'����Һ','6.jpg')
insert into Goods values(4,3,'�۵�˪','7.jpg')
insert into Goods values(4,3,'����˪','8.jpg')
select * from Goods

select * from CFplace
select Goods.GoodsName,Goods.img,GoodsType.TypeName,CFPlaces from Goods,GoodsType,CFplace where Goods.TypeID=GoodsType.TypeID and Goods.CFID=CFplace.CFID
----------����Ա-------------
create table Admins
(
AdminID int ,
AdminPwd nvarchar(50)
)
insert into Admins values(10086,'123456')