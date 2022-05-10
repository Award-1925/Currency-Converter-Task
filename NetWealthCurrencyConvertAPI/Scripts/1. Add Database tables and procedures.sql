CREATE TABLE [dbo].[tblCurrencies]
( 
	[CurrencyCode] NVARCHAR(20) NOT NULL PRIMARY KEY,
	[Currency] NVARCHAR(200) NOT NULL,
	[CreateTS] DATETIME NOT NULL,
	[LastUpdatedTS] DATETIME NULL
)
GO
CREATE TABLE [dbo].[tblExchangeRates]
(
	[ExchangeRateID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CurrencyCode] NVARCHAR(20) NOT NULL,
	[DestinationCurrencyCode] NVARCHAR(20) NOT NULL,
	[ExchangeRate] DECIMAL(18,6) NOT NULL,
	[CreateTS] DATETIME NOT NULL,
	[LastUpdatedTS] DATETIME NULL
)
GO
CREATE PROCEDURE [dbo].[sp_GetCurrencies] 
AS
BEGIN  
	SELECT CurrencyCode,
	[Currency],
	CreateTS, 
	LastUpdatedTS 
	FROM tblCurrencies (NOLOCK) 
END 
GO
CREATE PROCEDURE [dbo].[sp_ConvertCurrency] 
@CurrencyCode NVARCHAR(20),
@Amount DECIMAL(18,2),
@DestinationCurrencyCode NVARCHAR(20)

AS
BEGIN 
	SELECT 
	@CurrencyCode AS [CurrencyCode],
	@Amount AS [Amount],
	@DestinationCurrencyCode AS [DestinationCurrencyCode],
	@Amount * ExchangeRate AS [ConvertedAmount],
	LastUpdatedTS
	FROM tblExchangeRates (NOLOCK) WHERE CurrencyCode = @CurrencyCode AND DestinationCurrencyCode = @DestinationCurrencyCode
END
GO 
CREATE PROCEDURE [dbo].[sp_UpdateCurrencyExchangeRate] 
@CurrencyCode NVARCHAR(20),
@ExchangeRate DECIMAL(18,6),
@DestinationCurrencyCode NVARCHAR(20) 
AS
BEGIN  
	IF(EXISTS(SELECT 0 FROM tblExchangeRates (NOLOCK) WHERE CurrencyCode = @CurrencyCode AND DestinationCurrencyCode = @DestinationCurrencyCode))
	BEGIN
		UPDATE tblExchangeRates SET 
		ExchangeRate = @ExchangeRate,
		LastUpdatedTS = GETDATE()
		WHERE CurrencyCode = @CurrencyCode AND DestinationCurrencyCode = @DestinationCurrencyCode
	END
	ELSE
	BEGIN 
		INSERT INTO tblExchangeRates (CurrencyCode, ExchangeRate, DestinationCurrencyCode, CreateTS, LastUpdatedTS)
		SELECT @CurrencyCode, @ExchangeRate, @DestinationCurrencyCode, GETDATE(), GETDATE()
	END
END
GO  