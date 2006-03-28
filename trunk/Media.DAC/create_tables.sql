CREATE TABLE general_information (
	MediaId integer primary key, 	
	Description varchar(2000), 
	Cast varchar(2000),
	Genre varchar(400),
	Date DateTime,
	Director varchar(400),
	Length varchar(40),
	Country varchar(40),
	Rating varchar(40)
)	
; insert into general_information values (1, 'something', 'somecast', 'sci-fi', '2005-12-08', 'steven spielberg', '104 minutes', 'uzbekistan', 'ma')
