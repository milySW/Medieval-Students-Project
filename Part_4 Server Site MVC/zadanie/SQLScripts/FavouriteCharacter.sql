CREATE TABLE FavouriteCharacter(
    ID INT NOT NULL PRIMARY KEY IDENTITY,
	FavourtieClass VARCHAR(31) NOT NULL,
	PlayerID INT FOREIGN KEY(PlayerID) REFERENCES AvailablePoints(ID)
	);