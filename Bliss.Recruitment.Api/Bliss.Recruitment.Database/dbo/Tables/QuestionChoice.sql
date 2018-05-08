CREATE TABLE [dbo].[QuestionChoice] (
    [Id]                            BIGINT	IDENTITY (1, 1) NOT NULL,
	[QuestionId]					BIGINT					NOT NULL,
    [Name]							NVARCHAR (128)			NOT NULL,
    [Votes]							INT						NOT NULL,
    CONSTRAINT [PK_QuestionChoice]	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_QuestionChoice_Question] FOREIGN KEY ([QuestionId]) REFERENCES [Question] ([Id])
);

GO

CREATE NONCLUSTERED INDEX [IX_QuestionChoide_QuestionId] ON 
	[dbo].[QuestionChoice] ([QuestionId] ASC);