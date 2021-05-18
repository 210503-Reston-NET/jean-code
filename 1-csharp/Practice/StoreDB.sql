drop table reviews
drop table restaurants
--table definition
create table items
(
    id int identity primary key,
    Brand nvarchar(50) not null,
    Type nvarchar(50) not null,
);

-- create table reviews 
-- (
--     id int identity primary key,
--     rating int not null,
--     description nvarchar(240) not null,
--     restaurantID int references restaurants(id) on delete cascade
-- );

--seeding the database
insert into items (id, Brand, Type) values
('', 'Giant', 'Mountain'),
('', 'Specialized', 'Hybrid');
