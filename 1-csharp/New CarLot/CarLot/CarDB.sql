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

INSERT INTO CARINVENTORY (name) values
('One'), ('Two'), ('Three');

