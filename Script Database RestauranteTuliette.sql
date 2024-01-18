CREATE DATABASE RestauranteTuliette
GO

USE RestauranteTuliette
GO

CREATE TABLE Ingrediente(
	IdIngrediente INT IDENTITY(1,1) PRIMARY KEY,
	TipoIngrediente Varchar(20),
	NombreIngrediente VARCHAR(50),
	Unidad VARCHAR(20),
	Cantidad int,
	Descripcion VARCHAR(200)
);
CREATE TABLE Plato (
    IdPlato INT IDENTITY(1,1) PRIMARY KEY,
	TipoPlato VARCHAR(30),
	Precio DECIMAL,
	Descripcion VARCHAR(200),
	idIngrediente int,
	FOREIGN KEY (idIngrediente) REFERENCES Ingrediente(idIngrediente)
);
CREATE TABLE Bebida (
    IdBebida INT IDENTITY(1,1) PRIMARY KEY,
	TipoBebida VARCHAR(30),
	Precio DECIMAL,
	Descripcion VARCHAR(200),
	idIngrediente int,
	FOREIGN KEY (idIngrediente) REFERENCES Ingrediente(idIngrediente)
);



CREATE TABLE Ubicacion(
	IdUbicacion INT IDENTITY(1,1) PRIMARY KEY,
	Tipo VARCHAR(15),
	nroMesa VARCHAR(15),
);

CREATE TABLE Pedido(
	IdPedido INT IDENTITY(1,1) PRIMARY KEY,
	NombreCliente varchar(50),
	TipodePago varchar(20),
	PrecioTotal decimal,
	idUbicacion int,
	IdPlato int,
	IdBebida int,
	FOREIGN KEY (IdUbicacion) REFERENCES Ubicacion(IdUbicacion),
	FOREIGN KEY (IdPlato) REFERENCES Plato(IdPlato),
	FOREIGN KEY (IdBebida) REFERENCES Bebida(IdBebida)
);

CREATE TABLE Rol(
	IdRol INT IDENTITY(1,1) PRIMARY KEY,
	Nombre varchar(20),
	Estado int
);

CREATE TABLE Usuario(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(100),
	Contrasena VARCHAR(100),
	Estado int,
	IdRol int,
	FOREIGN KEY (IdRol) REFERENCES Rol(IdRol)
);