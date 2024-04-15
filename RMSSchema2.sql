-- Users table remains unchanged
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1, 1),
    Username VARCHAR(255) NOT NULL UNIQUE,
    PasswordHash VARBINARY(256) NOT NULL,
    Phone VARCHAR(20),
    Email VARCHAR(255),
    Role VARCHAR(50) NOT NULL,
    Since DATE,
    Picture VARBINARY(MAX),
    Salary DECIMAL(10, 2),
    TipEarned DECIMAL(10, 2) DEFAULT 0
);

-- Items table remains unchanged
CREATE TABLE Items (
    ItemID INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    CostOfPurchase DECIMAL(10, 2),
    Picture VARBINARY(MAX)
);

-- Orders table adjusted for cascade on CustomerID, no action on RiderID
CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1, 1),
    CustomerID INT NOT NULL,
    Date_Time DATETIME NOT NULL,
    TotalAmount DECIMAL(10, 2) NOT NULL,
    OrderType VARCHAR(50) CHECK (OrderType IN ('online', 'offline')),
    Address VARCHAR(255),
    PaymentMethod VARCHAR(50) NOT NULL,
    Tip DECIMAL(10, 2),
    DeliveryCharges DECIMAL(10, 2),
    Status VARCHAR(50),
    RiderID INT,
    FOREIGN KEY (CustomerID) REFERENCES Users(UserID) ON DELETE CASCADE,
    FOREIGN KEY (RiderID) REFERENCES Users(UserID) ON DELETE NO ACTION
);

-- OrderDetails table remains unchanged
CREATE TABLE OrderDetails (
    OrderID INT,
    ItemID INT,
    Quantity INT NOT NULL,
    PRIMARY KEY (OrderID, ItemID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID) ON DELETE CASCADE
);

-- Carts and CartItems tables remain unchanged, assuming cascade on deletion from Users
CREATE TABLE Carts (
    CartID INT PRIMARY KEY IDENTITY(1, 1),
    UserID INT NOT NULL,
    CreatedDate DATETIME NOT NULL,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);
CREATE TABLE CartItems (
    CartItemID INT PRIMARY KEY IDENTITY(1, 1),
    CartID INT NOT NULL,
    ItemID INT NOT NULL,
    Quantity INT NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (CartID) REFERENCES Carts(CartID) ON DELETE CASCADE,
    FOREIGN KEY (ItemID) REFERENCES Items(ItemID) ON DELETE CASCADE
);

-- Inbox table adjusted for cascading delete on sender and receiver
-- Define other tables as previously stated, focusing on changes to Inbox:
CREATE TABLE Inbox (
    MessageID INT PRIMARY KEY IDENTITY(1, 1),
    SenderID INT NOT NULL,
    ReceiverID INT NOT NULL,
    MessageText TEXT NOT NULL,
    SentDateTime DATETIME NOT NULL,
    FOREIGN KEY (SenderID) REFERENCES Users(UserID) ON DELETE CASCADE, -- Cascade when sender is deleted
    FOREIGN KEY (ReceiverID) REFERENCES Users(UserID) ON DELETE NO ACTION -- No automatic action when receiver is deleted
);


-- Attendance table remains unchanged
CREATE TABLE Attendance (
    AttendanceID INT PRIMARY KEY IDENTITY(1, 1),
    UserID INT NOT NULL,
    Date DATE NOT NULL,
    TimeIn TIME,
    TimeOut TIME,
    FOREIGN KEY (UserID) REFERENCES Users(UserID) ON DELETE CASCADE
);
