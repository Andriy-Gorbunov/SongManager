
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PerformerSet'
CREATE TABLE [dbo].[PerformerSet] (
    [Id] uniqueidentifier  NOT NULL,
    [StageName] nvarchar(max)  NOT NULL,
    [CountryId] uniqueidentifier  NULL
);
GO

-- Creating table 'SongSet'
CREATE TABLE [dbo].[SongSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Duration] datetimeoffset  NOT NULL,
    [PerformerId] uniqueidentifier  NULL,
    [PerformerId1] uniqueidentifier  NULL,
    [LanguageId] uniqueidentifier  NULL
);
GO

-- Creating table 'CountrySet'
CREATE TABLE [dbo].[CountrySet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsoCode] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CountryGroupSet'
CREATE TABLE [dbo].[CountryGroupSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LanguageSet'
CREATE TABLE [dbo].[LanguageSet] (
    [Id] uniqueidentifier  NOT NULL,
    [IsoCode] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'QuoteSet'
CREATE TABLE [dbo].[QuoteSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Percentage] decimal(18,0)  NOT NULL,
    [CountryGroupId] uniqueidentifier  NOT NULL,
    [LanguageId] uniqueidentifier  NULL,
    [CountryGroupId1] uniqueidentifier  NULL
);
GO

-- Creating table 'PerformanceSet'
CREATE TABLE [dbo].[PerformanceSet] (
    [Id] uniqueidentifier  NOT NULL,
    [StartTime] datetime  NOT NULL,
    [SongId] uniqueidentifier  NOT NULL,
    [RadioStationId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'RadioStationSet'
CREATE TABLE [dbo].[RadioStationSet] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CountryGroupCountry'
CREATE TABLE [dbo].[CountryGroupCountry] (
    [CountryGroups_Id] uniqueidentifier  NOT NULL,
    [Countries_Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PerformerSet'
ALTER TABLE [dbo].[PerformerSet]
ADD CONSTRAINT [PK_PerformerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SongSet'
ALTER TABLE [dbo].[SongSet]
ADD CONSTRAINT [PK_SongSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CountrySet'
ALTER TABLE [dbo].[CountrySet]
ADD CONSTRAINT [PK_CountrySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CountryGroupSet'
ALTER TABLE [dbo].[CountryGroupSet]
ADD CONSTRAINT [PK_CountryGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LanguageSet'
ALTER TABLE [dbo].[LanguageSet]
ADD CONSTRAINT [PK_LanguageSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'QuoteSet'
ALTER TABLE [dbo].[QuoteSet]
ADD CONSTRAINT [PK_QuoteSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PerformanceSet'
ALTER TABLE [dbo].[PerformanceSet]
ADD CONSTRAINT [PK_PerformanceSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RadioStationSet'
ALTER TABLE [dbo].[RadioStationSet]
ADD CONSTRAINT [PK_RadioStationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CountryGroups_Id], [Countries_Id] in table 'CountryGroupCountry'
ALTER TABLE [dbo].[CountryGroupCountry]
ADD CONSTRAINT [PK_CountryGroupCountry]
    PRIMARY KEY CLUSTERED ([CountryGroups_Id], [Countries_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CountryId] in table 'PerformerSet'
ALTER TABLE [dbo].[PerformerSet]
ADD CONSTRAINT [FK_CountryPerformer]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[CountrySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryPerformer'
CREATE INDEX [IX_FK_CountryPerformer]
ON [dbo].[PerformerSet]
    ([CountryId]);
GO

-- Creating foreign key on [PerformerId1] in table 'SongSet'
ALTER TABLE [dbo].[SongSet]
ADD CONSTRAINT [FK_PerformerSong]
    FOREIGN KEY ([PerformerId1])
    REFERENCES [dbo].[PerformerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerformerSong'
CREATE INDEX [IX_FK_PerformerSong]
ON [dbo].[SongSet]
    ([PerformerId1]);
GO

-- Creating foreign key on [CountryGroups_Id] in table 'CountryGroupCountry'
ALTER TABLE [dbo].[CountryGroupCountry]
ADD CONSTRAINT [FK_CountryGroupCountry_CountryGroup]
    FOREIGN KEY ([CountryGroups_Id])
    REFERENCES [dbo].[CountryGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Countries_Id] in table 'CountryGroupCountry'
ALTER TABLE [dbo].[CountryGroupCountry]
ADD CONSTRAINT [FK_CountryGroupCountry_Country]
    FOREIGN KEY ([Countries_Id])
    REFERENCES [dbo].[CountrySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryGroupCountry_Country'
CREATE INDEX [IX_FK_CountryGroupCountry_Country]
ON [dbo].[CountryGroupCountry]
    ([Countries_Id]);
GO

-- Creating foreign key on [LanguageId] in table 'QuoteSet'
ALTER TABLE [dbo].[QuoteSet]
ADD CONSTRAINT [FK_LanguageQuote]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[LanguageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LanguageQuote'
CREATE INDEX [IX_FK_LanguageQuote]
ON [dbo].[QuoteSet]
    ([LanguageId]);
GO

-- Creating foreign key on [CountryGroupId1] in table 'QuoteSet'
ALTER TABLE [dbo].[QuoteSet]
ADD CONSTRAINT [FK_CountryGroupQuote]
    FOREIGN KEY ([CountryGroupId1])
    REFERENCES [dbo].[CountryGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryGroupQuote'
CREATE INDEX [IX_FK_CountryGroupQuote]
ON [dbo].[QuoteSet]
    ([CountryGroupId1]);
GO

-- Creating foreign key on [LanguageId] in table 'SongSet'
ALTER TABLE [dbo].[SongSet]
ADD CONSTRAINT [FK_LanguageSong]
    FOREIGN KEY ([LanguageId])
    REFERENCES [dbo].[LanguageSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LanguageSong'
CREATE INDEX [IX_FK_LanguageSong]
ON [dbo].[SongSet]
    ([LanguageId]);
GO

-- Creating foreign key on [SongId] in table 'PerformanceSet'
ALTER TABLE [dbo].[PerformanceSet]
ADD CONSTRAINT [FK_SongPerformance]
    FOREIGN KEY ([SongId])
    REFERENCES [dbo].[SongSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SongPerformance'
CREATE INDEX [IX_FK_SongPerformance]
ON [dbo].[PerformanceSet]
    ([SongId]);
GO

-- Creating foreign key on [RadioStationId] in table 'PerformanceSet'
ALTER TABLE [dbo].[PerformanceSet]
ADD CONSTRAINT [FK_RadioStationPerformance]
    FOREIGN KEY ([RadioStationId])
    REFERENCES [dbo].[RadioStationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadioStationPerformance'
CREATE INDEX [IX_FK_RadioStationPerformance]
ON [dbo].[PerformanceSet]
    ([RadioStationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------