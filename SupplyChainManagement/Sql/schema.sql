CREATE TABLE IF NOT EXISTS Item  (
	Id int not null primary key,
	Type varchar(255) not null,
	Description varchar(255) not null,
	Value real not null,
	Stock int not null,

	DiscountQuantity int,
	OrderCosts real,
	ProcureLeadTime real,
	ProcureLeadTimeDeviation real
);

CREATE TABLE IF NOT EXISTS ChildToProduct (
	Child_Id int not null,
	Product_Id int not null,
	Quantity int not null,
	primary key (Child_Id, Product_Id)
);

CREATE TABLE IF NOT EXISTS Workplace (
	Id int not null primary key,
	JobDescription varchar(255),
	LaborCostsFirstShift real not null,
	LaborCostsSecondShift real not null,
	LaborCostsThirdShift real not null,
	LaborCostsOvertime real not null
);

CREATE TABLE IF NOT EXISTS ItemJob (
	Id int not null primary key,
	Workplace_Id int,
	Product_Id int,
	SetupTime real not null,
	ProductionTimePerPiece real not null,
	NextItemJob_Id int,
	foreign key (NextItemJob_Id) references ItemJob (Id),
	foreign key (Workplace_Id) references Workplace (Id),
	foreign key (Product_Id) references Item (Id),
	unique (Workplace_Id, Product_Id)
);
