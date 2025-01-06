-- トランザクション開始（オプション）
BEGIN TRANSACTION;

-- Authors テーブルへのデータ挿入
INSERT INTO Authors (Name) VALUES 
('George Orwell'),          -- 初期データ
('Robert C. Martin'),       -- Clean Codeの著者
('Andrew Hunt'),            -- The Pragmatic Programmerの共著者
('David Thomas'),           -- The Pragmatic Programmerの共著者
('Martin Fowler'),          -- Refactoringの著者
('Eric Evans'),             -- Domain-Driven Designの著者
('Kent Beck'),              -- Test-Driven Developmentの著者
('Don Box'),                -- Essential COMの著者
('Jeffrey Richter');        -- CLR via C#の著者

-- Books テーブルへのデータ挿入
INSERT INTO Books (Title, AuthorId) VALUES 
('1984', (SELECT AuthorId FROM Authors WHERE Name = 'George Orwell')),
('Animal Farm', (SELECT AuthorId FROM Authors WHERE Name = 'George Orwell')),
('Clean Code', (SELECT AuthorId FROM Authors WHERE Name = 'Robert C. Martin')),
('The Pragmatic Programmer', (SELECT AuthorId FROM Authors WHERE Name = 'Andrew Hunt')),
('The Pragmatic Programmer', (SELECT AuthorId FROM Authors WHERE Name = 'David Thomas')),
('Refactoring', (SELECT AuthorId FROM Authors WHERE Name = 'Martin Fowler')),
('Domain-Driven Design', (SELECT AuthorId FROM Authors WHERE Name = 'Eric Evans')),
('Test-Driven Development: By Example', (SELECT AuthorId FROM Authors WHERE Name = 'Kent Beck')),
('Essential COM', (SELECT AuthorId FROM Authors WHERE Name = 'Don Box')),
('CLR via C#', (SELECT AuthorId FROM Authors WHERE Name = 'Jeffrey Richter'));

-- トランザクションコミット（オプション）
COMMIT TRANSACTION;