CREATE TABLE Clients 
	(
	ClientId INT PRIMARY KEY,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Phone VARCHAR(12)
	)

CREATE TABLE Mechanics 
	(
	MechanicId INT PRIMARY KEY,
	FirstName NVARCHAR(50),
	LastName NVARCHAR(50),
	Address NVARCHAR(255)
	)
	
CREATE TABLE Models 
	(
	ModelId INT PRIMARY KEY,
	Name NVARCHAR(50) UNIQUE
	)

CREATE TABLE Jobs 
	(
	JobId INT PRIMARY KEY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId),
	Status NVARCHAR(13) DEFAULT ('Pending')
	CHECK (Status IN ('Pending','In Progress','Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId),
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId) NULL,
	IssueDate DATE,
	FinishDate DATE NULL,
	)

CREATE TABLE Orders
	(
	OrderId INT PRIMARY KEY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATE NULL,
	Delivered BIT DEFAULT 0
	)

CREATE TABLE Vendors
	(
	VendorId INT PRIMARY KEY,
	Name NVARCHAR(50) UNIQUE
	)

CREATE TABLE Parts
	(
	PartId INT PRIMARY KEY,
	SerialNumber NVARCHAR(50) UNIQUE,
	Description NVARCHAR(255) NULL,
	Price DECIMAL CHECK (Price > 0),
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT 0 CHECK (StockQty > 0)
	)

CREATE TABLE OrderParts
	(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	CONSTRAINT PK_Order_Parts PRIMARY KEY(OrderId,PartId),
	Quantity INT DEFAULT 1 CHECK (Quantity > 0),
	)

CREATE TABLE PartsNeeded
	(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	CONSTRAINT PK_Jobs_Parts PRIMARY KEY(JobId,PartId),
	Quantity INT DEFAULT 1 CHECK (Quantity > 0),
	)