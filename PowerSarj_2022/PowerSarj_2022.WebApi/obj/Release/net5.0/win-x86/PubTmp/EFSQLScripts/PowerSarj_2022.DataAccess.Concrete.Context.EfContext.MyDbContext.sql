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
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [Admins] (
        [_id] nvarchar(450) NOT NULL,
        [adminid] nvarchar(max) NULL,
        [name] nvarchar(max) NULL,
        [surname] nvarchar(max) NULL,
        [username] nvarchar(max) NULL,
        [site] nvarchar(max) NULL,
        [password] nvarchar(max) NULL,
        [mail] nvarchar(max) NULL,
        [tel] nvarchar(max) NULL,
        [lastlogin] datetime2 NOT NULL,
        CONSTRAINT [PK_Admins] PRIMARY KEY ([_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [Users] (
        [_id] nvarchar(450) NOT NULL,
        [userid] nvarchar(450) NULL,
        [cardid] nvarchar(max) NULL,
        [username] nvarchar(max) NULL,
        [site] nvarchar(max) NULL,
        [password] nvarchar(max) NULL,
        [date] datetime2 NOT NULL,
        [__v] int NOT NULL,
        [balance] decimal(18,2) NOT NULL,
        [chargingdevice] nvarchar(max) NULL,
        [updatedAt] datetime2 NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([_id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [Devices] (
        [_id] nvarchar(450) NOT NULL,
        [deviceid] nvarchar(max) NULL,
        [location] nvarchar(max) NULL,
        [type] nvarchar(max) NULL,
        [site] nvarchar(max) NULL,
        [state] nvarchar(max) NULL,
        [price] decimal(18,2) NOT NULL,
        [charginguser] nvarchar(max) NULL,
        [mobilecharging] nvarchar(max) NULL,
        [devicename] nvarchar(max) NULL,
        [date] datetime2 NOT NULL,
        [adminid] nvarchar(450) NULL,
        CONSTRAINT [PK_Devices] PRIMARY KEY ([_id]),
        CONSTRAINT [FK_Devices_Admins_adminid] FOREIGN KEY ([adminid]) REFERENCES [Admins] ([_id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [Fills] (
        [_id] nvarchar(450) NOT NULL,
        [amount] decimal(18,2) NOT NULL,
        [lastbalance] decimal(18,2) NOT NULL,
        [admin] nvarchar(max) NULL,
        [date] datetime2 NOT NULL,
        [user_id] nvarchar(450) NULL,
        CONSTRAINT [PK_Fills] PRIMARY KEY ([_id]),
        CONSTRAINT [FK_Fills_Users_user_id] FOREIGN KEY ([user_id]) REFERENCES [Users] ([_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [AllowedSites] (
        [_id] nvarchar(450) NOT NULL,
        [Name] nvarchar(max) NULL,
        [Device_id] nvarchar(450) NULL,
        CONSTRAINT [PK_AllowedSites] PRIMARY KEY ([_id]),
        CONSTRAINT [FK_AllowedSites_Devices_Device_id] FOREIGN KEY ([Device_id]) REFERENCES [Devices] ([_id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [DeviceUser] (
        [User_id] nvarchar(450) NOT NULL,
        [devices_id] nvarchar(450) NOT NULL,
        CONSTRAINT [PK_DeviceUser] PRIMARY KEY ([User_id], [devices_id]),
        CONSTRAINT [FK_DeviceUser_Devices_devices_id] FOREIGN KEY ([devices_id]) REFERENCES [Devices] ([_id]) ON DELETE CASCADE,
        CONSTRAINT [FK_DeviceUser_Users_User_id] FOREIGN KEY ([User_id]) REFERENCES [Users] ([_id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE TABLE [Operations] (
        [_id] nvarchar(450) NOT NULL,
        [operation] nvarchar(max) NULL,
        [energy] float NOT NULL,
        [amount] decimal(18,2) NOT NULL,
        [duration] int NOT NULL,
        [date] datetime2 NOT NULL,
        [user_id] nvarchar(450) NULL,
        [device_id] nvarchar(450) NULL,
        CONSTRAINT [PK_Operations] PRIMARY KEY ([_id]),
        CONSTRAINT [FK_Operations_Devices_device_id] FOREIGN KEY ([device_id]) REFERENCES [Devices] ([_id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Operations_Users_user_id] FOREIGN KEY ([user_id]) REFERENCES [Users] ([_id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'lastlogin', N'mail', N'name', N'password', N'site', N'surname', N'tel', N'username') AND [object_id] = OBJECT_ID(N'[Admins]'))
        SET IDENTITY_INSERT [Admins] ON;
    EXEC(N'INSERT INTO [Admins] ([_id], [adminid], [lastlogin], [mail], [name], [password], [site], [surname], [tel], [username])
    VALUES (N''MARSIS_ADMIN_1'', N''mberkayakar'', ''0001-01-01T00:00:00.0000000'', N''m.berkay.akar@gmail.com'', N''Berkay'', N''1234'', N''WHITEROSE'', N''AKAR'', N''0552 693 14 36'', N''MBerkayAkar10'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'lastlogin', N'mail', N'name', N'password', N'site', N'surname', N'tel', N'username') AND [object_id] = OBJECT_ID(N'[Admins]'))
        SET IDENTITY_INSERT [Admins] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'lastlogin', N'mail', N'name', N'password', N'site', N'surname', N'tel', N'username') AND [object_id] = OBJECT_ID(N'[Admins]'))
        SET IDENTITY_INSERT [Admins] ON;
    EXEC(N'INSERT INTO [Admins] ([_id], [adminid], [lastlogin], [mail], [name], [password], [site], [surname], [tel], [username])
    VALUES (N''MARSIS_ADMIN_2'', N''recepcengiz'', ''0001-01-01T00:00:00.0000000'', N''recepcengiz@gmail.com'', N''Recep'', N''1234'', N''MAR-SİS BİLİSİM'', N''Cengiz'', N''0555 XXX YY ZZ'', N''recepcengiz'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'lastlogin', N'mail', N'name', N'password', N'site', N'surname', N'tel', N'username') AND [object_id] = OBJECT_ID(N'[Admins]'))
        SET IDENTITY_INSERT [Admins] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] ON;
    EXEC(N'INSERT INTO [Devices] ([_id], [adminid], [charginguser], [date], [deviceid], [devicename], [location], [mobilecharging], [price], [site], [state], [type])
    VALUES (N''MARDEV_1'', N''MARSIS_ADMIN_1'', NULL, ''2022-06-08T11:40:49.0427048+03:00'', N''MARDEV_1'', N''MARSISBILISIM_DEVICE_1'', N''36.36 , 36.36'', NULL, 0.0, N''WHITEROSE'', NULL, N''AC'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] ON;
    EXEC(N'INSERT INTO [Devices] ([_id], [adminid], [charginguser], [date], [deviceid], [devicename], [location], [mobilecharging], [price], [site], [state], [type])
    VALUES (N''MARDEV_2'', N''MARSIS_ADMIN_2'', NULL, ''2022-06-08T11:40:49.0432090+03:00'', N''MARDEV_2'', N''MARSISBILISIM_DEVICE_2'', N''36.37 , 36.37'', NULL, 0.0, N''MAR-SİS BİLİSİM'', NULL, N''AC'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] ON;
    EXEC(N'INSERT INTO [Devices] ([_id], [adminid], [charginguser], [date], [deviceid], [devicename], [location], [mobilecharging], [price], [site], [state], [type])
    VALUES (N''MARDEV_3'', N''MARSIS_ADMIN_2'', NULL, ''2022-06-08T11:40:49.0432112+03:00'', N''MARDEV_3'', N''MARSISBILISIM_DEVICE_3'', N''36.37 , 36.37'', NULL, 0.0, N''MAR-SİS BİLİSİM'', NULL, N''DC'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'_id', N'adminid', N'charginguser', N'date', N'deviceid', N'devicename', N'location', N'mobilecharging', N'price', N'site', N'state', N'type') AND [object_id] = OBJECT_ID(N'[Devices]'))
        SET IDENTITY_INSERT [Devices] OFF;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_AllowedSites_Device_id] ON [AllowedSites] ([Device_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_Devices_adminid] ON [Devices] ([adminid]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_DeviceUser_devices_id] ON [DeviceUser] ([devices_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_Fills_user_id] ON [Fills] ([user_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_Operations_device_id] ON [Operations] ([device_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    CREATE INDEX [IX_Operations_user_id] ON [Operations] ([user_id]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Users_userid] ON [Users] ([userid]) WHERE [userid] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220608084049_mig1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220608084049_mig1', N'5.0.15');
END;
GO

COMMIT;
GO

