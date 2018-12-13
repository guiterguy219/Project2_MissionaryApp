CREATE TABLE Mission (
	missionId INT NOT NULL IDENTITY(1,1),
	missionName NVARCHAR(100) NOT NULL,
	president NVARCHAR(100) NOT NULL,
	address NVARCHAR(250) NOT NULL,
	language NVARCHAR(50) NOT NULL,
	climate NVARCHAR(250) NOT NULL,
	dominantReligion NVARCHAR(50) NOT NULL,
	logoFilePath NVARCHAR(250) NOT NULL,
	PRIMARY KEY CLUSTERED ([missionId] ASC)
);

CREATE TABLE MissionQuestions (
	missionQuestionId INT NOT NULL IDENTITY(1,1),
	missionId INT NOT NULL,
	userId NVARCHAR(250) NOT NULL,
	question NVARCHAR(1000) NOT NULL,
	PRIMARY KEY CLUSTERED ([missionQuestionId] ASC),
	FOREIGN KEY ([missionId]) REFERENCES [dbo].[Mission]([missionId])
);

CREATE TABLE MissionAnswers (
	missionAnswerId INT NOT NULL IDENTITY (1,1),
	missionQuestionId INT             NOT NULL,
    answer           NVARCHAR (1000) NOT NULL,
    userId            NVARCHAR (250)  NOT NULL,
	PRIMARY KEY CLUSTERED ([missionAnswerId] ASC),
	FOREIGN KEY ([missionQuestionId]) REFERENCES [dbo].[MissionQuestions]([missionQuestionId])
);