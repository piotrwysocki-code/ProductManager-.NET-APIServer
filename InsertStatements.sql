INSERT INTO dbo.Category (CategoryId, CategoryName) 
VALUES (1, 'Electronics');

INSERT INTO dbo.Category (CategoryId, CategoryName) 
VALUES (2, 'Housewares');

INSERT INTO dbo.Product (ProductId, ProductName, Price, CategoryId) 
VALUES (1, 'Stovetop Popper', 12.99, 1);

INSERT INTO dbo.Product (ProductId, ProductName, Price, CategoryId) 
VALUES (2, 'Dish rack', 21.99, 2);

INSERT INTO dbo.Product (ProductId, ProductName, Price, CategoryId) 
VALUES (3, 'Oven mitts', 5.99, 2);

INSERT INTO dbo.Product (ProductId, ProductName, Price, CategoryId) 
VALUES (4, 'CD Player', 42.99, 1);

INSERT INTO dbo.Product (ProductId, ProductName, Price, CategoryId) 
VALUES (5, 'Keyboard', 22.99, 1);