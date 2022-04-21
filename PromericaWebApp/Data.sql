CREATE TABLE [dbo].[Table]
(
	[tipo_prestamo] CHAR(1) NOT NULL PRIMARY KEY, 
    [tasa] DECIMAL(5, 2) NULL DEFAULT 0
)

go

INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'D', CAST(12.36 AS Decimal(5, 2)))
INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'E', CAST(18.95 AS Decimal(5, 2)))
INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'G', CAST(0.00 AS Decimal(5, 2)))
INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'I', CAST(8.02 AS Decimal(5, 2)))
INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'N', CAST(14.99 AS Decimal(5, 2)))
INSERT INTO [dbo].[Tipo_prestamo] ([tipo_prestamo], [tasa]) VALUES (N'R', CAST(0.00 AS Decimal(5, 2)))

go

CREATE PROCEDURE Usp_InsertUpdateDelete_Tipo_Prestamo

@TipoPrestamo char(10) = NULL

,@tasa decimal(5,2) = NULL

,@Query INT

AS

BEGIN

IF (@Query = 1)

BEGIN

INSERT INTO Tipo_prestamo(

tipo_prestamo
,tasa

)

VALUES (

@TipoPrestamo

,@tasa

)

 

IF (@@ROWCOUNT > 0)

BEGIN

SELECT 'Insert'

END

END

 

IF (@Query = 2)

BEGIN

UPDATE Tipo_prestamo

SET tipo_prestamo = @TipoPrestamo

,tasa = @tasa


WHERE Tipo_prestamo.tipo_prestamo = @TipoPrestamo

 

SELECT 'Update'

END

 

IF (@Query = 3)

BEGIN

DELETE

FROM Tipo_prestamo

WHERE Tipo_prestamo.tipo_prestamo = @TipoPrestamo

 

SELECT 'Deleted'

END

 

IF (@Query = 4)

BEGIN

SELECT *

FROM Tipo_prestamo

END

END

 

IF (@Query = 5)

BEGIN

SELECT *

FROM Tipo_prestamo

WHERE Tipo_prestamo.tipo_prestamo = @TipoPrestamo

END

go