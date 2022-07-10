create database FStore

use FStore

create table Members(
MemberId int PRIMARY KEY,
Email varchar(100) NOT NULL,
CompanyName varchar(40) NOT NULL,
City varchar(15) NOT NULL, 
Country varchar(15) NOT NULL,
Password varchar(30) NOT NULL)

create table Orders(
OrderId int PRIMARY KEY,
MemberId int FOREIGN KEY REFERENCES Members(MemberId),
OrderDate datetime NOT NULL,
RequiredDate datetime,
ShippedDate datetime,
Freight money)

create table Products(
ProductId int PRIMARY KEY,
CategoryId int NOT NULL,
ProductName varchar(40) NOT NULL,
Weight varchar(20) NOT NULL,
UnitPrice money NOT NULL,
UnitsInStock int NOT NULL)

create table OrderDetails(
OrderId int NOT NULL,
ProductId int NOT NULL,
UnitPrice money NOT NULL,
Quantity int NOT NULL,
Discount float NOT NULL,
CONSTRAINT Primarykey PRIMARY KEY (OrderId, ProductId),
FOREIGN KEY (OrderId) REFERENCES Orders(OrderId),
FOREIGN KEY (ProductId) REFERENCES Products(ProductId))


INSERT INTO Members VALUES (2, 'user@fstore.com', 'FPT Company', 'Ho Chi Minh', 'Vietnam', 'user@@')
INSERT INTO Members VALUES (3, 'trieudh@fstore.com', 'FPT Company', 'Ho Chi Minh', 'Vietnam', 'user@@')
INSERT INTO Members VALUES (4, 'linhnpn@fstore.com', 'FPT Company', 'Ho Chi Minh', 'Vietnam', 'user@@')
INSERT INTO Members VALUES (5, 'hoanghdm@fstore.com', 'FPT Company', 'Ho Chi Minh', 'Vietnam', 'user@@')
INSERT INTO Members VALUES (6, 'thinhdnp@fstore.com', 'FPT Company', 'Ho Chi Minh', 'Vietnam', 'user@@')

INSERT INTO Orders VALUES (1, 2, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders VALUES (2, 3, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders VALUES (3, 4, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders VALUES (4, 5, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders VALUES (5, 6, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders (OrderId, MemberId, OrderDate) VALUES (6, 2, '20120618 10:34:09 AM')
INSERT INTO Orders VALUES (7, 3, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)
INSERT INTO Orders (OrderId, MemberId, OrderDate) VALUES (8, 4, '20120618 10:34:09 AM')
INSERT INTO Orders (OrderId, MemberId, OrderDate) VALUES (9, 5, '20120618 10:34:09 AM')
INSERT INTO Orders VALUES (10, 6, '20120618 10:34:09 AM', '20120618 10:34:09 AM', '20120618 10:34:09 AM', 30000)

INSERT INTO Products VALUES (1, 1, 'Bap luoc', '300', 30000, 20)
INSERT INTO Products VALUES (2, 1, 'Ngo luoc', '300', 240000, 17)
INSERT INTO Products VALUES (3, 2, 'Khoai luoc', '300', 22000, 22)
INSERT INTO Products VALUES (4, 2, 'San luoc', '300', 14000, 21)
INSERT INTO Products VALUES (5, 1, 'Thit luoc', '300', 34000, 2)

INSERT INTO OrderDetails VALUES (1, 1, 90000, 3, 0)
INSERT INTO OrderDetails VALUES (1, 2, 480000, 2, 0)
INSERT INTO OrderDetails VALUES (2, 3, 44000, 2, 0)
INSERT INTO OrderDetails VALUES (2, 4, 28000, 2, 0)
INSERT INTO OrderDetails VALUES (3, 5, 34000, 1, 0)
INSERT INTO OrderDetails VALUES (3, 1, 60000, 2, 0)
INSERT INTO OrderDetails VALUES (4, 2, 240000, 1, 0)
INSERT INTO OrderDetails VALUES (4, 3, 22000, 1, 0)
INSERT INTO OrderDetails VALUES (5, 5, 34000, 1, 0)
INSERT INTO OrderDetails VALUES (5, 2, 216000, 1, 0.1)
