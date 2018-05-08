CREATE TABLE [dbo].[Question] (
    [Id]						BIGINT	IDENTITY (1, 1) NOT NULL,
	[QuestionDescription]		NVARCHAR (256)			NOT NULL,
    [ImageUrl]                  NVARCHAR (256)			NULL,
    [ThumbUrl]                  NVARCHAR (256)			NULL,
    [PublishedAt]               DATETIME2 (7)			NOT NULL,
    CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED ([Id] ASC)
);