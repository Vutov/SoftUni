USE master

GO

CREATE DATABASE ATM

GO

USE ATM

GO

CREATE TABLE CardAccounts(
	Id int PRIMARY KEY IDENTITY,
	CardNumber char(10) NOT NULL,
	CardPIN char(4) NOT NULL,
	CardCash money NOT NULL,
	CHECK (CardCash >= 0)
)

GO

INSERT INTO CardAccounts VALUES('1000', 'abvd', 500);
INSERT INTO CardAccounts VALUES('1001', 'asda', 800);
INSERT INTO CardAccounts VALUES('1002', '434a', 300);
INSERT INTO CardAccounts VALUES('1003', '1234', 1500);
INSERT INTO CardAccounts VALUES('1134', 'accc', 900);
INSERT INTO CardAccounts VALUES('5320', 'a123', 480);