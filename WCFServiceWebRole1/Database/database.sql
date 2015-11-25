CREATE DATABASE [3SemesterProjektDb]
GO
USE [3SemesterProjektDb]

CREATE TABLE [dbo].[Bevaegelser] (
    [Id]         INT            NOT NULL,
    [Tidspunkt]  DATETIME       NOT NULL,
    [Temperatur] DECIMAL (4, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO Bevaegelser VALUES ('25-11-2015 21:00:00', '20');
INSERT INTO Bevaegelser VALUES ('25-11-2015 23:00:00', '23');
CREATE TABLE [dbo].[Brugere] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Brugernavn] VARCHAR (50)  NOT NULL,
    [Password]   VARCHAR (100) NOT NULL,
    [Email]      VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO Brugere VALUES ('Daniel', 'Secret12', 'danielwinther@hotmail.dk');
INSERT INTO Brugere VALUES ('Benjamin', 'Secret12', 'belzamouri@gmail.com');
INSERT INTO Brugere VALUES ('Jacob', 'Secret12', 'jacob.balling@hotmail.com');
INSERT INTO Brugere VALUES ('Jari', 'Secret12', 'jarimalte@gmail.com');
CREATE TABLE [dbo].[Tid] (
    [Id]  INT      IDENTITY (1, 1) NOT NULL,
    [Fra] TIME (0) NOT NULL,
    [Til] TIME (0) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
INSERT INTO Tider VALUES ('07:00', '21:00');
INSERT INTO Tider VALUES ('09:00', '17:00');
