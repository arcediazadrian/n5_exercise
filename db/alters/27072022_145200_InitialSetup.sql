--USING SQL SERVER 2019
CREATE TABLE PermissionTypes(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Description TEXT NOT NULL
);

CREATE TABLE Permissions(
    Id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    EmployeeFirstName TEXT NOT NULL,
    EmployeeLastName TEXT NOT NULL,
    PermissionType INT FOREIGN KEY REFERENCES PermissionTypes(Id),
    GrantedDate DATE NOT NULL
);