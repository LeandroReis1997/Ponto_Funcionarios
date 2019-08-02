create table Employees(
Id int identity primary key,
Name varchar(50),
CPF varchar(50),
CEP varchar(50),
telephone varchar(50),
_Address varchar(50),
City varchar(50),
_State varchar(50),
neighborhood varchar(50),
Dateirth date,
Dateregister date,
SectorId int not null
   )


   create table Sector(
   
   id int identity primary key not null,
   Name varchar(50) not null,
   Active bit
   
   )