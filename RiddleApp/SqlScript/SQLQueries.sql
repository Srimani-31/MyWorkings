--creating database for the application
create database MyRiddleDatabase

--using the database
use MyRiddleDatabase

--creating user table for storing the user info
create table [User] ([Username] varchar(20) primary key,
[FullName] varchar(50) not null, [Email] varchar(50) not null, [Password] varchar(50) not null)

--creating Riddle table for storing the riddle
create table [Riddle] ([Id] int primary key identity(1,1),
[Username] varchar(20) foreign key references [User](Username) not null,
[RiddleQuestion] varchar(250) not null, [RiddleAnswer] varchar(100))

--view table rows
select * from [User]
select * from [Riddle]






