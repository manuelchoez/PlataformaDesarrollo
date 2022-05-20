use Infraestructura
go 

if exists(select * from sys.tables where name = 'Conexion')
begin 
	drop table Conexion
end 

create table Conexion (
IdConexion int identity(1,1),
Modulo varchar(4),
Fuente varchar(64),
Proveedor varchar(64),
Autenticacion varchar(4),
Usuario varchar(64),
Clave varchar(64),
NombreBaseDeDatos varchar(64),
Modelo varchar(128),
Primary key (IdConexion)
)