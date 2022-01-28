CREATE TABLE [dbo].[LineUP] (
    [ModelID] UNIQUEIDENTIFIER NOT NULL,
    [ModifID] UNIQUEIDENTIFIER NOT NULL,
    [ColorID] UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY ([ModelID]) REFERENCES [dbo].[Models] ([Id]),
    FOREIGN KEY ([ModifID]) REFERENCES [dbo].[Modifications] ([Id]),
    FOREIGN KEY ([ColorID]) REFERENCES [dbo].[Colors] ([Id])
);

