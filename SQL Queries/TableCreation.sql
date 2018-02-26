use JoshTest
CREATE TABLE Products
(
    ID INT IDENTITY NOT NULL,
    [Name] NVARCHAR(100),
    Price MONEY null,
    [Description] NVARCHAR(500),
    ImageUrl NVARCHAR(1000),
    DateCreated DATETIME NULL DEFAULT(GetDate()),
    DateLastModified DATETIME Null DEFAULT(GetDate()),

    CONSTRAINT PK_Products PRIMARY KEY (ID)
)
INSERT INTO Products VALUES
('Jazz', 39.99, 'Recreate the sharp, tangy sounds of Jazz music.', '/images/jazz.jpg', GetDate(), GetDate()),
('Rock', 29.99, 'Recreate the rugged sounds of Rock music.', '/images/rock.jpg', GetDate(), GetDate()),
('Hip Hop', 15.99, 'Oldschool boom bap and New Age 808s', '/images/hiphop.jpg', GetDate(), GetDate()),

CREATE TABLE Genres
(
    ID INT IDENTITY NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    DateCreated DATETIME NULL DEFAULT(GetDate()),
    DateLastModified DATETIME NULL DEFAULT(GetDate()),
    
    CONSTRAINT PK_Genres PRIMARY KEY (ID),
)
INSERT INTO Genres VALUES
('Jazz', GetDate(), GetDate()),
('Rock', GetDate(), GetDate()),
('Hip Hop', GetDate(), GetDate()),
('Electronic', GetDate(), GetDate())

CREATE TABLE ProductsGenres
(
    ProductID INT NOT NULL,
    GenreID INT NOT NULL,

    CONSTRAINT PK_ProductsGenres PRIMARY KEY (ProductID, GenreID),
    CONSTRAINT FK_ProductsGenres_Products FOREIGN KEY (ProductID) REFERENCES Products(ID),
	CONSTRAINT FK_ProductsGenres_Genres FOREIGN KEY (GenreID) REFERENCES Genres(ID)
)

CREATE TABLE Cart
(
    ID INT IDENTITY not null,
    DateCreated DATETIME not null DEFAULT(GetDate()),
    DateLastModified DATETIME not null DEFAULT(GetDate())

    CONSTRAINT PK_Cart Primary KEY (ID)
)

CREATE TABLE [Order]
(
    ID INT IDENTITY NOT NULL,
    Email nvarchar(100) null,
    ShippingStreet NVARCHAR(1000) not null,
    ShippingCity NVARCHAR(500) not null,
    ShippingState NvarChar(100) not null,
    ShippingZip NVARCHAR(50) not null,
    Subtotal MONEY not null,
    Shipping MONEY not null,
    Tax MONEY not null,
    DateCreated DATETIME DEFAULT GetDate(),
    DateLastModified DATETIME DEFAULT GetDate()

    CONSTRAINT PK_Order PRIMARY KEY (ID)
)

CREATE TABLE OrderProducts
(
    [OrderID] INT not null,
    [ProductsID] INT not null,
    Quantity INT not null,
    DateCreated DATETIME DEFAULT GetDate(),
    DateLastModified DATETIME DEFAULT GetDate(),

    CONSTRAINT [PK_OrderProducts] PRIMARY KEY ([ProductsID], [OrderID]), 
    CONSTRAINT [FK_OrderProducts_Order] FOREIGN KEY (OrderID) REFERENCES [Order](ID), 
    CONSTRAINT [FK_OrderProducts_Product] FOREIGN KEY (ProductsID) REFERENCES Products(ID),
)

CREATE TABLE CartProducts
(
    CartID INT not null,
    ProductsID INT not null,
    Quantity INT not null,
    DateCreated DATETIME DEFAULT GetDate(),
    DateLastModified DATETIME DEFAULT GetDate(),

    CONSTRAINT PK_CartProducts PRIMARY KEY ([CartID], [ProductsID]),
    CONSTRAINT [FK_CartProducts_Cart] FOREIGN KEY (CartID) REFERENCES Cart(ID), 
    CONSTRAINT [FK_CartProducts_Product] FOREIGN KEY (ProductsID) REFERENCES Products(ID)
)

CREATE PROCEDURE sp_GetProduct (@id int = 1)
AS
SELECT 
	[Name], 
	Price,  
	[Description], 
	ImageUrl  
FROM 
	Products 
WHERE 
	ID = @id