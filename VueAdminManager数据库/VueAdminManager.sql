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
-----用户-------
create table AdminUser
(
UserID int primary key identity(1,1),
UserName nvarchar(20),
UserPhone nvarchar(11),
UserPwd nvarchar(20)
)
go
insert into AdminUser values('张三','15139959700','123456')
insert into AdminUser values('李四','13783184129','123456')
insert into AdminUser values('王五','15138750150','123456')
select * from AdminUser where UserPhone='15139959700' and UserPwd='123456'
-------货物类别---------
create table GoodsType
(
TypeID int primary key identity(1,1),
TypeName nvarchar(20),
)
go
insert into GoodsType values('肤用化妆品')
insert into GoodsType values('发用化妆品')
insert into GoodsType values('美容化妆品')
insert into GoodsType values('特殊功能化妆品')
select * from GoodsType
update GoodsType set TypeName='发用化妆品' where TypeID=2
-----供应商-------
create table Buyer
(
BuyID int primary key identity(1,1),
BuyerName nvarchar(20),
HZTime date
)
go
insert into Buyer values('欧束','1998-12-30')
insert into Buyer values('夫兰雅','2002-09-06')
insert into Buyer values('美宝莲','2010-05-24')
select * from Buyer order by HZTime desc
-------存放地点---------
create table CFplace
(
CFID int primary key identity(1,1),
CFPlaces nvarchar(50)
)
go
insert into CFplace values('洛阳')
insert into CFplace values('平顶山')
insert into CFplace values('上海')
update CFplace set CFPlaces='洛阳' where CFID=1
------部门--------
create table department
(
DepartID int primary key identity(1,1),
Departments nvarchar(50)
)

--------货物-----------
create table Goods
(
GoodsID int primary key identity(1,1),
TypeID int foreign key references GoodsType(TypeID),
CFID int foreign key references CFplace(CFID),
GoodsName nvarchar(50),
img text
)
insert into Goods values(1,1,'面霜','1.jpg')
insert into Goods values(1,1,'浴剂','2.jpg')
insert into Goods values(2,1,'香波','3.jpg')
insert into Goods values(2,2,'摩丝','4.jpg')
insert into Goods values(3,2,'化妆水','5.jpg')
insert into Goods values(3,2,'精华液','6.jpg')
insert into Goods values(4,3,'粉底霜','7.jpg')
insert into Goods values(4,3,'润面霜','8.jpg')
select * from Goods

select * from CFplace
select Goods.GoodsName,Goods.img,GoodsType.TypeName,CFPlaces from Goods,GoodsType,CFplace where Goods.TypeID=GoodsType.TypeID and Goods.CFID=CFplace.CFID
----------管理员-------------
create table Admins
(
AdminID int ,
AdminPwd nvarchar(50)
)
insert into Admins values(10086,'123456')