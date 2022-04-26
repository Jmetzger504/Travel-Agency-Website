drop table Itinerary;
drop table cruiseTicket;
drop table Voyages;
drop table Customer;
drop table cruiseShip;

CREATE TABLE [cruiseShip] (
  [Id] int identity(1,1) primary key,
  [availableRooms] int,
  [totalRooms] int,
  [portCity] varchar(50),
  [portState] varchar(50),
  [shipName] varchar(50),
  [cruiseLine] varchar(50),
  [destination] varchar(30),
  [adultPrice] money,
  [childPrice] money,
  [roomPrice] money,
  [tripLength] int,
  [img1] varchar(50),
  [img2] varchar(50),
  [img3] varchar(50),
  [img4] varchar(50),
);

CREATE TABLE [Voyages] (
  Id int identity(1,1) primary key,
  [shipId] int foreign key references cruiseShip(Id),
  [departure] datetime,
  [arrival] datetime,
  CONSTRAINT [FK_Voyages.shipId]
    FOREIGN KEY ([shipId])
      REFERENCES [cruiseShip]([Id])
);

CREATE TABLE [Customer] (
  [Id] int primary key,
  [email] varchar(50),
  [password] varchar(50),
  [firstName] varchar(50),
  [lastName] varchar(50),
  [streetAddress] varchar(50),
  [city] varchar(50),
  [state] varchar(50),
  [zipCode] int,
  [balance] money,
);



CREATE TABLE [cruiseTicket] (
  [Id] int identity(1,1) primary key,
  [voyageId] int foreign key references Voyages(Id),
  [custID] int foreign key references Customer(Id),
  [shipID] int foreign key references cruiseShip(Id),
  [Rooms] int,
  [childGuests] int,
  [adultGuests] int,
  [totalCost] money,
);



CREATE TABLE [Itinerary] (
  [shipId] int foreign key references cruiseShip(Id),
  [day] int,
  [city] varchar(50),
  [stateCountry] varchar(50),
  [portTime] varchar(10)
);


insert into Customer(Id,email,password,firstName,lastName,streetAddress,city,state,zipCode,balance) values (1,'julian@gmail.com','myPassword','Julian','Metzger','My house','New Orleans','Louisiana',70005,50000)

insert into cruiseShip(availableRooms,totalRooms,portCity,portState,shipName,cruiseLine,destination,adultPrice,childPrice,roomPrice,tripLength,img1,img2,img3,img4) values (998,1000,'New Orleans','Louisiana, United States','Glory','Carnival','Caribbean',250,100,400,8,'src\assets\images\carnivalGlory1.jpg','src\assets\images\carnivalGlory2.jpg','src\assets\images\carnivalGlory3.jpg','src\assets\images\carnivalGlory4.jpg')

insert into Voyages values (1,'20220430 10:00:00 AM','20220506 10:00:00 AM')
insert into Voyages values (1,'20220508 10:00:00 AM','20220515 10:00:00 AM')

insert into Itinerary values(1,1,'New Orleans','Louisiana, United States','10:00am')
insert into Itinerary values(1,2,'At Sea','','')
insert into Itinerary values(1,3,'Progreso','Mexico','8:00am')
insert into Itinerary values(1,4,'At Sea','','')
insert into Itinerary values(1,5,'Belize City','Belize','8:00am')
insert into Itinerary values(1,6,'Cozumel','Mexico','7:00am')
insert into Itinerary values(1,7,'At Sea','','')
insert into Itinerary values(1,8,'New Orleans','Louisiana, United States','10:00am')

insert into cruiseTicket(voyageId,custID,shipID,Rooms,childGuests,adultGuests,totalCost) values(1,1,1,2,3,2,1350)
