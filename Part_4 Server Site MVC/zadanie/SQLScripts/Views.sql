CREATE VIEW PlayersView AS
SELECT AvailablePoints.Nick, Score.Points AS Score FROM AvailablePoints
INNER JOIN Score ON Score.PlayerID = AvailablePoints.ID WHERE Score.ID IN 
(SELECT TOP 10 ID FROM Score ORDER  BY Points);

CREATE VIEW PlayersLoggedWithLast10Logs AS
SELECT Accounts.Nick, AvailablePoints.Points, Accounts.FirstName, Accounts.LastName, Accounts.PasswordString AS Password FROM Accounts
INNER JOIN AvailablePoints ON AvailablePoints.Nick = Accounts.Nick WHERE Accounts.ID IN 
(SELECT TOP 10 UserID FROM LoginHistory ORDER  BY ID DESC);

CREATE VIEW History AS
SELECT Accounts.Nick, Accounts.FirstName, Accounts.LastName, LoginHistory.DateOfLogging AS DATE FROM Accounts
INNER JOIN LoginHistory ON Accounts.ID = LoginHistory.UserID 