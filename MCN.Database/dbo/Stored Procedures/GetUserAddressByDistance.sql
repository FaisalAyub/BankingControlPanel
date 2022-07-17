
CREATE PROCEDURE [dbo].[GetUserAddressByDistance]
	
	@Latitude FLOAT = 0,
	@Longitude FLOAT = 0,
	@Keyword  NVARCHAR(500),
	@MinDistance FLOAT = 0, 
	@MaxDistance FLOAT = 0,
	@Interests NVARCHAR(500)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @InterestTable TABLE (InterestId INT)
	INSERT INTO @InterestTable SELECT value FROM string_split( @Interests, ',')
	SELECT * FROM (
	SELECT U.Id,  U.Email, U.FirstName, U.LastName, U.Gender, I.Title, U.Latitude,U.Longitude,
	dbo.fnCalcDistanceKM(AL.Latitude, @Latitude,  AL.Longitude, @Longitude) as Distance FROM Users U 
	INNER JOIN Account.UserInterest UI ON UI.UserId = U.ID
	INNER JOIN Account.Location AL  ON AL.UserId = UI.UserId 
	INNER JOIN Account.Interest I ON UI.InterestId = I.Id
	Where 1=1 
	AND  (ISNULL(@Keyword, '') = '' OR I.Title Like '%'+@keyword+'%') 
	AND  (ISNULL(@Interests, '') = '' OR I.Id IN (SELECT * FROM @InterestTable) ) 
	) K
	Where 1=1 
	AND (ISNULL(@MaxDistance, '') = '' OR Distance <= @MaxDistance)
	AND (ISNULL(@MinDistance, '') = '' OR Distance >=@MinDistance)
END
