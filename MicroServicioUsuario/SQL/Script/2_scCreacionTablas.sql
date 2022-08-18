use Seguridad
go 


if  exists (select top 1 1 from sys.objects where name = 'PerfilPantalla')
begin 
	drop table PerfilPantalla
end 

if  exists (select top 1 1 from sys.objects where name = 'UsuarioPerfil')
begin 
	drop table UsuarioPerfil
end 

if  exists (select top 1 1 from sys.objects where name = 'Pantalla')
begin 
	drop table Pantalla
end 

if  exists (select top 1 1 from sys.objects where name = 'Perfil')
begin 
	drop table Perfil
end 

if  exists (select top 1 1 from sys.objects where name = 'Usuario')
begin 
	drop table Usuario
end 


Create table Usuario (
IdUsuario int identity(1,1),
Username varchar(200),
Contrasenia varchar(100),
FechaCreacion datetime,
Activo bit, 
FechaActualizacion datetime
Primary Key (IdUsuario)
)


Create table Perfil (
IdPerfil int identity(1,1),
Codigo varchar(100),
Nombre varchar(200),
FechaCreacion datetime,
Activo bit, 
FechaActualizacion datetime
Primary Key (IdPerfil)
)


Create table Pantalla (
IdPantalla int identity(1,1),
Codigo varchar(100),
Nombre varchar(200),
FechaCreacion datetime,
Activo bit, 
FechaActualizacion datetime
Primary Key (IdPantalla)
)

Create table UsuarioPerfil (
IdUsuarioPerfil int identity(1,1),
IdUsuario int,
IdPerfil int,
FechaCreacion datetime,
Activo bit, 
FechaActualizacion datetime
Primary Key (IdUsuarioPerfil),
FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario),
FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil),
)


Create table PerfilPantalla (
IdPerfilPantalla int identity(1,1),
IdPerfil int,
IdPantalla int,
FechaCreacion datetime,
Activo bit, 
FechaActualizacion datetime
Primary Key (IdPerfilPantalla),
FOREIGN KEY (IdPerfil) REFERENCES Perfil(IdPerfil),
FOREIGN KEY (IdPantalla) REFERENCES Pantalla(IdPantalla)
)