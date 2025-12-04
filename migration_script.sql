IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250920160505_InitialCreate'
)
BEGIN
    CREATE TABLE [Clientes] (
        [IdCliente] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [Apellido] nvarchar(max) NOT NULL,
        [Email] nvarchar(max) NOT NULL,
        [Telefono] nvarchar(max) NOT NULL,
        [NombreUsuario] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Clientes] PRIMARY KEY ([IdCliente])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250920160505_InitialCreate'
)
BEGIN
    CREATE TABLE [Salones] (
        [IdSalon] int NOT NULL IDENTITY,
        [NombreSalon] nvarchar(max) NOT NULL,
        [Estado] nvarchar(max) NOT NULL,
        [MontoSalon] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Salones] PRIMARY KEY ([IdSalon])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250920160505_InitialCreate'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250920160505_InitialCreate', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250924150535_AddBarraEntityAndConfigureDecimals'
)
BEGIN
    CREATE TABLE [Barras] (
        [IdBarra] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NOT NULL,
        [TipoBebida] nvarchar(max) NOT NULL,
        [PrecioPorHora] decimal(18,2) NOT NULL,
        [Estado] nvarchar(max) NOT NULL,
        [Descripcion] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Barras] PRIMARY KEY ([IdBarra])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250924150535_AddBarraEntityAndConfigureDecimals'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250924150535_AddBarraEntityAndConfigureDecimals', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250924151600_AddDjEntity'
)
BEGIN
    CREATE TABLE [Djs] (
        [IdDj] int NOT NULL IDENTITY,
        [NombreArtistico] nvarchar(100) NOT NULL,
        [Estado] nvarchar(50) NOT NULL,
        [MontoDj] decimal(18,2) NOT NULL,
        [Foto] nvarchar(255) NULL,
        CONSTRAINT [PK_Djs] PRIMARY KEY ([IdDj])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250924151600_AddDjEntity'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Djs_NombreArtistico] ON [Djs] ([NombreArtistico]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250924151600_AddDjEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250924151600_AddDjEntity', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250925150042_AddUsuarioEntity'
)
BEGIN
    CREATE TABLE [Usuarios] (
        [IdUsuario] int NOT NULL IDENTITY,
        [NombreUsuario] nvarchar(50) NOT NULL,
        [Password] nvarchar(255) NOT NULL,
        [Rol] nvarchar(20) NOT NULL,
        [Nombre] nvarchar(100) NOT NULL,
        [Apellido] nvarchar(100) NOT NULL,
        [Email] nvarchar(150) NULL,
        [Telefono] nvarchar(20) NULL,
        [FechaCreacion] datetime2 NOT NULL,
        [Activo] bit NOT NULL,
        CONSTRAINT [PK_Usuarios] PRIMARY KEY ([IdUsuario])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250925150042_AddUsuarioEntity'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Usuarios_NombreUsuario] ON [Usuarios] ([NombreUsuario]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250925150042_AddUsuarioEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250925150042_AddUsuarioEntity', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250926134559_AddGastronomicoEntity'
)
BEGIN
    CREATE TABLE [Gastronomicos] (
        [IdGastro] int NOT NULL IDENTITY,
        [TipoComida] nvarchar(100) NOT NULL,
        [Foto] nvarchar(255) NULL,
        [Nombre] nvarchar(100) NOT NULL,
        [MontoG] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_Gastronomicos] PRIMARY KEY ([IdGastro])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250926134559_AddGastronomicoEntity'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250926134559_AddGastronomicoEntity', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [Solicitudes] (
        [IdSolicitud] int NOT NULL IDENTITY,
        [IdCliente] int NOT NULL,
        [FechaDesde] datetime2 NOT NULL,
        [MontoDJ] decimal(18,2) NOT NULL,
        [MontoSalon] decimal(18,2) NOT NULL,
        [MontoGastro] decimal(18,2) NOT NULL,
        [MontoBarra] decimal(18,2) NOT NULL,
        [Estado] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Solicitudes] PRIMARY KEY ([IdSolicitud]),
        CONSTRAINT [FK_Solicitudes_Clientes_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes] ([IdCliente]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [Zonas] (
        [IdZona] int NOT NULL IDENTITY,
        [Nombre] nvarchar(100) NOT NULL,
        CONSTRAINT [PK_Zonas] PRIMARY KEY ([IdZona])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [BarraSolicitudes] (
        [IdBarraSolicitud] int NOT NULL IDENTITY,
        [IdBarra] int NOT NULL,
        [IdSolicitud] int NOT NULL,
        CONSTRAINT [PK_BarraSolicitudes] PRIMARY KEY ([IdBarraSolicitud]),
        CONSTRAINT [FK_BarraSolicitudes_Barras_IdBarra] FOREIGN KEY ([IdBarra]) REFERENCES [Barras] ([IdBarra]) ON DELETE NO ACTION,
        CONSTRAINT [FK_BarraSolicitudes_Solicitudes_IdSolicitud] FOREIGN KEY ([IdSolicitud]) REFERENCES [Solicitudes] ([IdSolicitud]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [DjSolicitudes] (
        [IdDjSolicitud] int NOT NULL IDENTITY,
        [IdDj] int NOT NULL,
        [IdSolicitud] int NOT NULL,
        CONSTRAINT [PK_DjSolicitudes] PRIMARY KEY ([IdDjSolicitud]),
        CONSTRAINT [FK_DjSolicitudes_Djs_IdDj] FOREIGN KEY ([IdDj]) REFERENCES [Djs] ([IdDj]) ON DELETE NO ACTION,
        CONSTRAINT [FK_DjSolicitudes_Solicitudes_IdSolicitud] FOREIGN KEY ([IdSolicitud]) REFERENCES [Solicitudes] ([IdSolicitud]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [GastroSolicitudes] (
        [IdGastroSolicitud] int NOT NULL IDENTITY,
        [IdGastro] int NOT NULL,
        [IdSolicitud] int NOT NULL,
        CONSTRAINT [PK_GastroSolicitudes] PRIMARY KEY ([IdGastroSolicitud]),
        CONSTRAINT [FK_GastroSolicitudes_Gastronomicos_IdGastro] FOREIGN KEY ([IdGastro]) REFERENCES [Gastronomicos] ([IdGastro]) ON DELETE NO ACTION,
        CONSTRAINT [FK_GastroSolicitudes_Solicitudes_IdSolicitud] FOREIGN KEY ([IdSolicitud]) REFERENCES [Solicitudes] ([IdSolicitud]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [SalonSolicitudes] (
        [IdSalonSolicitud] int NOT NULL IDENTITY,
        [IdSalon] int NOT NULL,
        [IdSolicitud] int NOT NULL,
        CONSTRAINT [PK_SalonSolicitudes] PRIMARY KEY ([IdSalonSolicitud]),
        CONSTRAINT [FK_SalonSolicitudes_Salones_IdSalon] FOREIGN KEY ([IdSalon]) REFERENCES [Salones] ([IdSalon]) ON DELETE NO ACTION,
        CONSTRAINT [FK_SalonSolicitudes_Solicitudes_IdSolicitud] FOREIGN KEY ([IdSolicitud]) REFERENCES [Solicitudes] ([IdSolicitud]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [ZonaBarras] (
        [IdZonaBarra] int NOT NULL IDENTITY,
        [IdZona] int NOT NULL,
        [IdBarra] int NOT NULL,
        CONSTRAINT [PK_ZonaBarras] PRIMARY KEY ([IdZonaBarra]),
        CONSTRAINT [FK_ZonaBarras_Barras_IdBarra] FOREIGN KEY ([IdBarra]) REFERENCES [Barras] ([IdBarra]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZonaBarras_Zonas_IdZona] FOREIGN KEY ([IdZona]) REFERENCES [Zonas] ([IdZona]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [ZonaDJs] (
        [IdZonaDJ] int NOT NULL IDENTITY,
        [IdZona] int NOT NULL,
        [IdDj] int NOT NULL,
        CONSTRAINT [PK_ZonaDJs] PRIMARY KEY ([IdZonaDJ]),
        CONSTRAINT [FK_ZonaDJs_Djs_IdDj] FOREIGN KEY ([IdDj]) REFERENCES [Djs] ([IdDj]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZonaDJs_Zonas_IdZona] FOREIGN KEY ([IdZona]) REFERENCES [Zonas] ([IdZona]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [ZonaGastros] (
        [IdZonaGastro] int NOT NULL IDENTITY,
        [IdZona] int NOT NULL,
        [IdGastro] int NOT NULL,
        CONSTRAINT [PK_ZonaGastros] PRIMARY KEY ([IdZonaGastro]),
        CONSTRAINT [FK_ZonaGastros_Gastronomicos_IdGastro] FOREIGN KEY ([IdGastro]) REFERENCES [Gastronomicos] ([IdGastro]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZonaGastros_Zonas_IdZona] FOREIGN KEY ([IdZona]) REFERENCES [Zonas] ([IdZona]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE TABLE [ZonaSalones] (
        [IdZonaSalon] int NOT NULL IDENTITY,
        [IdZona] int NOT NULL,
        [IdSalon] int NOT NULL,
        CONSTRAINT [PK_ZonaSalones] PRIMARY KEY ([IdZonaSalon]),
        CONSTRAINT [FK_ZonaSalones_Salones_IdSalon] FOREIGN KEY ([IdSalon]) REFERENCES [Salones] ([IdSalon]) ON DELETE NO ACTION,
        CONSTRAINT [FK_ZonaSalones_Zonas_IdZona] FOREIGN KEY ([IdZona]) REFERENCES [Zonas] ([IdZona]) ON DELETE NO ACTION
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_BarraSolicitudes_IdBarra] ON [BarraSolicitudes] ([IdBarra]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_BarraSolicitudes_IdSolicitud] ON [BarraSolicitudes] ([IdSolicitud]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_DjSolicitudes_IdDj] ON [DjSolicitudes] ([IdDj]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_DjSolicitudes_IdSolicitud] ON [DjSolicitudes] ([IdSolicitud]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_GastroSolicitudes_IdGastro] ON [GastroSolicitudes] ([IdGastro]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_GastroSolicitudes_IdSolicitud] ON [GastroSolicitudes] ([IdSolicitud]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_SalonSolicitudes_IdSalon] ON [SalonSolicitudes] ([IdSalon]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_SalonSolicitudes_IdSolicitud] ON [SalonSolicitudes] ([IdSolicitud]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_Solicitudes_IdCliente] ON [Solicitudes] ([IdCliente]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaBarras_IdBarra] ON [ZonaBarras] ([IdBarra]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaBarras_IdZona] ON [ZonaBarras] ([IdZona]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaDJs_IdDj] ON [ZonaDJs] ([IdDj]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaDJs_IdZona] ON [ZonaDJs] ([IdZona]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaGastros_IdGastro] ON [ZonaGastros] ([IdGastro]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaGastros_IdZona] ON [ZonaGastros] ([IdZona]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaSalones_IdSalon] ON [ZonaSalones] ([IdSalon]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    CREATE INDEX [IX_ZonaSalones_IdZona] ON [ZonaSalones] ([IdZona]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251025151504_AddZonaSolicitudAndRelations'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251025151504_AddZonaSolicitudAndRelations', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var sysname;
    SELECT @var = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Solicitudes]') AND [c].[name] = N'MontoBarra');
    IF @var IS NOT NULL EXEC(N'ALTER TABLE [Solicitudes] DROP CONSTRAINT [' + @var + '];');
    ALTER TABLE [Solicitudes] DROP COLUMN [MontoBarra];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Solicitudes]') AND [c].[name] = N'MontoDJ');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Solicitudes] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Solicitudes] DROP COLUMN [MontoDJ];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Solicitudes]') AND [c].[name] = N'MontoGastro');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Solicitudes] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Solicitudes] DROP COLUMN [MontoGastro];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Solicitudes]') AND [c].[name] = N'MontoSalon');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Solicitudes] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Solicitudes] DROP COLUMN [MontoSalon];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Gastronomicos]') AND [c].[name] = N'Foto');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Gastronomicos] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Gastronomicos] DROP COLUMN [Foto];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Djs]') AND [c].[name] = N'Foto');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Djs] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Djs] DROP COLUMN [Foto];
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251026183815_RemoveImageFieldsAndSolicitudPrices'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251026183815_RemoveImageFieldsAndSolicitudPrices', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251116142214_AddEstadoToGastronomico'
)
BEGIN
    ALTER TABLE [Gastronomicos] ADD [Estado] nvarchar(50) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251116142214_AddEstadoToGastronomico'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251116142214_AddEstadoToGastronomico', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251116143306_UpdateGastronomicoEstadoDefault'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251116143306_UpdateGastronomicoEstadoDefault', N'9.0.9');
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Telefono');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Clientes] ALTER COLUMN [Telefono] nvarchar(20) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'NombreUsuario');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Clientes] ALTER COLUMN [NombreUsuario] nvarchar(50) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Nombre');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Clientes] ALTER COLUMN [Nombre] nvarchar(100) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Email');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Clientes] ALTER COLUMN [Email] nvarchar(150) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Clientes]') AND [c].[name] = N'Apellido');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Clientes] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Clientes] ALTER COLUMN [Apellido] nvarchar(100) NOT NULL;
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    ALTER TABLE [Clientes] ADD [Clave] nvarchar(255) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    ALTER TABLE [Clientes] ADD [Rol] nvarchar(20) NOT NULL DEFAULT N'';
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20251204162129_AddClaveAndRolToCliente'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20251204162129_AddClaveAndRolToCliente', N'9.0.9');
END;

COMMIT;
GO

