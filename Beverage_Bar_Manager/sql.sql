
USE [PRN211_GroupProject_CoffeeManagementSystem]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](1000) NOT NULL,
	[Role] [nvarchar](50) NOT NULL,
	[idEmployee] [int] NOT NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attendance](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NULL,
	[Attendance1ST] [bit] NULL,
	[Attendance2ND] [bit] NULL,
	[AttendanceDate] [date] NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdEmployee] [int] NULL,
	[DateCheckIn] [datetime] NULL,
	[DateCheckOut] [datetime] NULL,
	[IdTable] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillDetail]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillDetail](
	[IdBill] [int] NOT NULL,
	[IdFood] [int] NOT NULL,
	[Quality] [int] NULL,
 CONSTRAINT [PK_BillDetail] PRIMARY KEY CLUSTERED 
(
	[IdBill] ASC,
	[IdFood] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Address] [nvarchar](max) NULL,
	[DOB] [date] NULL,
	[Photo] [varchar](max) NULL,
	[Phone] [varchar](50) NULL,
	[Salary] [money] NULL,
	[DateJoin] [date] NULL,
	[Gender] [nvarchar](50) NULL,
	[CMT] [varchar](50) NULL,
	[IdShift] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Food]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[IdCatagory] [int] NULL,
	[Price] [money] NULL,
	[Size] [varchar](5) NULL,
	[Description] [nvarchar](500) NULL,
	[Picture] [nvarchar](1000) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_FoodCatagory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shift]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shift](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Time] [int] NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
 CONSTRAINT [PK_Shift] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TableOr]    Script Date: 25/10/2021 10:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableOr](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NULL,
	[Status] [nvarchar](50) NULL,
 CONSTRAINT [PK_TableOr] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'demo', N'12345678', N'employee', 1004, 1)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'ducle', N'12345678', N'employee', 5, 1)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'nhungbae', N'12345678', N'employee', 4, 1)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'phanhai', N'12345678', N'employee', 3, 0)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'superman', N'12345678', N'employee', 7, 1)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'tiendung', N'1', N'manager', 1, 1)
INSERT [dbo].[Account] ([Username], [Password], [Role], [idEmployee], [Status]) VALUES (N'vankhanh', N'12345678', N'employee', 6, 1)
GO
SET IDENTITY_INSERT [dbo].[Attendance] ON 

INSERT [dbo].[Attendance] ([ID], [IdEmployee], [Attendance1ST], [Attendance2ND], [AttendanceDate]) VALUES (2, 1, 1, 1, CAST(N'2021-10-22' AS Date))
INSERT [dbo].[Attendance] ([ID], [IdEmployee], [Attendance1ST], [Attendance2ND], [AttendanceDate]) VALUES (3, 1, 1, 1, CAST(N'2021-10-22' AS Date))
INSERT [dbo].[Attendance] ([ID], [IdEmployee], [Attendance1ST], [Attendance2ND], [AttendanceDate]) VALUES (6, 1, 1, 1, CAST(N'2021-10-23' AS Date))
SET IDENTITY_INSERT [dbo].[Attendance] OFF
GO
SET IDENTITY_INSERT [dbo].[Bill] ON 

INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (22, 1, CAST(N'2021-10-21T00:00:00.000' AS DateTime), CAST(N'2021-10-21T00:00:00.000' AS DateTime), 1, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (24, 1, CAST(N'2021-10-21T00:00:00.000' AS DateTime), CAST(N'2021-10-21T22:58:40.277' AS DateTime), 7, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (25, 1, CAST(N'2021-10-21T23:00:27.483' AS DateTime), CAST(N'2021-10-21T23:00:27.483' AS DateTime), 5, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (26, 1, CAST(N'2021-10-22T11:05:29.190' AS DateTime), CAST(N'2021-10-22T11:05:59.700' AS DateTime), 1, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (27, 1, CAST(N'2021-10-24T01:35:40.377' AS DateTime), CAST(N'2021-10-24T01:35:40.377' AS DateTime), 1, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (28, 1, CAST(N'2021-10-24T22:00:43.743' AS DateTime), CAST(N'2021-10-24T22:45:26.563' AS DateTime), 10, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (1028, 1, CAST(N'2021-10-25T21:17:39.803' AS DateTime), CAST(N'2021-10-25T21:17:56.163' AS DateTime), 1, 1)
INSERT [dbo].[Bill] ([ID], [IdEmployee], [DateCheckIn], [DateCheckOut], [IdTable], [Status]) VALUES (1029, 1, CAST(N'2021-10-25T21:20:49.327' AS DateTime), CAST(N'2021-10-25T21:20:49.327' AS DateTime), 2, 1)
SET IDENTITY_INSERT [dbo].[Bill] OFF
GO
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (22, 6, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (22, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (22, 10, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (24, 6, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (24, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (25, 6, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (25, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (26, 4, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (26, 5, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (26, 6, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (26, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (26, 10, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 1, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 3, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 4, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 5, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 6, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 7, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 9, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 10, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 11, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 19, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 21, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 22, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 23, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (27, 24, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (28, 8, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (28, 10, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (28, 11, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (28, 13, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1028, 1, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1028, 6, 6)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1028, 7, 2)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1028, 9, 2)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 4, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 5, 3)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 7, 3)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 9, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 11, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 12, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 14, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 15, 1)
INSERT [dbo].[BillDetail] ([IdBill], [IdFood], [Quality]) VALUES (1029, 16, 1)
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (1, N'Hoàng Tiến Dũng', N'Hiệp Hòa - Bắc Giang', CAST(N'1999-12-06' AS Date), N'Image\download.jfif', N'097-2655-368', 30000.0000, CAST(N'2021-10-24' AS Date), N'Female', N'122274439', 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (3, N'Phan Triệu Hải', N'Nghệ An', CAST(N'1998-08-06' AS Date), N'Image\hai.jpg', N'111-1111-111', 100000.0000, CAST(N'2021-10-24' AS Date), N'Male', N'11111111111', 2)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (4, N'Nguyễn Thị Nhung', N'Hà Nội', CAST(N'1999-01-01' AS Date), N'Image\avtnhung.jpg', N'098-7654-321', 30000.0000, CAST(N'2021-10-24' AS Date), N'Female', N'123456789', 2)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (5, N'Đức Lê', N'Hà Nội', CAST(N'1998-01-01' AS Date), N'Image\duc.jpg', N'098-7778-787', 40000.0000, CAST(N'2021-10-24' AS Date), N'Male', N'123456678', 3)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (6, N'Phạm Văn Khánh', N'Hà Nội', CAST(N'1999-01-01' AS Date), N'Image\khanh.jpg', N'123-5674-567', 20000.0000, CAST(N'2021-10-24' AS Date), N'Male', N'123456678', 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (7, N'Superman', N'Mỹ', CAST(N'1999-01-01' AS Date), N'Image\download.jfif', N'132-3123-131', 20000.0000, CAST(N'2021-10-24' AS Date), N'Male', N'12334557', 1)
INSERT [dbo].[Employee] ([ID], [Name], [Address], [DOB], [Photo], [Phone], [Salary], [DateJoin], [Gender], [CMT], [IdShift]) VALUES (1004, N'demo', N'ok', CAST(N'2021-10-25' AS Date), N'E:\PRN211\PRN211_GroupProject_Group1\Coffee_Management_Software\bin\Debug\net5.0-windows\Food_Picture\AMERICANO.png', N'123-1212-312', 12210.0000, CAST(N'2021-10-25' AS Date), N'Male', N'2312312', 1)
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Food] ON 

INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (1, N'PHIN SUA DA', 1, 29000.0000, N'S', N'Vietnamese Iced Milk Coffee! The authentic taste of Vietnam! A bold blend of the finest Vietnamese Robusta and Arabica coffee beans, hand roasted and flavored to perfection, then slow drip brewed through a traditional Vietnamese ‘Phin’ filter. Sweet condensed milk and ice are added to create this deliciously indulgent pick me up!', N'Food_Picture/PHIN-SUA-DA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (2, N'PHIN SUA DA', 1, 39000.0000, N'L    ', N'Vietnamese Iced Milk Coffee! The authentic taste of Vietnam! A bold blend of the finest Vietnamese Robusta and Arabica coffee beans, hand roasted and flavored to perfection, then slow drip brewed through a traditional Vietnamese ‘Phin’ filter. Sweet condensed milk and ice are added to create this deliciously indulgent pick me up!', N'Food_Picture/PHIN-SUA-DA.png', 0)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (3, N'PHIN DA DEN', 1, 29000.0000, N'S    ', N'Vietnamese Iced Black Coffee! For committed caffeine lovers! Made from our signature Highlands Traditional Blend. Rich, slow brewed coffee mixed with a teaspoon of sugar and poured over ice to bring you the bold taste of Vietnam!', N'Food_Picture/PHIN-DEN-DA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (4, N'PHIN DA DEN', 1, 39000.0000, N'L    ', N'Vietnamese Iced Black Coffee! For committed caffeine lovers! Made from our signature Highlands Traditional Blend. Rich, slow brewed coffee mixed with a teaspoon of sugar and poured over ice to bring you the bold taste of Vietnam!', N'Food_Picture/PHIN-DEN-DA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (5, N'PHIN SUA NONG', 1, 29000.0000, N'S    ', N'Vietnamese Hot Milk Coffee! A bold blend of the finest Vietnamese Robusta and Arabica coffee beans, hand roasted and flavored to perfection, then slow drip brewed through a traditional Vietnamese ‘Phin’ filter. Served hot with sweet condensed milk, to create a deliciously indulgent pick me up!', N'Food_Picture/PHIN-SUA-NONG.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (6, N'PHIN DEN NONG', 1, 29000.0000, N'S    ', N'Vietnamese Hot Black Coffee! For committed caffeine lovers! Made from our signature Highlands Traditional Blend. Rich, slow brewed coffee mixed with a teaspoon of sugar to bring you the bold taste of Vietnam!', N'Food_Picture/PHIN DEN NONG.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (7, N'CAPPUCCINO', 1, 54000.0000, N'M    ', N'Bold Milk Coffee! Bolder tasting than a Latte, our Cappuccino starts with an espresso shot then we add equal amounts fresh steamed milk and hot milk foam. Also available as Iced Cappuccino.', N'Food_Picture/CAPPUCINO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (8, N'CAPPUCCINO', 1, 64000.0000, N'L    ', N'Bold Milk Coffee! Bolder tasting than a Latte, our Cappuccino starts with an espresso shot then we add equal amounts fresh steamed milk and hot milk foam. Also available as Iced Cappuccino.', N'Food_Picture/CAPPUCINO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (9, N'AMERICANO', 1, 44000.0000, N'M    ', N'A shot of espresso topped with hot water. Also available was an Iced Americano.', N'Food_Picture/AMERICANO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (10, N'AMERICANO', 1, 54000.0000, N'L    ', N'A shot of espresso topped with hot water. Also available was an Iced Americano.', N'Food_Picture/AMERICANO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (11, N'ESPRESSO', 1, 44000.0000, N'M    ', N'Intense! An expertly crafted shot of espresso made from our Highlands Coffee Full City Roast Blend – a blend of premium Vietnamese Arabica and Robusta coffee beans.', N'Food_Picture/ESPRESSO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (12, N'ESPRESSO', 1, 54000.0000, N'L    ', N'Intense! An expertly crafted shot of espresso made from our Highlands Coffee Full City Roast Blend – a blend of premium Vietnamese Arabica and Robusta coffee beans.', N'Food_Picture/ESPRESSO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (13, N'CARAMEL MACCHIATO', 1, 59000.0000, N'M    ', N'Sweet satisfaction! Our multi-layered Macchiato begins with fresh steamed milk and a layer of creamy milk foam. Then rich espresso is poured through the foam where it mixes with the milk. Finally, the barista signs their work of art with a swirl of sweet caramel sauce. Also available as Iced Mocha.', N'Food_Picture/CARAMEL-MACCHIATO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (14, N'CARAMEL MACCHIATO', 1, 69000.0000, N'L    ', N'Sweet satisfaction! Our multi-layered Macchiato begins with fresh steamed milk and a layer of creamy milk foam. Then rich espresso is poured through the foam where it mixes with the milk. Finally, the barista signs their work of art with a swirl of sweet caramel sauce. Also available as Iced Mocha.', N'Food_Picture/CARAMEL-MACCHIATO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (15, N'MOCHA', 1, 59000.0000, N'M    ', N'A flawless mixture of Espresso, chocolate syrup and steamed milk, expertly topped with hot milk foam and more chocolate syrup. Also available as Iced Mocha.', N'Food_Picture/MOCHA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (16, N'MOCHA', 1, 69000.0000, N'L    ', N'A flawless mixture of Espresso, chocolate syrup and steamed milk, expertly topped with hot milk foam and more chocolate syrup. Also available as Iced Mocha.', N'Food_Picture/MOCHA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (17, N'LATTE', 1, 54000.0000, N'M    ', N'Silky Smooth Milk Coffee! Lighter tasting than Cappuccino, our Latte starts with a shot of espresso, then we add a generous portion of fresh steamed milk and top it with a touch of hot milk foam. Also available as Iced Latte.', N'Food_Picture/LATTE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (18, N'LATTE', 1, 64000.0000, N'L    ', N'Silky Smooth Milk Coffee! Lighter tasting than Cappuccino, our Latte starts with a shot of espresso, then we add a generous portion of fresh steamed milk and top it with a touch of hot milk foam. Also available as Iced Latte.', N'Food_Picture/LATTE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (19, N'GREEN TEA FREEZE', 2, 49000.0000, N'S    ', N'A fan favorite! Premium Vietnamese green tea and ice are blended into fine flavor granules with added chewy green tea jelly and a topping of rich cream. Indulgently delicious and refreshing!', N'Food_Picture/GTF.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (20, N'GREEN TEA FREEZE', 2, 65000.0000, N'L    ', N'A fan favorite! Premium Vietnamese green tea and ice are blended into fine flavor granules with added chewy green tea jelly and a topping of rich cream. Indulgently delicious and refreshing!', N'Food_Picture/GTF.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (21, N'COOKIES & CREAM', 2, 49000.0000, N'S    ', N'Crunchy Cookie Delight! A perfect combination of crunchy chocolate cookies, condensed milk and fresh milk, blended with ice then topped with rich whipped cream and crushed chocolate cookies!', N'Food_Picture/COOKIES-CREAM.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (22, N'COOKIES & CREAM', 2, 65000.0000, N'L    ', N'Crunchy Cookie Delight! A perfect combination of crunchy chocolate cookies, condensed milk and fresh milk, blended with ice then topped with rich whipped cream and crushed chocolate cookies!', N'Food_Picture/COOKIES-CREAM.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (23, N'CHOCOLATE FREEZE', 2, 49000.0000, N'S    ', N'Iced Chocolate Heaven! Premium Vietnamese chocolate is ice blended into fine flavor granules then we add chewy chocolate jelly and a topping of rich whipped cream and chocolate sauce.', N'Food_Picture/CHOCOLATE-FREEZE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (24, N'CHOCOLATE FREEZE', 2, 65000.0000, N'L    ', N'Iced Chocolate Heaven! Premium Vietnamese chocolate is ice blended into fine flavor granules then we add chewy chocolate jelly and a topping of rich whipped cream and chocolate sauce.', N'Food_Picture/CHOCOLATE-FREEZE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (25, N'CARAMEL COFFEE FREEZE', 2, 49000.0000, N'S    ', N'Deliciously indulgent! Our unique Highlands Traditional Blend of slow-dripped Vietnamese coffee, luscious caramel, coffee jelly, blended with ice and topped with whipped cream and a rich caramel sauce. A perfect way to catch-up with friends!', N'Food_Picture/CARAMEL-MACCHIATO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (26, N'CARAMEL COFFEE FREEZE', 2, 65000.0000, N'L    ', N'Deliciously indulgent! Our unique Highlands Traditional Blend of slow-dripped Vietnamese coffee, luscious caramel, coffee jelly, blended with ice and topped with whipped cream and a rich caramel sauce. A perfect way to catch-up with friends!', N'Food_Picture/CARAMEL-MACCHIATO.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (27, N'CLASSIC PHIN FREEZE', 2, 49000.0000, N'S    ', N'Boldly indulgent! Our unique Highlands Traditional Blend of slow-dripped Vietnamese coffee, coffee jelly, blended with ice and topped with whipped cream and bold cocoa powder.', N'Food_Picture/CLASSIC-FREEZE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (28, N'CLASSIC PHIN FREEZE', 2, 65000.0000, N'L    ', N'Boldly indulgent! Our unique Highlands Traditional Blend of slow-dripped Vietnamese coffee, coffee jelly, blended with ice and topped with whipped cream and bold cocoa powder.', N'Food_Picture/CLASSIC-FREEZE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (29, N'LYCHEE TEA', 3, 39000.0000, N'S    ', N'A refreshing blend of black tea, whole lychee fruits and chewy golden jelly.', N'Food_Picture/LYCHEE TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (30, N'LYCHEE TEA', 3, 55000.0000, N'L    ', N'A refreshing blend of black tea, whole lychee fruits and chewy golden jelly.', N'Food_Picture/LYCHEE TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (31, N'PEACH JELLY TEA', 3, 39000.0000, N'S    ', N'A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!', N'Food_Picture/PEACH JELLY TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (32, N'PEACH JELLY TEA', 3, 55000.0000, N'L    ', N'A bold tea base with juicy peaches and chewy peach jelly. Top it with milk if you prefer!', N'Food_Picture/PEACH JELLY TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (33, N'PEACH LEMONGRASS TEA', 3, 39000.0000, N'S    ', N'Delightfully refreshing! The perfect balance of premium tea, subtle lemongrass and sweet juicy peaches.', N'Food_Picture/PEACH LEMONGRASS TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (34, N'PEACH LEMONGRASS TEA', 3, 55000.0000, N'L    ', N'Delightfully refreshing! The perfect balance of premium tea, subtle lemongrass and sweet juicy peaches.', N'Food_Picture/PEACH LEMONGRASS TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (35, N'GOLDEN LOTUS TEA', 3, 39000.0000, N'S    ', N'Another fan favorite! A refreshing blend of cooling oolong tea, luscious lotus seeds and water chestnuts. Your choice whether to add milk or not!', N'Food_Picture/GOLDEN LOTUS TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (36, N'GOLDEN LOTUS TEA', 3, 55000.0000, N'L    ', N'Another fan favorite! A refreshing blend of cooling oolong tea, luscious lotus seeds and water chestnuts. Your choice whether to add milk or not!', N'Food_Picture/GOLDEN LOTUS TEA.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (37, N'GRILLED PORK
', 4, 19000.0000, N'N    ', N'A Vietnamese icon! Crispy crusty baguette filled with deliciously grilled pork, vegetables and herbs and our special sauce.', N'Food_Picture/GRILLED PORK.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (38, N'PORK MEATBALL', 4, 19000.0000, N'N    ', N'Crispy Vietnamese baguette filled with juicy pork meatballs, smothered in a rich tomato sauce and balanced with fresh vegetables and herbs.', N'Food_Picture/PORK MEATBALL.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (39, N'ROAST PORK & PORK SAUSAGE', 4, 19000.0000, N'N    ', N'Crispy Vietnamese baguette filled with delicious pork sausage & char siu pork, vegetables and herbs and our special sauce.', N'Food_Picture/ROAST PORK & PORK SAUSAGE.png', 1)
INSERT [dbo].[Food] ([ID], [Name], [IdCatagory], [Price], [Size], [Description], [Picture], [Status]) VALUES (40, N'ROAST CHICKEN', 4, 19000.0000, N'N    ', N'Crispy Vietnamese baguette stuffed with shredded roasted chicken, vegetables and herbs and our special sauce!', N'Food_Picture/ROAST CHICKEN.png', 1)
SET IDENTITY_INSERT [dbo].[Food] OFF
GO
SET IDENTITY_INSERT [dbo].[FoodCategory] ON 

INSERT [dbo].[FoodCategory] ([ID], [Name], [Description], [Status]) VALUES (1, N'COFFEE', N'Vietnam is the world’s second largest producer of coffee. As a Vietnamese brand, Highlands Coffee hand selects and roasts only the finest aromatic Arabica and bold Robusta beans for our signature blends.', 1)
INSERT [dbo].[FoodCategory] ([ID], [Name], [Description], [Status]) VALUES (2, N'FREEZE', N'Our delicious ice-blended beverages are made from premium Vietnamese ingredients and have a range of options with coffee and also without coffee.', 1)
INSERT [dbo].[FoodCategory] ([ID], [Name], [Description], [Status]) VALUES (3, N'TEA', N'Building on Vietnam’s rich tea heritage, we select only the finest teas grown in the highlands regions of Vietnam to create delicious, modern tea beverages that include natural fruits and toppings. Served with or without milk.', 1)
INSERT [dbo].[FoodCategory] ([ID], [Name], [Description], [Status]) VALUES (4, N'BANH MI', N'You’ve heard enough about the legendary Vietnamese Banh Mi. Now take a bite of the freshly made, crispy baguette at Highlands Coffee. Let that distinctive balance of flavors and textures fill your mouth with layers of tastes from salty to sweet and sour, finished with a hint of spiciness. It’s love at first bite.', 1)
INSERT [dbo].[FoodCategory] ([ID], [Name], [Description], [Status]) VALUES (6, N'Trà tắc', N'okokok', 0)
SET IDENTITY_INSERT [dbo].[FoodCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Shift] ON 

INSERT [dbo].[Shift] ([ID], [Title], [Time], [StartTime], [EndTime]) VALUES (1, N'Ca A', 8, CAST(N'06:30:00' AS Time), CAST(N'14:30:00' AS Time))
INSERT [dbo].[Shift] ([ID], [Title], [Time], [StartTime], [EndTime]) VALUES (2, N'Ca B', 8, CAST(N'14:30:00' AS Time), CAST(N'22:30:00' AS Time))
INSERT [dbo].[Shift] ([ID], [Title], [Time], [StartTime], [EndTime]) VALUES (3, N'Ca C', 8, CAST(N'08:00:00' AS Time), CAST(N'17:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[Shift] OFF
GO
SET IDENTITY_INSERT [dbo].[TableOr] ON 

INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (1, N'Bàn 0', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (2, N'Bàn1', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (3, N'Bàn2', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (4, N'Bàn3', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (5, N'Bàn4', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (6, N'Bàn5', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (7, N'Bàn6', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (8, N'Bàn7', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (9, N'Bàn8', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (10, N'Bàn9', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (11, N'Bàn10', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (12, N'Bàn11', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (13, N'Bàn12', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (14, N'Bàn13', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (15, N'Bàn14', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (16, N'Bàn15', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (17, N'Bàn16', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (18, N'Bàn17', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (19, N'Bàn18', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (20, N'Bàn19', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (21, N'Bàn20', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (22, N'Bàn21', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (23, N'Bàn22', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (24, N'Bàn23', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (25, N'Bàn24', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (26, N'Bàn25', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (27, N'Bàn26', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (28, N'Bàn27', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (29, N'Bàn28', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (30, N'Bàn29', N'Trống')
INSERT [dbo].[TableOr] ([ID], [Name], [Status]) VALUES (31, N'Bàn30', N'Trống')
SET IDENTITY_INSERT [dbo].[TableOr] OFF
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_Attendance1ST]  DEFAULT ((0)) FOR [Attendance1ST]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_Attendance2ND]  DEFAULT ((0)) FOR [Attendance2ND]
GO
ALTER TABLE [dbo].[Attendance] ADD  CONSTRAINT [DF_Attendance_AttendanceDate]  DEFAULT (getdate()) FOR [AttendanceDate]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF_Bill_DateCheckIn]  DEFAULT (getdate()) FOR [DateCheckIn]
GO
ALTER TABLE [dbo].[Bill] ADD  CONSTRAINT [DF_Bill_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[BillDetail] ADD  CONSTRAINT [DF_BillDetail_Quality]  DEFAULT ((0)) FOR [Quality]
GO
ALTER TABLE [dbo].[Food] ADD  CONSTRAINT [DF_Food_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[TableOr] ADD  CONSTRAINT [DF_TableOr_Status]  DEFAULT (N'Trống') FOR [Status]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Employee] FOREIGN KEY([idEmployee])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Employee]
GO
ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employee]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_TableOr] FOREIGN KEY([IdTable])
REFERENCES [dbo].[TableOr] ([ID])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_TableOr]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Bill] FOREIGN KEY([IdBill])
REFERENCES [dbo].[Bill] ([ID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Bill]
GO
ALTER TABLE [dbo].[BillDetail]  WITH CHECK ADD  CONSTRAINT [FK_BillDetail_Food] FOREIGN KEY([IdFood])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[BillDetail] CHECK CONSTRAINT [FK_BillDetail_Food]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Shift] FOREIGN KEY([IdShift])
REFERENCES [dbo].[Shift] ([ID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Shift]
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_FoodCatagory] FOREIGN KEY([IdCatagory])
REFERENCES [dbo].[FoodCategory] ([ID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_FoodCatagory]
GO
