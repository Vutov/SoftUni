USE ATM

CREATE TABLE TransactionHistory (
	Id int PRIMARY KEY IDENTITY,
	CardNumber char(10) NOT NULL,
	TransactionDate date NOT NULL,
	Amount money NOT NULL
)