
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/27/2022 14:31:29
-- Generated from EDMX file: C:\Users\Estudiante\source\repos\AppFinanciera\Models\ModelFinanciera.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Financiera];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioExtraInfoCuentaUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaUsuarios] DROP CONSTRAINT [FK_UsuarioExtraInfoCuentaUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_TipoDeGastoMovimientoCuentas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoCuentas] DROP CONSTRAINT [FK_TipoDeGastoMovimientoCuentas];
GO
IF OBJECT_ID(N'[dbo].[FK_CuentaUsuarioMovimientoCuentas]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MovimientoCuentas] DROP CONSTRAINT [FK_CuentaUsuarioMovimientoCuentas];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[CuentaUsuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaUsuarios];
GO
IF OBJECT_ID(N'[dbo].[MovimientoCuentas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovimientoCuentas];
GO
IF OBJECT_ID(N'[dbo].[TipoDeGastos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoDeGastos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Apodo] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [EsActivo] bit  NOT NULL,
    [Pass] nvarchar(max) NOT NULL
);
GO

-- Creating table 'CuentaUsuarios'
CREATE TABLE [dbo].[CuentaUsuarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NombreCuenta] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Moneda] nvarchar(max)  NOT NULL,
    [BalanceInicial] decimal(18,0)  NOT NULL,
    [BalanceActual] decimal(18,0)  NOT NULL,
    [Tags] nvarchar(max)  NOT NULL,
    [UsuarioExtraInfoId] int  NOT NULL
);
GO

-- Creating table 'MovimientoCuentas'
CREATE TABLE [dbo].[MovimientoCuentas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Comentarios] nvarchar(max)  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [TipoDeGastoId] int  NOT NULL,
    [CuentaUsuarioId] int  NOT NULL
);
GO

-- Creating table 'TipoDeGastos'
CREATE TABLE [dbo].[TipoDeGastos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [EsActivo] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaUsuarios'
ALTER TABLE [dbo].[CuentaUsuarios]
ADD CONSTRAINT [PK_CuentaUsuarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MovimientoCuentas'
ALTER TABLE [dbo].[MovimientoCuentas]
ADD CONSTRAINT [PK_MovimientoCuentas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoDeGastos'
ALTER TABLE [dbo].[TipoDeGastos]
ADD CONSTRAINT [PK_TipoDeGastos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UsuarioExtraInfoId] in table 'CuentaUsuarios'
ALTER TABLE [dbo].[CuentaUsuarios]
ADD CONSTRAINT [FK_UsuarioExtraInfoCuentaUsuario]
    FOREIGN KEY ([UsuarioExtraInfoId])
    REFERENCES [dbo].[Usuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioExtraInfoCuentaUsuario'
CREATE INDEX [IX_FK_UsuarioExtraInfoCuentaUsuario]
ON [dbo].[CuentaUsuarios]
    ([UsuarioExtraInfoId]);
GO

-- Creating foreign key on [TipoDeGastoId] in table 'MovimientoCuentas'
ALTER TABLE [dbo].[MovimientoCuentas]
ADD CONSTRAINT [FK_TipoDeGastoMovimientoCuentas]
    FOREIGN KEY ([TipoDeGastoId])
    REFERENCES [dbo].[TipoDeGastos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipoDeGastoMovimientoCuentas'
CREATE INDEX [IX_FK_TipoDeGastoMovimientoCuentas]
ON [dbo].[MovimientoCuentas]
    ([TipoDeGastoId]);
GO

-- Creating foreign key on [CuentaUsuarioId] in table 'MovimientoCuentas'
ALTER TABLE [dbo].[MovimientoCuentas]
ADD CONSTRAINT [FK_CuentaUsuarioMovimientoCuentas]
    FOREIGN KEY ([CuentaUsuarioId])
    REFERENCES [dbo].[CuentaUsuarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaUsuarioMovimientoCuentas'
CREATE INDEX [IX_FK_CuentaUsuarioMovimientoCuentas]
ON [dbo].[MovimientoCuentas]
    ([CuentaUsuarioId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------