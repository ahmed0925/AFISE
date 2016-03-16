CREATE TABLE [dbo].[Staging_Area45332016] (
    [column0]        NVARCHAR (MAX) NULL,
    [column1]        NVARCHAR (MAX) NULL,
    [column2]        NVARCHAR (MAX) NULL,
    [column3]        NVARCHAR (MAX) NULL,
    [column4]        NVARCHAR (MAX) NULL,
    [column5]        NVARCHAR (MAX) NULL,
    [column6]        NVARCHAR (MAX) NULL,
    [column7]        NVARCHAR (MAX) NULL,
    [Error_Msg]      NVARCHAR (MAX) DEFAULT ('0') NULL,
    [Is_Interface]   NVARCHAR (MAX) DEFAULT ('-1') NULL,
    [Interface_Date] DATE           DEFAULT (getdate()) NULL
);

