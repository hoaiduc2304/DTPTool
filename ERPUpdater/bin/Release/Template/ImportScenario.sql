

DECLARE @CompanyID INT,
@ProviderID uniqueidentifier , 
@CompanyMask varbinary(32),

@ProviderName NVARCHAR(256),
@MappingName NVARCHAR(256),
@UserID uniqueidentifier

SET @CompanyID='{#CompanyID}'

SET @ProviderName =N'{#ProviderName}' 
SET @MappingName = N'{#MappingName}'


if NOT exists (Select 1 from [SYProvider] where [Name] = @ProviderName AND CompanyID=@CompanyID ) BEGIN
SELECT top 1 @UserID = PKID, @CompanyMask = CompanyMask from users where companyid =@CompanyID
SET @ProviderID = NEWID()
-- Import [SYProvider]
{#SyProvider}
-- Import [SYProviderParameter]
{#SyProviderParam}
-- Import [SYProviderObject]
{#SyProviderObject}

 
 
-- Import [SYProviderField]
{#SYProviderField}


if NOT exists (Select 1 from [SYMapping] where [Name] = @MappingName AND CompanyID=@CompanyID ) BEGIN
-- Add to IMport Scenarios Screen 
		DECLARE @MappingID uniqueidentifier 
		SET @MappingID = NEWID()
		-- Import [SYMapping]
		{#SYMapping}

		-- Add the field into Scenarios screen 
		-- Import [SYMappingField]
		{#SYMappingField}
		
	END
END
