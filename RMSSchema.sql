CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1, 1),
    Username VARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARBINARY(256) NOT NULL, -- Storing hashed passwords
    Phone VARCHAR(20),
    Email VARCHAR(255) UNIQUE,
    Role VARCHAR(50) NOT NULL, -- e.g., 'Customer', 'Rider', 'Admin'
    Since DATE,
    Picture VARBINARY(MAX), -- Assuming you are storing the image as a blob
    Salary DECIMAL(10, 2),
    TipEarned DECIMAL(10, 2) DEFAULT 0 -- Tips earned by the rider
);
CREATE TABLE Items (
    ItemID INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CostOfPurchase DECIMAL(10, 2),
    Picture VARBINARY(MAX) -- Assuming you are storing the image as a blob
);
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1, 1),
    CustomerID INT NOT NULL,
    Date_Time DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    OrderType VARCHAR(50) CHECK (OrderType IN ('online', 'offline')), -- 'online' or 'offline'
    Address VARCHAR(255), -- Only for online orders
    PaymentMethod VARCHAR(50) NOT NULL, -- 'cash', 'card', etc.
    Tip DECIMAL(10, 2), -- Tip given by the customer at the time of order
    DeliveryCharges DECIMAL(10, 2), -- Applicable for online orders
    Status VARCHAR(50),
    RiderID INT, -- Nullable for in-house (offline) orders
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID),
    FOREIGN KEY (RiderID) REFERENCES Users(UserID)
);
CREATE TABLE OrderDetails (
    OrderID INT,
    ItemID INT,
    Quantity INT NOT NULL,
    PRIMARY KEY (OrderID, ItemID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);
CREATE TABLE Carts (
    CartID INT PRIMARY KEY IDENTITY(1, 1),
    UserID INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE CartItems (
    CartItemID INT PRIMARY KEY IDENTITY(1, 1),
    CartID INT NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CartID) REFERENCES Carts(CartID),
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID)
);
CREATE TABLE Inbox (
    MessageID INT PRIMARY KEY IDENTITY(1, 1),
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    MessageText TEXT NOT NULL,
    SentDateTime DATETIME NOT NULL,
    FOREIGN KEY (SenderID) REFERENCES Users(UserID),
    FOREIGN KEY (ReceiverID) REFERENCES Users(UserID)
);
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1, 1),
    UserID INT NOT NULL,
    Date DATE NOT NULL,
    TimeIn TIME,
    TimeOut TIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
