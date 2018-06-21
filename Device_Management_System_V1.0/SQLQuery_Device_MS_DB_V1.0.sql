create database DB_Device_MS

use DB_Device_MS

create table Admin
(
	Account char(16) primary key,
	Password char(16) not null
)

create table Users
(
	Account char(16) primary key,
	Password char(16) not null,
	Scope char(1) not null
)

create table Device_Input_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)


create table Device_FlashStorage_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_ODD_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_CardReader_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
	)

create table Device_PrinterScanner_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_HUB_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_Audio_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_AccessPointStation_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_Adapter_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)


create table Device_CellPhoneTablet_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_MediaCard_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_DongleCable_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_DisplayTV_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_Switch_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)

create table Device_Others_List(
	Identifier nvarchar(6) primary key not null,
	Category nvarchar(30) not null,
	Type nvarchar(30) null,
	Size nvarchar(30) null,
	DET_info ntext null,
	Status nvarchar(12) not null,
	Qty_Inventory int not null,
	Qty_Storage int not null,
	Remake ntext null,
	Other_info ntext null
)


create table Borrow_Device_Input_List(
	Identifier nvarchar(6) foreign key references Device_Input_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_FlashStorage_List(
	Identifier nvarchar(6) foreign key references Device_FlashStorage_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_ODD_List(
	Identifier nvarchar(6) foreign key references Device_ODD_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_CardReader_List(
	Identifier nvarchar(6) foreign key references Device_CardReader_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_PrinterScanner_List(
	Identifier nvarchar(6) foreign key references Device_PrinterScanner_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_HUB_List(
	Identifier nvarchar(6) foreign key references Device_HUB_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_Audio_List(
	Identifier nvarchar(6) foreign key references Device_Audio_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_AccessPointStation_List(
	Identifier nvarchar(6) foreign key references Device_AccessPointStation_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_Adapter_List(
	Identifier nvarchar(6) foreign key references Device_Adapter_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_CellPhoneTablet_List(
	Identifier nvarchar(6) foreign key references Device_CellPhoneTablet_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_MediaCard_List(
	Identifier nvarchar(6) foreign key references Device_MediaCard_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_DongleCable_List(
	Identifier nvarchar(6) foreign key references Device_DongleCable_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_DisplayTV_List(
	Identifier nvarchar(6) foreign key references Device_DisplayTV_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_Switch_List(
	Identifier nvarchar(6) foreign key references Device_Switch_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)
create table Borrow_Device_Others_List(
	Identifier nvarchar(6) foreign key references Device_Others_List(Identifier),
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)




create table Log_Borrow_Armo(
	ID int primary key identity(1,1),
	Identifier nvarchar(6),	
	Borrower nvarchar(16) not null,
	Extension nvarchar (11) null,
	Date_of_borrowing nvarchar(12) null,
	Return_data nvarchar(12) null,
	Remake ntext null
)


select * from Users where Account='Sandy';
select * from Borrow_Device_FlashStorage_List where Return_data is NUll union all select *from Borrow_Device_ODD_List where Return_data is NUll;
select Identifier,Category,Type,Size,DET_info,Qty_Inventory,Remake from Device_Input_List
select * from Admin where Account='test';

insert into Users values('test','qwe')

update Admin set Password = 'test' where Account = 'test'

drop table Device_Input_List;
update Device_Input_List set Category = 'bt',Type = '', Size = '',DET_info = '', Status = '',Qty_Inventory = '', Qty_Storage='',Remake = '', Other_info = '' where Identifier = 'K001';
insert into Borrow_Device_Switch_List values(N'SW01',N'william',N'6812',N'0319',null,N'нч')
use master
select * from sys.databases where name='DB_Device_MS'