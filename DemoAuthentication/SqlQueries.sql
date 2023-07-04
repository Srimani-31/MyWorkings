create table [UserTable] (Id varchar(10) primary key not null,
[Name] varchar(50) not null, [Email] varchar(50) not null,  [Password] binary(64) not null)

drop table [user]

select * from UserTable


insert into UserTable values ('user001','person1','p1@gmail.com',HASHBYTES('SHA2_512','person1'))