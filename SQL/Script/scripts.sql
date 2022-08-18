use cliente 
go 
select * from cliente 
insert into cliente (nombre, Apellido, EstadoCivil)
values ('Sonia', 'Choez', 'Soltero')

create procedure pConsultaCliente
as

select IdCliente, nombre, Apellido, EstadoCivil from cliente


exec cliente.dbo.pConsultaCliente

select IdConexion,Modulo,Fuente,Proveedor,Autenticacion,Usuario,Clave,NombreBaseDeDatos,Modelo from Conexion
Data Source=DESKTOP-JIJ5VUP\SQLEXPRESS;Initial Catalog=LogPlataforma;Persist Security Info=True; User Id=UserDesa;Password=userdesa01;MultipleActiveResultSets=True;TrustServerCertificate=True


use Infraestructura
go 

insert into conexion (Modulo,Fuente,Proveedor,Autenticacion,Usuario,Clave,NombreBaseDeDatos,Modelo)
values ('CRE', 'DESKTOP-JIJ5VUP\SQLEXPRESS', 'System.Data.SqlClient', 'SQL','cZFltg88taTUVPLDAKBR7w==', 'HPcydMQNrvh1JGCUSIjoHQ==', 'Credito', '')


use credito
go 

create table credito(
IdCredito int identity(1,1),
NumeroCredito varchar(200),
Monto decimal(19,2),
IdCliente int,
Primary Key (IdCredito)
)

insert into credito(NumeroCredito,Monto,IdCliente)
values ('59102036', 9000,3)

create procedure pConsultarCredito
as 
select IdCredito,NumeroCredito,Monto,IdCliente from credito






use Log
go 
select * from Infraestructura.dbo.log
select * from Credito.dbo.log

select * from Log.dbo.LogPlataforma
--truncate table  Log.dbo.LogPlataforma
--drop table Log
--drop table LogPlataforma
CREATE TABLE [dbo].[LogPlataforma](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](128) NULL,
	[TimeStamp] [datetimeoffset](7) NOT NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [xml] NULL,
	[LogEvent] [nvarchar](max) NULL,
	[Aplicacion] [nvarchar](max) NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO