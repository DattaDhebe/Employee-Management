CREATE TABLE EmployeeTable
(
  ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(50),
  LastName varchar(50),
  Email varchar(50),
  ContactNumber varchar(50),
  City varchar(50),
  Salary varchar(50),
  JoiningDate DATE NOT NULL DEFAULT GETDATE()
);
INSERT INTO Employee VALUES ('Datta', 'Dhebe', 'hello@gmail.com', '8149277030', 'Pune', '25000', GETDATE());
INSERT INTO Employee VALUES ('apur', 'kakade', 'apur@gmail.com', '8445216457', 'Mumbai', '12000', GETDATE());
select * from Employee