-- Create the database
CREATE DATABASE IF NOT EXISTS TodoService;

-- Use the database
USE TodoService;

-- Show tables
SHOW TABLES;

-- Create todos table
CREATE TABLE todos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    UserId INT NOT NULL,
    Title VARCHAR(255) NOT NULL,
    Description TEXT,
    IsCompleted BOOLEAN DEFAULT FALSE,
    Status VARCHAR(1) DEFAULT 'A',
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO todos (UserId, Title, Description, IsCompleted)
VALUES
    (1, 'Buy groceries', 'Milk, Bread, Eggs, Cheese', FALSE),
    (2, 'Finish report', 'Complete the sales report by EOD', FALSE),
    (3, 'Workout', '30-minute cardio session', TRUE),
    (4, 'Call mom', 'Check in and have a chat', FALSE),
    (5, 'Clean the house', 'Sweep and mop all floors', TRUE),
    (1, 'Read book', 'Finish reading 2 chapters', FALSE),
    (2, 'Pay bills', 'Electricity and internet', TRUE),
    (3, 'Attend meeting', 'Project kickoff meeting at 10 AM', FALSE),
    (4, 'Buy dog food', 'Dry dog food, 10kg bag', TRUE),
    (5, 'Plan vacation', 'Look for resorts in Batangas', FALSE);
