create table cova (
id int identity(1,1) not null primary key,
x int,
y int
)
go

insert into cova (x,y) values (-1,-1);
insert into cova (x,y) values (0,1);
insert into cova (x,y) values (1,3);
insert into cova (x,y) values (2,5);
