 IF object_id('[dbo].[{#table}_Paging]') IS NOT NULL
	DROP PROCEDURE [dbo].[{#table}_Paging]
                            
GO
CREATE PROCEDURE [dbo].[{#table}_Paging]

(
@Page int,
@RecsPerPage int,
@SearchValue nvarchar(200),
@TotalRecords int = null OUTPUT
)
As
SET NOCOUNT ON
CREATE TABLE #TempItems(
ID bigint IDENTITY,
{#Fields}
)
declare @str nvarchar(4000)
set @str = N'insert into #TempItems({#Param})
select {#Param}
 from {#table}
 where ({#PKID} IS NOT NULL) '
set @str = @str + @SearchValue
exec (@str)
DECLARE @FirstRec int, @LastRec int
SELECT @FirstRec = (@Page - 1) * @RecsPerPage
SELECT @LastRec = (@Page * @RecsPerPage + 1)
select @TotalRecords = (SELECT COUNT(*) FROM #TempItems)
SELECT *,MoreRecords = 
(SELECT COUNT(*) FROM #TempItems TI) 
FROM #TempItems
WHERE ID > @FirstRec AND ID < @LastRec
drop table #TempItems
SET NOCOUNT OFF
