CREATE DATABASE [PRO_XY];

DROP DATABASE [PRO_XY]

CREATE TABLE [Roles] (

    [Id] INT PRIMARY KEY IDENTITY(1,1),

    [Role_Name] VARCHAR(255) UNIQUE NOT NULL,

    Description TEXT

);

CREATE TABLE [Users](

    [Id] INT PRIMARY KEY IDENTITY(1,1),

    [Name] VARCHAR(255) NOT NULL,

    [User_Name] VARCHAR(255) UNIQUE NOT NULL,

    [Password] VARBINARY(255) NOT NULL,

    [Address] VARCHAR(255),

    [Phone_No] VARCHAR(20),

    [Role_Id] INT,

    FOREIGN KEY (Role_Id) REFERENCES [Roles]([Id])

);
DROP TABLE [Users]

CREATE TABLE [Dashboards] (

    [Id] UNIQUEIDENTIFIER PRIMARY KEY ,

    [Json_Value] varchar(Max) NOT NULL

);
DROP TABLE [Dashboards]
CREATE TABLE [SharedDashboards] (

    [Id] INT PRIMARY KEY IDENTITY(1,1),

    Dashboard_Id UNIQUEIDENTIFIER,

    [User_Id] INT,

    FOREIGN KEY ([User_Id]) REFERENCES [Users](Id),

    FOREIGN KEY (Dashboard_Id) REFERENCES [Dashboards]([Id])

);
drop table SharedDashboard
--roles

INSERT INTO [Roles] ( [Role_Name], [Description])

VALUES ('Admin', 'Full Access');
 
INSERT INTO [Roles] ( [Role_Name], [Description])

VALUES ('CIO', 'Read Only');
 
INSERT INTO [Roles] ( [Role_Name], [Description])

VALUES ('Data Engineer', 'Read Only');
 
INSERT INTO [Roles] ( [Role_Name], [Description])

VALUES ( 'Data Scientist', 'Read Only');

--users

INSERT INTO [Users] ( [Name], [User_Name], [Password], [Address], [Phone_No], [Role_Id])

VALUES ( 'Admin', 'admin@gmail.com',HASHBYTES('SHA2_256','admin123' ), 'Texas', '1234245', 1);
 
INSERT INTO [Users] ( [Name], [User_Name], [Password], [Address], [Phone_No], [Role_Id])

VALUES ( 'John CIO', 'john@gmail.com', HASHBYTES('SHA2_256','12345' ), 'Texas', '1234245', 2);
 
INSERT INTO [Users] ( [Name], [User_Name], [Password], [Address], [Phone_No], [Role_Id])

VALUES ( 'Mike DE', 'Mike@gmail.com', HASHBYTES('SHA2_256','12345' ), 'Texas', '1234245', 3);
 
INSERT INTO [Users] ( [Name], [User_Name], [Password], [Address], [Phone_No], [Role_Id])

VALUES ( 'Smith DS', 'Smith@gmail.com',HASHBYTES('SHA2_256','12345' ), 'Texas', '1234245', 4);

--dashboard 

INSERT INTO [Dashboards] ([Id],[Json_Value]) VALUES(NEWID(),'[
  {
    "state": "Illinois",
    "salesInState": 80167
  },
  {
    "state": "Oklahoma",
    "salesInState": 19684
  },
  {
    "state": "Wisconsin",
    "salesInState": 32115
  },
  {
    "state": "Pennsylvania",
    "salesInState": 116512
  },
  {
    "state": "Maine",
    "salesInState": 1271
  },
  {
    "state": "Massachusetts",
    "salesInState": 28635
  },
  {
    "state": "Ohio",
    "salesInState": 78259
  },
  {
    "state": "Arizona",
    "salesInState": 35283
  },
  {
    "state": "Oregon",
    "salesInState": 17432
  },
  {
    "state": "Wyoming",
    "salesInState": 1604
  },
  {
    "state": "Louisiana",
    "salesInState": 9218
  },
  {
    "state": "New Hampshire",
    "salesInState": 7293
  },
  {
    "state": "Virginia",
    "salesInState": 70637
  },
  {
    "state": "New York",
    "salesInState": 310877
  },
  {
    "state": "South Dakota",
    "salesInState": 1316
  },
  {
    "state": "Maryland",
    "salesInState": 23706
  },
  {
    "state": "California",
    "salesInState": 457688
  },
  {
    "state": "Missouri",
    "salesInState": 22206
  },
  {
    "state": "Minnesota",
    "salesInState": 29864
  },
  {
    "state": "District of Columbia",
    "salesInState": 2866
  },
  {
    "state": "Florida",
    "salesInState": 89474
  },
  {
    "state": "Indiana",
    "salesInState": 53556
  },
  {
    "state": "Washington",
    "salesInState": 138642
  },
  {
    "state": "Delaware",
    "salesInState": 27452
  },
  {
    "state": "North Dakota",
    "salesInState": 920
  },
  {
    "state": "Connecticut",
    "salesInState": 13385
  },
  {
    "state": "New Jersey",
    "salesInState": 35765
  },
  {
    "state": "Michigan",
    "salesInState": 76270
  },
  {
    "state": "Iowa",
    "salesInState": 4580
  },
  {
    "state": "North Carolina",
    "salesInState": 55604
  },
  {
    "state": "Vermont",
    "salesInState": 8930
  },
  {
    "state": "Idaho",
    "salesInState": 4383
  },
  {
    "state": "Nebraska",
    "salesInState": 7465
  },
  {
    "state": "Georgia",
    "salesInState": 49096
  },
  {
    "state": "Mississippi",
    "salesInState": 10772
  },
  {
    "state": "Colorado",
    "salesInState": 32109
  },
  {
    "state": "Texas",
    "salesInState": 170189
  },
  {
    "state": "South Carolina",
    "salesInState": 8482
  },
  {
    "state": "West Virginia",
    "salesInState": 1210
  },
  {
    "state": "Montana",
    "salesInState": 5590
  },
  {
    "state": "Utah",
    "salesInState": 11221
  },
  {
    "state": "Tennessee",
    "salesInState": 30662
  },
  {
    "state": "Alabama",
    "salesInState": 19511
  },
  {
    "state": "Rhode Island",
    "salesInState": 22628
  },
  {
    "state": "Arkansas",
    "salesInState": 11679
  },
  {
    "state": "Nevada",
    "salesInState": 16730
  },
  {
    "state": "Kansas",
    "salesInState": 2915
  },
  {
    "state": "Kentucky",
    "salesInState": 36592
  },
  {
    "state": "New Mexico",
    "salesInState": 4784
  }
]')

INSERT into [SharedDashboards] ([Dashboard_Id],[User_Id]) values('0818092C-FC64-4D6A-9466-0AC3A9228A51',1)
 SELECT * from [Roles]
 SELECT * from [Users]
 SELECT * from [Dashboards]
 SELECT * from [SharedDashboards]

 select * from [samplesuperstore]

 delete  from [Users] where [Name]='Admin' 

 DROP DATABASE [PRO_XY]