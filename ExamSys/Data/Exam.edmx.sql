
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/11/2016 20:40:25
-- Generated from EDMX file: C:\Users\Alley\Documents\GitHub\ExamSys_Test\ExamSys\Data\Exam.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ExamSys];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Questions_EmployeeType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_Questions_EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[FK_Questions_SubjectType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_Questions_SubjectType];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[EmployeeType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeType];
GO
IF OBJECT_ID(N'[dbo].[Questions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Questions];
GO
IF OBJECT_ID(N'[dbo].[SubjectType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'EmployeeType'
CREATE TABLE [dbo].[EmployeeType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EType] nvarchar(20)  NOT NULL,
    [ETypeName] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'Questions'
CREATE TABLE [dbo].[Questions] (
    [ID] uniqueidentifier  NOT NULL,
    [CreateTime] datetime  NULL,
    [LastUpdateTime] datetime  NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NULL,
    [Answer] nvarchar(max)  NULL,
    [EmployeeTypeID] int  NOT NULL,
    [SubjectTypeID] int  NOT NULL,
    [IsDelete] bit  NOT NULL,
    [Score] int  NULL
);
GO

-- Creating table 'SubjectType'
CREATE TABLE [dbo].[SubjectType] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SType] nvarchar(20)  NOT NULL,
    [STypeName] nvarchar(20)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'EmployeeType'
ALTER TABLE [dbo].[EmployeeType]
ADD CONSTRAINT [PK_EmployeeType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [PK_Questions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SubjectType'
ALTER TABLE [dbo].[SubjectType]
ADD CONSTRAINT [PK_SubjectType]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmployeeTypeID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Questions_EmployeeType]
    FOREIGN KEY ([EmployeeTypeID])
    REFERENCES [dbo].[EmployeeType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Questions_EmployeeType'
CREATE INDEX [IX_FK_Questions_EmployeeType]
ON [dbo].[Questions]
    ([EmployeeTypeID]);
GO

-- Creating foreign key on [SubjectTypeID] in table 'Questions'
ALTER TABLE [dbo].[Questions]
ADD CONSTRAINT [FK_Questions_SubjectType]
    FOREIGN KEY ([SubjectTypeID])
    REFERENCES [dbo].[SubjectType]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Questions_SubjectType'
CREATE INDEX [IX_FK_Questions_SubjectType]
ON [dbo].[Questions]
    ([SubjectTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------