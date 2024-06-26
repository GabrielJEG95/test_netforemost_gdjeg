USE [test_netforemost_gdjeg]
GO

if exists (select 1 from sys.objects where object_id = OBJECT_ID(N'[dbo].[saldosGestores]'))
	drop procedure dbo.saldosGestores
/****** Object:  StoredProcedure [dbo].[saldosGestores]    Script Date: 25/06/2024 22:42:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[saldosGestores]
as
begin 

declare @cantidadGestores int,
		@CantidadCuentaSaldo int,
		@contadorGestor int;

declare @IdCuentaCliente int, 
		@IdGestor int;

select @cantidadGestores = count(*) from agente;
select @CantidadCuentaSaldo = count(*) from cuentas_cliente;
set @contadorGestor = 1;


declare cursorGestor CURSOR for 

select a.IdCuenta
from cuentas_cliente a
join clientes b 
on a.IdCliente = b.IdCliente
where b.Estado = 1
order by a.Saldo desc

OPEN cursorGestor;

FETCH NEXT FROM cursorGestor into @IdCuentaCliente

while @@FETCH_STATUS = 0
begin

	select @IdGestor = IdAgente from agente where IdAgente = @contadorGestor;
	
	if not exists(select 1 from cuentas_cobro where IdCuentaCliente = @IdCuentaCliente)
		insert into cuentas_cobro (IdAgente,IdCuentaCliente) values (@IdGestor,@IdCuentaCliente);

	if @contadorGestor = @cantidadGestores
		set @contadorGestor = 1
	else
		set @contadorGestor += 1;

	FETCH NEXT FROM cursorGestor into @IdCuentaCliente
end

close cursorGestor
deallocate cursorGestor

END;
