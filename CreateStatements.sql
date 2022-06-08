CREATE TABLE Category(
	CategoryId INTEGER PRIMARY KEY,
	CategoryName VARCHAR(100)
);

DELETE FROM Product;

DROP TABLE Product;

CREATE TABLE Product(
	ProductId INTEGER PRIMARY KEY,
	ProductName VARCHAR(100),
	Price FLOAT,
	CategoryId INTEGER,
	FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
);

INSERT INTO Product (ProductId, ProductName, Price, CategoryId) 
VALUES (1, 'Stovetop Popper', 12.99, 1);

INSERT INTO Product (ProductId, ProductName, Price, CategoryId) 
VALUES (2, 'Dish rack', 21.99, 2);

INSERT INTO Product (ProductId, ProductName, Price, CategoryId) 
VALUES (3, 'Oven mitts', 5.99, 2);

INSERT INTO Product (ProductId, ProductName, Price, CategoryId) 
VALUES (4, 'CD Player', 42.99, 1);

INSERT INTO Product (ProductId, ProductName, Price, CategoryId) 
VALUES (5, 'Keyboard', 22.99, 1);
