
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server Compact Edition
-- --------------------------------------------------
-- Date Created: 12/12/2016 01:42:07
-- Generated from EDMX file: G:\Work\SongManager\trunk\SongManager\RadioEtherMonitor\Model.edmx
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- NOTE: if the constraint does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    ALTER TABLE [PerformerSet] DROP CONSTRAINT [FK_CountryPerformer];
GO
    ALTER TABLE [SongSet] DROP CONSTRAINT [FK_PerformerSong];
GO
    ALTER TABLE [CountryGroupCountry] DROP CONSTRAINT [FK_CountryGroupCountry_CountryGroup];
GO
    ALTER TABLE [CountryGroupCountry] DROP CONSTRAINT [FK_CountryGroupCountry_Country];
GO
    ALTER TABLE [QuoteSet] DROP CONSTRAINT [FK_LanguageQuote];
GO
    ALTER TABLE [QuoteSet] DROP CONSTRAINT [FK_CountryGroupQuote];
GO
    ALTER TABLE [SongSet] DROP CONSTRAINT [FK_LanguageSong];
GO
    ALTER TABLE [PerformanceSet] DROP CONSTRAINT [FK_SongPerformance];
GO
    ALTER TABLE [PerformanceSet] DROP CONSTRAINT [FK_RadioStationPerformance];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- NOTE: if the table does not exist, an ignorable error will be reported.
-- --------------------------------------------------

    DROP TABLE [PerformerSet];
GO
    DROP TABLE [SongSet];
GO
    DROP TABLE [CountrySet];
GO
    DROP TABLE [CountryGroupSet];
GO
    DROP TABLE [LanguageSet];
GO
    DROP TABLE [QuoteSet];
GO
    DROP TABLE [PerformanceSet];
GO
    DROP TABLE [RadioStationSet];
GO
    DROP TABLE [CountryGroupCountry];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PerformerSet'
CREATE TABLE [PerformerSet] (
    [Id] uniqueidentifier  NOT NULL,
    [StageName] nvarchar(4000)  NOT NULL,
    [CountryId] uniqueidentifier  NULL
);
GO

-- Creating table 'SongSet'
CREATE TABLE [SongSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(4000)  NOT NULL,
    [Duration] float  NOT NULL,
    [PerformerId] uniqueidentifier  NULL,
    [PerformerId1] uniqueidentifier  NULL,
    [LanguageId] uniqueidentifier  NULL
);
GO

-- Creating table 'CountrySet'
CREATE TABLE [CountrySet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsoCode] nvarchar(4000)  NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'CountryGroupSet'
CREATE TABLE [CountryGroupSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'LanguageSet'
CREATE TABLE [LanguageSet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsoCode] nvarchar(4000)  NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'QuoteSet'
CREATE TABLE [QuoteSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Percentage] decimal(18,0)  NOT NULL,
    [CountryGroupId] uniqueidentifier  NOT NULL,
    [LanguageId] uniqueidentifier  NULL,
    [CountryGroupId1] uniqueidentifier  NULL
);
GO

-- Creating table 'PerformanceSet'
CREATE TABLE [PerformanceSet] (
    [Id] uniqueidentifier  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [SongId] uniqueidentifier  NOT NULL,
    [RadioStationId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RadioStationSet'
CREATE TABLE [RadioStationSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(4000)  NOT NULL
);
GO

-- Creating table 'CountryGroupCountry'
CREATE TABLE [CountryGroupCountry] (
    [CountryGroups_Id] uniqueidentifier  NOT NULL,
    [Countries_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PerformerSet'
ALTER TABLE [PerformerSet]
ADD CONSTRAINT [PK_PerformerSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'SongSet'
ALTER TABLE [SongSet]
ADD CONSTRAINT [PK_SongSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'CountrySet'
ALTER TABLE [CountrySet]
ADD CONSTRAINT [PK_CountrySet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'CountryGroupSet'
ALTER TABLE [CountryGroupSet]
ADD CONSTRAINT [PK_CountryGroupSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'LanguageSet'
ALTER TABLE [LanguageSet]
ADD CONSTRAINT [PK_LanguageSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'QuoteSet'
ALTER TABLE [QuoteSet]
ADD CONSTRAINT [PK_QuoteSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'PerformanceSet'
ALTER TABLE [PerformanceSet]
ADD CONSTRAINT [PK_PerformanceSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [Id] in table 'RadioStationSet'
ALTER TABLE [RadioStationSet]
ADD CONSTRAINT [PK_RadioStationSet]
    PRIMARY KEY ([Id] );
GO

-- Creating primary key on [CountryGroups_Id], [Countries_Id] in table 'CountryGroupCountry'
ALTER TABLE [CountryGroupCountry]
ADD CONSTRAINT [PK_CountryGroupCountry]
    PRIMARY KEY ([CountryGroups_Id], [Countries_Id] );
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CountryId] in table 'PerformerSet'
ALTER TABLE [PerformerSet]
ADD CONSTRAINT [FK_CountryPerformer]
    FOREIGN KEY ([CountryId])
    REFERENCES [CountrySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryPerformer'
CREATE INDEX [IX_FK_CountryPerformer]
ON [PerformerSet]
    ([CountryId]);
GO

-- Creating foreign key on [PerformerId1] in table 'SongSet'
ALTER TABLE [SongSet]
ADD CONSTRAINT [FK_PerformerSong]
    FOREIGN KEY ([PerformerId1])
    REFERENCES [PerformerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerformerSong'
CREATE INDEX [IX_FK_PerformerSong]
ON [SongSet]
    ([PerformerId1]);
GO

-- Creating foreign key on [CountryGroups_Id] in table 'CountryGroupCountry'
ALTER TABLE [CountryGroupCountry]
ADD CONSTRAINT [FK_CountryGroupCountry_CountryGroup]
    FOREIGN KEY ([CountryGroups_Id])
    REFERENCES [CountryGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Countries_Id] in table 'CountryGroupCountry'
ALTER TABLE [CountryGroupCountry]
ADD CONSTRAINT [FK_CountryGroupCountry_Country]
    FOREIGN KEY ([Countries_Id])
    REFERENCES [CountrySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryGroupCountry_Country'
CREATE INDEX [IX_FK_CountryGroupCountry_Country]
ON [CountryGroupCountry]
    ([Countries_Id]);
GO

-- Creating foreign key on [LanguageId] in table 'QuoteSet'
ALTER TABLE [QuoteSet]
ADD CONSTRAINT [FK_LanguageQuote]
    FOREIGN KEY ([LanguageId])
    REFERENCES [LanguageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LanguageQuote'
CREATE INDEX [IX_FK_LanguageQuote]
ON [QuoteSet]
    ([LanguageId]);
GO

-- Creating foreign key on [CountryGroupId1] in table 'QuoteSet'
ALTER TABLE [QuoteSet]
ADD CONSTRAINT [FK_CountryGroupQuote]
    FOREIGN KEY ([CountryGroupId1])
    REFERENCES [CountryGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryGroupQuote'
CREATE INDEX [IX_FK_CountryGroupQuote]
ON [QuoteSet]
    ([CountryGroupId1]);
GO

-- Creating foreign key on [LanguageId] in table 'SongSet'
ALTER TABLE [SongSet]
ADD CONSTRAINT [FK_LanguageSong]
    FOREIGN KEY ([LanguageId])
    REFERENCES [LanguageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LanguageSong'
CREATE INDEX [IX_FK_LanguageSong]
ON [SongSet]
    ([LanguageId]);
GO

-- Creating foreign key on [SongId] in table 'PerformanceSet'
ALTER TABLE [PerformanceSet]
ADD CONSTRAINT [FK_SongPerformance]
    FOREIGN KEY ([SongId])
    REFERENCES [SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongPerformance'
CREATE INDEX [IX_FK_SongPerformance]
ON [PerformanceSet]
    ([SongId]);
GO

-- Creating foreign key on [RadioStationId] in table 'PerformanceSet'
ALTER TABLE [PerformanceSet]
ADD CONSTRAINT [FK_RadioStationPerformance]
    FOREIGN KEY ([RadioStationId])
    REFERENCES [RadioStationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadioStationPerformance'
CREATE INDEX [IX_FK_RadioStationPerformance]
ON [PerformanceSet]
    ([RadioStationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------