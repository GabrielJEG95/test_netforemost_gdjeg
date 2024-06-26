create database test_netforemost_gdjeg;

use test_netforemost_gdjeg;

create table agente
(
	IdAgente int primary key identity(1,1) not null,
	NombreAgente varchar(50) not null,
	Estado bit default 1 not null,
	FechaCreacion datetime default getdate() not null,
	FechaAnulacion datetime null
);

create table clientes
(
	IdCliente int primary key identity(1,1) not null,
	NombreCliente varchar(50) not null,
	Estado bit default 1 not null,
	FechaCreacion datetime default getdate() not null,
	FechaAnulacion datetime null
);

create table cuentas_cliente
(
	IdCuenta int primary key identity(1,1) not null,
	IdCliente int not null,
	Saldo int not null,
	FechaCreacion datetime default getdate() not null,
	foreign key(IdCliente) references agente (IdAgente)
);


create table cuentas_cobro
(
	IdCuentaCobro int primary key identity(1,1) not null,
	IdAgente int not null,
	IdCuentaCliente int not null,
	FechaCreacion datetime default getdate() not null,
	foreign key(IdAgente) references agente(IdAgente),
	foreign key(IdCuentaCliente) references cuentas_cliente(IdCuenta)
);


insert into agente(NombreAgente) values ('Gabriel Espinoza'),('Carlos M'),('José G'),('Manuel R'),('Josue N'),('Alejandro V'),('David U');
insert into agente(NombreAgente) values ('Agente 8'),('Agente 9'),('Agente 10')

select * from agente;

insert into clientes (NombreCliente) values('Cliente 1'),('Cliente 2'),('Cliente 3'),('Cliente 4'),('Cliente 5'),('Cliente 6'),('Cliente 7'),('Cliente 8');
insert into clientes (NombreCliente) values('Cliente 9'),('Cliente 10'),('Cliente 11'),('Cliente 12'),('Cliente 13'),('Cliente 14'),('Cliente 15'),('Cliente 16');
insert into clientes (NombreCliente) values('Cliente 17'),('Cliente 18'),('Cliente 19'),('Cliente 20'),('Cliente 21'),('Cliente 22'),('Cliente 23'),('Cliente 24');
insert into clientes (NombreCliente) values('Cliente 25'),('Cliente 26'),('Cliente 27'),('Cliente 28'),('Cliente 29'),('Cliente 30'),('Cliente 31'),('Cliente 32');
select * from clientes;


insert into cuentas_cliente (IdCliente, Saldo) values (1,2227),(2,3953),(3,4726),(4,1414),(5,627),(6,1784),(7,1634),(8,3958);
insert into cuentas_cliente (IdCliente, Saldo) values (9,2156),(10,1347),(11,2166),(12,820),(13,2325),(14,3613),(15,2389),(16,4130);
insert into cuentas_cliente (IdCliente, Saldo) values (1,2007),(2,3027),(3,2591),(4,3940),(5,3888),(6,2975),(7,4470),(8,2291);
insert into cuentas_cliente (IdCliente, Saldo) values (9,3393),(10,3588),(11,3286),(12,2293),(13,4353),(14,3315),(15,4900),(16,794);
insert into cuentas_cliente (IdCliente, Saldo) values (17,4424),(18,4505),(19,2643),(20,2217),(21,4193),(22,2893),(23,4120),(24,3352);
insert into cuentas_cliente (IdCliente, Saldo) values (25,2355),(26,3219),(27,3064),(28,4893),(29,272),(30,1299),(31,4725),(32,1900);
insert into cuentas_cliente (IdCliente, Saldo) values (17,4927),(18,4011);

select * 
from cuentas_cliente 
order by Saldo desc;
