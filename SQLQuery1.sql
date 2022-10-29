drop table Sales;
drop table SalesProd;
drop table Employees;
drop table Departments;

CREATE TABLE Sales (
    saleId int,
    saleDate Date,
    total varchar(255),
    CONSTRAINT PK_Sale PRIMARY KEY (saleId)
);

CREATE TABLE SalesProd (
    saleId int,
    productId int,
    CONSTRAINT PK_SalesProd PRIMARY KEY (saleId, productId)

);

CREATE TABLE Employees (
    employeeId int,
    deptId int,
    lastName varchar(255),
    firstName varchar(255),
    salary float,
    city varchar(255),
    CONSTRAINT PK_Employeed PRIMARY KEY (employeeId)

)

CREATE TABLE Departments (
    deptId int,
    deptName varchar(255),
    CONSTRAINT PK_Dept PRIMARY KEY (deptId)
);