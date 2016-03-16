CREATE TABLE [dbo].[Staging_Area6332016] (
    [Column0]        NVARCHAR (50)  NULL,
    [Column1]        NVARCHAR (50)  NULL,
    [Column2]        NVARCHAR (50)  NULL,
    [Error_Msg]      NVARCHAR (MAX) DEFAULT ('0') NULL,
    [Is_Interface]   NVARCHAR (MAX) DEFAULT ('-1') NULL,
    [Interface_Date] DATE           DEFAULT (getdate()) NULL
);

