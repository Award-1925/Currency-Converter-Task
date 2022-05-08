CREATE TABLE [dbo].[tblCurrencies]
(
	[CurrencyID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CurrencySymbol] NVARCHAR(10) NOT NULL,
	[CurrencyCode] NVARCHAR(20) NOT NULL,
	[Currency] NVARCHAR(200) NOT NULL,
	[CreateTS] DATETIME NOT NULL,
	[LastUpdatedTS] DATETIME NULL
)
GO
CREATE TABLE [dbo].[tblExchangeRates]
(
	[ExchangeRateID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CurrencyID] INT NOT NULL,
	[DestinationCurrencyID] INT NOT NULL,
	[ExchangeRate] DECIMAL(18,2) NOT NULL,
	[CreateTS] DATETIME NOT NULL,
	[LastUpdatedTS] DATETIME NULL
)
GO
ALTER PROCEDURE [dbo].[sp_GetCurrencies] 
AS
BEGIN
	DECLARE @minLengthSymbolText INT = (SELECT MAX(LEN(C.CurrencySymbol)) FROM tblCurrencies C (NOLOCK)), 
	@minLengthCodeText INT  = (SELECT MAX(LEN(C.CurrencycODE)) FROM tblCurrencies C (NOLOCK))
	 
	SELECT C.CurrencyID, 
	(C.CurrencySymbol + SPACE(@minLengthSymbolText - LEN(C.CurrencySymbol))) AS [CurrencySymbol], 
	(C.CurrencyCode + SPACE(@minLengthCodeText - LEN(C.CurrencyCode))) AS [CurrencyCode],
	C.[Currency],
	C.CreateTS, 
	C.LastUpdatedTS 
	FROM tblCurrencies C (NOLOCK)

END

GO
CREATE PROCEDURE [dbo].[sp_ConvertCurrency] 
@CurrencyID INT,
@Amount DECIMAL(18,2),
@DestinationCurrencyID INT

AS
BEGIN 
	SELECT CAST(@amount * rand() AS DECIMAL(18,2)) AS [ConvertedAmount] 
END