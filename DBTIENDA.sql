CREATE DATABASE TIENDA;
Go  

USE TIENDA;
Go  

CREATE TABLE Cliente(
Id int identity primary key,
Nombre varchar(50) not null,
Apellidos varchar(75) not null,
Direccion varchar(150) not null,
pass varchar(3600) not null
);

CREATE TABLE Tienda(
Id int identity primary key,
Sucursal varchar(50) not null,
Direccion varchar(75) not null
);

CREATE TABLE Articulo(
Codigo int identity primary key,
Descripcion varchar(125) not null,
Precio decimal(9,2) not null,
Imagen varbinary(max),
ExtesionImagen varchar(20),
Stock int not null
);

CREATE TABlE ArticuloTienda(
Id int identity primary key,
Articulo int foreign key references Articulo(Codigo) NOT NULL,
Tienda int foreign key references Tienda(Id) NOT NULL,
Fecha datetime not null
);

CREATE TABLE ClienteArticulo(
Id int identity primary key,
Cliente INT FOREIGN KEY REFERENCES Cliente(Id) NOT NULL,
Articulo INT FOREIGN KEY REFERENCES Articulo(Codigo) NOT NULL,
Fecha datetime not null
);
Go

CREATE PROCEDURE CreateCliente(@Nombre varchar(50), @Apellidos varchar(75), @Direccion varchar(150),@pass varchar(3600))
AS
BEGIN
	INSERT Cliente(Nombre,Apellidos,Direccion, pass) 
	VALUES(@Nombre,@Apellidos,@Direccion,@pass);
END
Go

CREATE PROCEDURE LoginCliente(@user varchar(50), @pass varchar(3600))
AS
BEGIN
	SELECT *
	FROM Cliente
	WHERE Nombre = @user and pass = @pass
END
Go
EXEC LoginCliente 'brenda' ,'1234'
exec LoginCliente 'brenda', '1234'

CREATE PROCEDURE UpdateCliente(@Id int, @Nombre varchar(50), @Apellidos varchar(75), @Direccion varchar(150))
AS
BEGIN
	UPDATE Cliente 
	SET Nombre = @Nombre, Apellidos = @Apellidos, Direccion = @Direccion 
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE DeleteCliente(@Id int)
AS
BEGIN
	DELETE FROM Cliente 
	WHERE Id = @Id;
END
Go

CREATE PROCEDURE GetAllClientes
AS
BEGIN
	SELECT * 
	FROM Cliente (NOLOCK)
END
Go

CREATE PROCEDURE GetByID(@Id int)
AS
BEGIN
	SELECT *
	FROM Cliente (NOLOCK)
	WHERE Id = @Id
END
Go

CREATE PROCEDURE CreateTienda(@Sucursal varchar(50), @Direccion varchar(75))
AS
BEGIN
	INSERT Tienda(Sucursal,Direccion) 
	VALUES(@Sucursal,@Direccion);
END
Go 

CREATE PROCEDURE GetByIdTienda(@id int)
AS
BEGIN
	SELECT *
	FROM TIENDA
	WHERE Id = @id
END
GO

CREATE PROCEDURE UpdateTienda(@Id int, @Sucursal varchar(50), @Direccion varchar(150))
AS
BEGIN
	UPDATE Tienda 
	SET Sucursal = @Sucursal, Direccion = @Direccion 
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE DeleteTienda(@Id int)
AS
BEGIN
	DELETE FROM Tienda 
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE GetAllTiendas
AS
BEGIN
	SELECT * 
	FROM TIENDA(NOLOCK)
END
Go  

CREATE PROCEDURE CreateArticulo(@Descripcion varchar(125), @Precio decimal(9,2), @Imagen varbinary(max), @ExtesionImagen varchar(20), @Stock int)
AS
BEGIN
	INSERT Articulo(Descripcion,Precio,Imagen,ExtesionImagen,Stock) 
	VALUES(@Descripcion,@Precio,@Imagen,@ExtesionImagen,@Stock);
END
Go  

CREATE PROCEDURE UpdateArticulo(@Id int,@Descripcion varchar(125), @Precio decimal(9,2), @Imagen varbinary(max), @ExtesionImagen varchar(20), @Stock int)
AS
BEGIN
	UPDATE Articulo 
	SET Descripcion = @Descripcion, Precio = @Precio, Imagen = @Imagen, ExtesionImagen = @ExtesionImagen, Stock = @Stock
	WHERE Codigo = @Id;
END
Go  

CREATE PROCEDURE DeleteArticulo(@Id int)
AS
BEGIN
	DELETE FROM Articulo 
	WHERE Codigo = @Id;
END
Go  

CREATE PROCEDURE GetAllArticulos
AS
BEGIN
	SELECT * 
	FROM Articulo(NOLOCK)
END
Go

CREATE PROCEDURE GetByIdArticulos(@id int)
AS
BEGIN
	SELECT *
	FROM Articulo (NOLOCK)
	WHERE Codigo = @id
END
GO


CREATE PROCEDURE CreateArticuloTienda(@Articulo int, @Tienda int)
AS
BEGIN
	INSERT ArticuloTienda(Articulo,Tienda,Fecha) 
	VALUES(@Articulo,@Tienda,GETDATE());
END
Go  

CREATE PROCEDURE UpdateArticuloTienda(@Id int,@Articulo int, @Tienda int)
AS
BEGIN
	UPDATE ArticuloTienda 
	SET Articulo = @Articulo, Tienda = @Tienda, Fecha = GETDATE()
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE DeleteArticuloTienda(@Id int)
AS
BEGIN
	DELETE FROM ArticuloTienda 
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE GetAllArticuloTienda
AS
BEGIN
	SELECT * 
	FROM ArticuloTienda(NOLOCK)
END
Go  

CREATE PROCEDURE CreateClienteArticulo(@Cliente int,@Articulo int)
AS
BEGIN
	INSERT ClienteArticulo(Cliente,Articulo,Fecha) 
	VALUES(@Cliente,@Articulo,GETDATE());
END
Go  

CREATE PROCEDURE UpdateClienteArticulo(@Id int,@Cliente int,@Articulo int)
AS
BEGIN
	UPDATE ClienteArticulo 
	SET Articulo = @Articulo, Cliente = @Cliente, Fecha = GETDATE()
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE DeleteClienteArticulo(@Id int)
AS
BEGIN
	DELETE FROM ClienteArticulo 
	WHERE Id = @Id;
END
Go  

CREATE PROCEDURE GetAllClienteArticulo
AS
BEGIN
	SELECT * 
	FROM ArticuloTienda(NOLOCK)
END
Go  
