
-- --------------------------------------------------
-- Date Created: 11/16/2009 21:30:03
-- Generated from EDMX file: C:\Projects\MbUnitDemo\Vs2010Seminar\src\DataFlow\ClassLibrary1\EF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
SET ANSI_NULLS ON;
GO

USE [Personal]
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]')
GO

-- --------------------------------------------------
-- Dropping existing FK constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PersonSkill]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SkillSet] DROP CONSTRAINT [FK_PersonSkill]
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PersonSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSet];
GO
IF OBJECT_ID(N'[dbo].[SkillSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SkillSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Age] int  NOT NULL,
    [SkillId] int  NOT NULL
);
GO
-- Creating table 'SkillSet'
CREATE TABLE [dbo].[SkillSet] (
    [Id] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all Primary Key Constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet] WITH NOCHECK 
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO
-- Creating primary key on [Id] in table 'SkillSet'
ALTER TABLE [dbo].[SkillSet] WITH NOCHECK 
ADD CONSTRAINT [PK_SkillSet]
    PRIMARY KEY CLUSTERED ([Id] ASC)
    ON [PRIMARY]
GO

-- --------------------------------------------------
-- Creating all Foreign Key Constraints
-- --------------------------------------------------

-- Creating foreign key on [Person_Id] in table 'SkillSet'
ALTER TABLE [dbo].[SkillSet] WITH NOCHECK 
ADD CONSTRAINT [FK_PersonSkill]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[PersonSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------