drop table reviews
drop table CARINVENTORY
--table definition
create table inventory
(
    id int identity primary key,
    make nvarchar(50) not null,
    model nvarchar(50) not null,
    year nvarchar(50) not null
);

create table descriptionTable 
(
    id int identity primary key,
    rating int not null,
    Mpg nvarchar(240) not null,
    restaurantID int references restaurants(id) on delete cascade
);

insert into inventory (make, model, year, locationid) values
('Honda', 'Civic', '2010', 1);

SELECT TOP (1000) [locationid]
    ,[city]
    ,[state]
    ,[country]
FROM [dbo].[locations]

CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    FOREIGN KEY (PersonID) REFERENCES Persons(PersonID)
);

CREATE TABLE inventory (
    inventoryid int not null,
    Make nvarchar(240) not null,
    Model nvarchar(240) not null,
    Year int NOT NULL,
    locationid int not null,
    PRIMARY KEY(inventoryid),
    FOREIGN KEY (locationid) REFERENCES locations(locationid)
);